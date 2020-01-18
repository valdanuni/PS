using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Windows.Forms;
using PS.Mapping.DTOs;
using PS.Models;
using PS.Persistence;
using static AutoMapper.Mapper;
using static PS.Controllers.ControllerUtils;
using static PS.Persistence.DataContext;

namespace PS.Controllers
{
    public class PatientsController : ApiController
    {
        /// <summary>
        /// Retrieve all available patients in the system.
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        [HttpGet]
        [Route("api/patients")]
        public IEnumerable<PatientDto> GetAllPatients()
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientNotAllowedToGetOtherPatients);
            return Get(dataContext => dataContext.Patients.Select(Map<Patient, PatientDto>).ToList());
        }

        /// <summary>
        /// Retrieve a specific patient from the system.
        /// Restrictions: A patient can access only himself
        /// </summary>
        /// <param name="id">The GUID of the patient</param>
        [HttpGet]
        [Route("api/patients/{id:guid}")]
        public PatientDto GetPatient(Guid id)
        {
            if (IsUserInRole(User, UserRole.Patient))
                EnsureId(User, id, Messages.PatientNotAllowedToGetOtherPatients);
            var patient = Get(dataContext =>
                dataContext.Patients.Where(p => p.Guid.Equals(id))
                    .AsEnumerable()
                    .Select(Map<Patient, PatientDto>)
                    .FirstOrDefault());
            if (patient == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.PatientDoesNotExist);
            return patient;
        }

        /// <summary>
        /// Submit a new patient in the system.
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        /// <param name="patientDto">Patient to submit to the system</param>
        [HttpPost]
        [Route("api/patients")]
        public UserCredentialsDto CreateNewPatient([FromBody] PatientDto patientDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientNotAllowedToSubmitNewPatient);
            EnsurePatientWithEgnNotExists(patientDto.Egn);

            var sysUser = CreateNewSysUser(UserRole.Patient);
            Execute(dataContext =>
            {
                dataContext.SysUsers.InsertOnSubmit(sysUser);
                dataContext.SubmitChanges();
            });
            var patient = CreatePatient(patientDto, sysUser);
            Execute(dataContext =>
            {
                dataContext.Patients.InsertOnSubmit(patient);
                dataContext.SubmitChanges();
            });
            return new UserCredentialsDto(sysUser);
        }

        private static Patient CreatePatient(PatientDto patientDto, SysUser sysUser)
        {
            var patient = Map<PatientDto, Patient>(patientDto);
            patient.Guid = Guid.Empty;
            patient.UserId = sysUser.Guid;
            return patient;
        }

        /// <summary>
        /// Update specific patient information
        /// Restrictions: A patient can modify only himself
        /// </summary>
        /// <param name="id">The GUID of the patient</param>
        /// <param name="patientDto">Modified patient information</param>
        [HttpPut]
        [Route("api/patients/{id:guid}")]
        public void UpdateExistingPatient(Guid id, [FromBody] PatientDto patientDto)
        {
            if (IsUserInRole(User, UserRole.Patient))
                EnsureId(User, id, Messages.PatientNotAllowedToModifyOtherPatients);
            Execute(dataContext => UpdateExistingPatientFields(id, patientDto, dataContext));
        }

        private static void UpdateExistingPatientFields(Guid id, PatientDto patientDto, PersistenceClassesDataContext dataContext)
        {
            var patient = dataContext.Patients.FirstOrDefault(p => p.Guid.Equals(id));
            if (patient == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.PatientDoesNotExist);
            if (patientDto.Name != null) patient.Name = patientDto.Name;
            if (patientDto.MiddleName != null) patient.MiddleName = patientDto.MiddleName;
            if (patientDto.FamilyName != null) patient.FamilyName = patientDto.FamilyName;
            if (patientDto.Address != null) patient.Address = patientDto.Address;
            if (patientDto.Age != 0) patient.Age = patientDto.Age;
            if (patientDto.MobilePhone != null) patient.MobilePhone = patientDto.MobilePhone;
            if (patientDto.Egn != null) patient.Egn = patientDto.Egn;
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Delete specific patient from the system
        /// Restrictions: Endpoint is accessible only for Administrators
        /// </summary>
        /// <param name="id">The GUID of the patient</param>
        [HttpDelete]
        [Route("api/patients/{id:guid}")]
        public void DeleteExistingPatient(Guid id)
        {
            EnsureInRole(User, UserRole.Admin, Messages.OnlyAdministratorCanExecute);
            Execute(dataContext => DeleteExistingPatient(id, dataContext));
        }

        private static void DeleteExistingPatient(Guid id, PersistenceClassesDataContext dataContext)
        {
            var patient = dataContext.Patients.FirstOrDefault(p => p.Guid.Equals(id));
            dataContext.Patients.DeleteOnSubmit(
                patient ?? throw GetResponseException(HttpStatusCode.NotFound, Messages.PatientDoesNotExist));
            dataContext.SysUsers.DeleteOnSubmit(patient.SysUser);
            dataContext.SubmitChanges();
        }
    }
}