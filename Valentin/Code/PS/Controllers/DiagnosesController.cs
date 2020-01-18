using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using PS.Mapping.DTOs;
using PS.Models;
using PS.Persistence;
using static AutoMapper.Mapper;
using static PS.Controllers.ControllerUtils;
using static PS.Persistence.DataContext;

namespace PS.Controllers
{
    public class DiagnosesController : ApiController
    {
        /// <summary>
        /// Retrieve all available diagnoses in the system
        /// </summary>
        [HttpGet]
        [Route("api/diagnoses")]
        public IEnumerable<HistoricalDiagnosisDto> GetAllDiagnoses()
        {
            if (IsUserInRole(User, UserRole.Patient))
                return Get(dataContext =>
                    dataContext.Patients.First(patient => patient.SysUser.Username.Equals(User.Identity.Name)).HistoricalDiagnosis
                        .Select(Map<HistoricalDiagnosis, HistoricalDiagnosisDto>).Select(HideDoctorsEgn).ToList());
            if (IsUserInRole(User, UserRole.Doctor))
                return Get(dataContext => dataContext.Doctors.First(doctor => doctor.SysUser.Username.Equals(User.Identity.Name))
                    .HistoricalDiagnosis.Select(Map<HistoricalDiagnosis, HistoricalDiagnosisDto>).ToList());
            if (IsUserInRole(User, UserRole.Hospital))
                throw GetResponseException(HttpStatusCode.Forbidden, Messages.UnsupportedOperationForRole);

            if (!IsUserInRole(User, UserRole.Admin))
                throw GetResponseException(HttpStatusCode.BadRequest, "Unrecognized role");
            return Get(dataContext =>
                dataContext.HistoricalDiagnosis.Select(Map<HistoricalDiagnosis, HistoricalDiagnosisDto>).ToList());
        }

        private HistoricalDiagnosisDto HideDoctorsEgn(HistoricalDiagnosisDto historicalDiagnosis)
        {
            if (IsUserInRole(User, UserRole.Patient)) historicalDiagnosis.Doctor.Egn = "HIDDEN";
            return historicalDiagnosis;
        }

        /// <summary>
        /// Retrieve a specific diagnosis from the system
        /// </summary>
        /// <param name="id">The GUID of the diagnosis</param>
        [HttpGet]
        [Route("api/diagnoses/{id:guid}")]
        public HistoricalDiagnosisDto GetDiagnosis(Guid id)
        {
            var diagnosis = Get(dataContext => dataContext.HistoricalDiagnosis
                .Where(historicalDiagnosis => historicalDiagnosis.Guid.Equals(id)).AsEnumerable()
                .Select(Map<HistoricalDiagnosis, HistoricalDiagnosisDto>).Select(HideDoctorsEgn).FirstOrDefault());
            if (diagnosis == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.DiagnosisDoesNotExist);
            return diagnosis;
        }

        /// <summary>
        /// Submit a new diagnosis in the system.
        /// Restrictions: Endpoint is not accessible for patients / hospitals, only for doctors
        /// </summary>
        /// <param name="historicalDiagnosisDto">Diagnosis details</param>
        [HttpPost]
        [Route("api/diagnoses")]
        public void CreateNewDiagnosis([FromBody] HistoricalDiagnosisDto historicalDiagnosisDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientCannotCreateDiagnoses);
            Execute(dataContext =>
            {
                var diagnosis =
                    Map<HistoricalDiagnosisDto, HistoricalDiagnosis>(historicalDiagnosisDto);

                if (IsUserInRole(User, UserRole.Doctor))
                    if (!dataContext.SysUsers.First(user => user.Username.Equals(User.Identity.Name)).Doctors
                        .Any(doctor => doctor.Guid.Equals(diagnosis.DoctorId)))
                        throw GetResponseException(HttpStatusCode.Forbidden,
                            Messages.DoctorNotAllowedToPostDiagnosisOnOtherDoctors);
                if (!dataContext.Patients.Any(patient => patient.Guid.Equals(diagnosis.PatientId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.PatientDoesNotExist);
                if (!dataContext.Doctors.Any(doctor => doctor.Guid.Equals(diagnosis.DoctorId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);

                diagnosis.Guid = Guid.Empty;
                dataContext.HistoricalDiagnosis.InsertOnSubmit(diagnosis);
                dataContext.SubmitChanges();
            });
        }

        /// <summary>
        /// Update specific diagnosis information
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        /// <param name="id">The GUID of the diagnosis</param>
        /// <param name="historicalDiagnosisDto">Modified diagnosis information</param>
        [HttpPut]
        [Route("api/diagnoses/{id:guid}")]
        public void UpdateDiagnosis(Guid id, HistoricalDiagnosisDto historicalDiagnosisDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.UnsupportedOperationForRole);
            Execute(dataContext => UpdateExistingDiagnosisFields(id, historicalDiagnosisDto, dataContext));
        }

        private static void UpdateExistingDiagnosisFields(Guid id, HistoricalDiagnosisDto historicalDiagnosisDto,
            PersistenceClassesDataContext dataContext)
        {
            var diagnosis = dataContext.HistoricalDiagnosis.FirstOrDefault(r => r.Guid.Equals(id));
            if (diagnosis == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.DiagnosisDoesNotExist);
            if (historicalDiagnosisDto.DiagnosisDescription != null)
                diagnosis.SicknessDescription = historicalDiagnosisDto.DiagnosisDescription;
            if (historicalDiagnosisDto.DiagnosisTime != DateTime.MinValue)
                diagnosis.DiagnosisTime = historicalDiagnosisDto.DiagnosisTime;
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Delete specific diagnosis from the system
        /// Restrictions: Endpoint is accessible only for Administrators
        /// </summary>
        /// <param name="id">The GUID of the diagnosis</param>
        [HttpDelete]
        [Route("api/diagnoses/{id:guid}")]
        public void DeleteExistingDiagnosis(Guid id)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.UnsupportedOperationForRole);
            Execute(dataContext => DeleteExistingDiagnosis(id, dataContext));
        }

        private static void DeleteExistingDiagnosis(Guid id, PersistenceClassesDataContext dataContext)
        {
            var diagnosis = dataContext.HistoricalDiagnosis.FirstOrDefault(v => v.Guid.Equals(id));
            dataContext.HistoricalDiagnosis.DeleteOnSubmit(
                diagnosis ?? throw GetResponseException(HttpStatusCode.NotFound, Messages.VisitDoesNotExist));
            dataContext.SubmitChanges();
        }
    }
}