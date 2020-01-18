using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using PS.Models;
using PS.Persistence;
using static PS.Controllers.ControllerUtils;
using static PS.Persistence.DataContext;

namespace PS.Controllers
{
    public class HospitalsController : ApiController
    {
        /// <summary>
        ///     Retrieve all available hospitals in the system
        /// </summary>
        [HttpGet]
        [Route("api/hospitals")]
        public IEnumerable<HospitalDto> GetAllHospitals()
        {
            return Get(dataContext =>
                dataContext.Hospitals.Select(Mapper.Map<Hospital, HospitalDto>).ToList());
        }

        /// <summary>
        ///     Retrieve a specific hospital from the system
        /// </summary>
        /// <param name="id">The GUID of the hospital</param>
        [HttpGet]
        [Route("api/hospitals/{id:guid}")]
        public HospitalDto GetHospital(Guid id)
        {
            var hospital = Get(dataContext =>
                dataContext.Hospitals.Where(h => h.Guid.Equals(id)).AsEnumerable().Select(Mapper.Map<Hospital, HospitalDto>)
                    .FirstOrDefault());
            if (hospital == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.HospitalDoesNotExist);
            return hospital;
        }

        /// <summary>
        ///     Submit a new hospital in the system.
        ///     Restrictions: Endpoint is accessible only for administrators
        /// </summary>
        /// <param name="hospitalDto">Hospital to submit to the system</param>
        [HttpPost]
        [Route("api/hospitals")]
        public UserCredentialsDto CreateNewHospital([FromBody] HospitalDto hospitalDto)
        {
            EnsureInRole(User, UserRole.Admin, Messages.OnlyAdministratorCanExecute);

            var sysUser = CreateNewSysUser(UserRole.Hospital);
            Execute(dataContext =>
            {
                dataContext.SysUsers.InsertOnSubmit(sysUser);
                dataContext.SubmitChanges();
            });
            var hospital = CreateHospital(hospitalDto, sysUser);
            Execute(dataContext =>
            {
                dataContext.Hospitals.InsertOnSubmit(hospital);
                dataContext.SubmitChanges();
            });
            return new UserCredentialsDto(sysUser);
        }

        private static Hospital CreateHospital(HospitalDto hospitalDto, SysUser sysUser)
        {
            var hospital = Mapper.Map<HospitalDto, Hospital>(hospitalDto);
            hospital.Guid = Guid.Empty;
            hospital.UserId = sysUser.Guid;
            return hospital;
        }

        /// <summary>
        ///     Update specific hospital information
        ///     Restrictions: Endpoint is accessible only for the specific hospital and administrators
        /// </summary>
        /// <param name="id">The GUID of the hospital</param>
        /// <param name="hospitalDto">Modified hospital information</param>
        [HttpPut]
        [Route("api/hospitals/{id:guid}")]
        public void UpdateExistingHospital(Guid id, [FromBody] HospitalDto hospitalDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.OnlyAdministratorCanExecute);
            EnsureNotInRole(User, UserRole.Doctor, Messages.OnlyAdministratorCanExecute);
            if (IsUserInRole(User, UserRole.Hospital))
                EnsureId(User, id, Messages.HospitalNotAllowedToModifyOtherHospitals);
            Execute(dataContext => UpdateExistingHospitalFields(id, hospitalDto, dataContext));
        }

        private static void UpdateExistingHospitalFields(Guid id, HospitalDto hospitalDto,
            PersistenceClassesDataContext dataContext)
        {
            var hospital = dataContext.Hospitals.FirstOrDefault(p => p.Guid.Equals(id));
            if (hospital == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.HospitalDoesNotExist);
            if (hospitalDto.Name != null) hospital.Name = hospitalDto.Name;
            if (hospitalDto.Owner != null) hospital.Owner = hospitalDto.Owner;
            if (hospitalDto.MobilePhone != null) hospital.MobilePhone = hospitalDto.MobilePhone;
            if (hospitalDto.Address != null) hospital.Address = hospitalDto.Address;
            dataContext.SubmitChanges();
        }

        /// <summary>
        ///     Delete specific hospital from the system
        ///     Restrictions: Endpoint is accessible only for Administrators
        /// </summary>
        /// <param name="id">The GUID of the hospital</param>
        [HttpDelete]
        [Route("api/hospitals/{id:guid}")]
        public void DeleteExistingHospital(Guid id)
        {
            EnsureInRole(User, UserRole.Admin, Messages.OnlyAdministratorCanExecute);
            Execute(dataContext => DeleteExistingHospital(id, dataContext));
        }

        private static void DeleteExistingHospital(Guid id, PersistenceClassesDataContext dataContext)
        {
            var hospital = dataContext.Hospitals.FirstOrDefault(databaseHospital => databaseHospital.Guid.Equals(id));
            if (hospital == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.HospitalDoesNotExist);
            dataContext.SysUsers.DeleteOnSubmit(hospital.SysUser);
            dataContext.Hospitals.DeleteOnSubmit(hospital);
            dataContext.SubmitChanges();
        }

        /// <summary>
        ///     Retrieve all doctors working at a specific hospital
        /// </summary>
        /// <param name="id">The GUID of the hospital</param>
        [HttpGet]
        [Route("api/hospitals/{id:guid}/doctors")]
        public List<Guid> GetHospitalDoctorIds(Guid id)
        {
            return Get(dataContext => dataContext.HospitalDoctors
                .Where(hospitalDoctorLink => hospitalDoctorLink.HospitalId.Equals(id))
                .Select(hospitalDoctorLink => hospitalDoctorLink.DoctorId).ToList());
        }

        /// <summary>
        ///     Submit a doctor as working at a specific hospital
        /// </summary>
        /// <param name="id">The GUID of the hospital</param>
        /// <param name="doctorId">The GUID of the doctor</param>
        [HttpPost]
        [Route("api/hospitals/{id:guid}/doctors")]
        public void AddDoctorToHospital(Guid id, [FromBody] Guid doctorId)
        {
            Execute(dataContext =>
            {
                if (dataContext.HospitalDoctors.Any(hospitalDoctorLink =>
                    hospitalDoctorLink.DoctorId.Equals(doctorId) && hospitalDoctorLink.HospitalId.Equals(id)))
                    throw GetResponseException(HttpStatusCode.Conflict,
                        "The following link already exists! The specified doctor is already working at that hospital");
                dataContext.HospitalDoctors.InsertOnSubmit(new HospitalDoctor
                {
                    HospitalId = id,
                    DoctorId = doctorId
                });
                dataContext.SubmitChanges();
            });
        }

        /// <summary>
        ///     Remove a doctor as working at a specific hospital
        /// </summary>
        /// <param name="id">The GUID of the hospital</param>
        /// <param name="doctorId">The GUID of the doctor</param>
        [HttpDelete]
        [Route("api/hospitals/{id:guid}/doctors/{doctorId:guid}")]
        public void DeleteDoctorFromHospital(Guid id, Guid doctorId)
        {
            Execute(dataContext =>
            {
                var hospitalDoctor = dataContext.HospitalDoctors
                    .FirstOrDefault(hospitalDoctorLink =>
                        hospitalDoctorLink.HospitalId.Equals(id) && hospitalDoctorLink.DoctorId.Equals(doctorId));
                if (hospitalDoctor == null)
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);
                dataContext.HospitalDoctors.DeleteOnSubmit(hospitalDoctor);
                dataContext.SubmitChanges();
            });
        }
    }
}