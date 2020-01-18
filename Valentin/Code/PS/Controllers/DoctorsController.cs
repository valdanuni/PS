using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using PS.Mapping.DTOs;
using PS.Models;
using PS.Persistence;
using static PS.Controllers.ControllerUtils;
using static PS.Persistence.DataContext;

namespace PS.Controllers
{
    public class DoctorsController : ApiController
    {
        /// <summary>
        ///     Retrieve all available doctors in the system
        /// </summary>
        [HttpGet]
        [Route("api/doctors")]
        public IEnumerable<DoctorDto> GetAllDoctors()
        {
            return Get(dataContext => dataContext.Doctors.Select(Mapper.Map<Doctor, DoctorDto>).ToList());
        }

        /// <summary>
        ///     Retrieve a specific doctor from the system.
        ///     Restrictions: Patients will not observe EGN of the doctors
        /// </summary>
        /// <param name="id">The GUID of the doctor</param>
        [HttpGet]
        [Route("api/doctors/{id:guid}")]
        public DoctorDto GetDoctor(Guid id)
        {
            var doctor = Get(dataContext =>
                dataContext.Doctors.Where(p => p.Guid.Equals(id))
                    .AsEnumerable()
                    .Select(Mapper.Map<Doctor, DoctorDto>)
                    .Select(HideSensitiveInformationIfNeeded)
                    .FirstOrDefault());
            if (doctor == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);
            return doctor;
        }

        private DoctorDto HideSensitiveInformationIfNeeded(DoctorDto doctorDto)
        {
            if (IsUserInRole(User, UserRole.Patient)) doctorDto.Egn = "HIDDEN";
            return doctorDto;
        }

        /// <summary>
        ///     Submit a new doctor in the system.
        ///     Restrictions: Endpoint is accessible only for hospitals and administrators
        /// </summary>
        /// <param name="doctorDto">Doctor to submit to the system</param>
        [HttpPost]
        [Route("api/doctors")]
        public UserCredentialsDto CreateNewDoctor([FromBody] DoctorDto doctorDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientNotAllowedToSubmitNewPatient);
            EnsureNotInRole(User, UserRole.Doctor, Messages.DoctorNotAllowedToSubmitNewDoctor);
            EnsureDoctorWithEgnNotExists(doctorDto.Egn);

            var sysUser = CreateNewSysUser(UserRole.Doctor);
            Execute(dataContext =>
            {
                dataContext.SysUsers.InsertOnSubmit(sysUser);
                dataContext.SubmitChanges();
            });
            var doctor = CreateDoctor(doctorDto, sysUser);
            Execute(dataContext =>
            {
                dataContext.Doctors.InsertOnSubmit(doctor);
                dataContext.SubmitChanges();
            });
            return new UserCredentialsDto(sysUser);
        }

        private static Doctor CreateDoctor(DoctorDto doctorDto, SysUser sysUser)
        {
            var doctor = Mapper.Map<DoctorDto, Doctor>(doctorDto);
            doctor.Guid = Guid.Empty;
            doctor.UserId = sysUser.Guid;
            return doctor;
        }

        /// <summary>
        ///     Update specific doctor information
        ///     Restrictions: Endpoint is not accessible for patients and a doctor can modify only himself
        /// </summary>
        /// <param name="id">The GUID of the doctor</param>
        /// <param name="doctorDto">Modified doctor information</param>
        [HttpPut]
        [Route("api/doctors/{id:guid}")]
        public void UpdateExistingDoctor(Guid id, [FromBody] DoctorDto doctorDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientNotAllowedToExecute);
            if (IsUserInRole(User, UserRole.Doctor))
                EnsureId(User, id, Messages.DoctorNotAllowedToModifyOtherDoctors);
            Execute(dataContext => UpdateExistingDoctorFields(id, doctorDto, dataContext));
        }

        private static void UpdateExistingDoctorFields(Guid id, DoctorDto doctorDto, PersistenceClassesDataContext dataContext)
        {
            var doctor = dataContext.Doctors.FirstOrDefault(p => p.Guid.Equals(id));
            if (doctor == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);
            if (doctorDto.Name != null) doctor.Name = doctorDto.Name;
            if (doctorDto.MiddleName != null) doctor.MiddleName = doctorDto.MiddleName;
            if (doctorDto.FamilyName != null) doctor.FamilyName = doctorDto.FamilyName;
            if (doctorDto.Address != null) doctor.Address = doctorDto.Address;
            if (doctorDto.MobilePhone != null) doctor.MobilePhone = doctorDto.MobilePhone;
            if (doctorDto.Egn != null) doctor.Egn = doctorDto.Egn;
            dataContext.SubmitChanges();
        }

        /// <summary>
        ///     Delete specific doctor from the system
        ///     Restrictions: Endpoint is accessible only for Administrators
        /// </summary>
        /// <param name="id">The GUID of the doctor</param>
        [HttpDelete]
        [Route("api/doctors/{id:guid}")]
        public void DeleteExistingDoctor(Guid id)
        {
            EnsureInRole(User, UserRole.Admin, Messages.OnlyAdministratorCanExecute);
            Execute(dataContext => DeleteExistingDoctor(id, dataContext));
        }

        private static void DeleteExistingDoctor(Guid id, PersistenceClassesDataContext dataContext)
        {
            var doctor = dataContext.Doctors.FirstOrDefault(databaseDoctor => databaseDoctor.Guid.Equals(id));
            if (doctor == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);
            dataContext.SysUsers.DeleteOnSubmit(doctor.SysUser);
            dataContext.Doctors.DeleteOnSubmit(doctor);
            dataContext.SubmitChanges();
        }
    }
}