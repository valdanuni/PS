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
    public class VisitsController : ApiController
    {
        /// <summary>
        /// Retrieve all available hospital visits in the system
        /// </summary>
        [HttpGet]
        [Route("api/visits")]
        public IEnumerable<HistoricalVisitDto> GetAllVisits()
        {
            if (IsUserInRole(User, UserRole.Patient))
                return Get(dataContext =>
                    dataContext.Patients.First(patient => patient.SysUser.Username.Equals(User.Identity.Name)).HistoricalVisits
                        .Select(Map<HistoricalVisit, HistoricalVisitDto>).Select(HideDoctorsEgn).ToList());
            if (IsUserInRole(User, UserRole.Doctor))
                return Get(dataContext => dataContext.Doctors.First(doctor => doctor.SysUser.Username.Equals(User.Identity.Name))
                    .HistoricalVisits.Select(Map<HistoricalVisit, HistoricalVisitDto>).ToList());
            if (IsUserInRole(User, UserRole.Hospital))
                return Get(dataContext =>
                        dataContext.Hospitals.First(hospital => hospital.SysUser.Username.Equals(User.Identity.Name))
                    .HistoricalVisits.Select(Map<HistoricalVisit, HistoricalVisitDto>).ToList());

            if (!IsUserInRole(User, UserRole.Admin))
                throw GetResponseException(HttpStatusCode.BadRequest, "Unrecognized role");
            return Get(dataContext => dataContext.HistoricalVisits.Select(Map<HistoricalVisit, HistoricalVisitDto>).ToList());
        }

        private HistoricalVisitDto HideDoctorsEgn(HistoricalVisitDto historicalVisit)
        {
            if (IsUserInRole(User, UserRole.Patient)) historicalVisit.Doctor.Egn = "HIDDEN";
            return historicalVisit;
        }

        /// <summary>
        /// Retrieve a specific hospital visit from the system
        /// </summary>
        /// <param name="id">The GUID of the visit</param>
        [HttpGet]
        [Route("api/visits/{id:guid}")]
        public HistoricalVisitDto GetVisit(Guid id)
        {
            var visit = Get(dataContext => dataContext.HistoricalVisits
                .Where(historicalVisit => historicalVisit.Guid.Equals(id)).AsEnumerable()
                .Select(Map<HistoricalVisit, HistoricalVisitDto>).Select(HideDoctorsEgn).FirstOrDefault());
            if (visit == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.VisitDoesNotExist);
            return visit;
        }

        /// <summary>
        /// Submit a new visit in the system.
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        /// <param name="historicalVisitDto">Visitation details</param>
        [HttpPost]
        [Route("api/visits")]
        public void CreateNewVisit([FromBody] HistoricalVisitDto historicalVisitDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientCannotCreateVisit);
            Execute(dataContext =>
            {
                var visit =
                    Map<HistoricalVisitDto, HistoricalVisit>(historicalVisitDto);

                if (IsUserInRole(User, UserRole.Doctor))
                    if (!dataContext.SysUsers.First(user => user.Username.Equals(User.Identity.Name)).Doctors
                        .Any(doctor => doctor.Guid.Equals(visit.DoctorId)))
                        throw GetResponseException(HttpStatusCode.Forbidden,
                            Messages.DoctorNotAllowedToPostVisitOnOtherDoctors);
                if (IsUserInRole(User, UserRole.Hospital))
                    if (!dataContext.SysUsers.First(user => user.Username.Equals(User.Identity.Name)).Hospitals
                        .Any(hospital => hospital.Guid.Equals(visit.HospitalId)))
                        throw GetResponseException(HttpStatusCode.Forbidden,
                            Messages.HospitalNotAllowedToPostVisitationOnOtherHospitals);
                if (!dataContext.Patients.Any(patient => patient.Guid.Equals(visit.PatientId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.PatientDoesNotExist);
                if (!dataContext.Doctors.Any(doctor => doctor.Guid.Equals(visit.DoctorId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);
                if (!dataContext.Hospitals.Any(hospital => hospital.Guid.Equals(visit.HospitalId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.HospitalDoesNotExist);
                if (!dataContext.Hospitals.First(hospital => hospital.Guid.Equals(visit.HospitalId)).HospitalDoctors
                    .Any(hospitalDoctorLink => hospitalDoctorLink.DoctorId.Equals(visit.DoctorId)))
                    throw GetResponseException(HttpStatusCode.NotFound,
                        Messages.DoctorNotPartOfHospitalForVisitation);

                visit.Guid = Guid.Empty;
                dataContext.HistoricalVisits.InsertOnSubmit(visit);
                dataContext.SubmitChanges();
            });
        }

        /// <summary>
        /// Update specific hospital visit information
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        /// <param name="id">The GUID of the visitation</param>
        /// <param name="historicalVisitDto">Modified hospital visit information</param>
        [HttpPut]
        [Route("api/visits/{id:guid}")]
        public void UpdateVisit(Guid id, HistoricalVisitDto historicalVisitDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientCannotModifyVisitation);
            Execute(dataContext => UpdateExistingVisitFields(id, historicalVisitDto, dataContext));
        }

        private static void UpdateExistingVisitFields(Guid id, HistoricalVisitDto historicalVisitDto,
            PersistenceClassesDataContext dataContext)
        {
            var visit = dataContext.HistoricalVisits.FirstOrDefault(r => r.Guid.Equals(id));
            if (visit == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.VisitDoesNotExist);
            if (historicalVisitDto.VisitTime != DateTime.MinValue)
                visit.VisitTime = historicalVisitDto.VisitTime;
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Delete specific hospital visit from the system
        /// Restrictions: Endpoint is accessible only for Administrators
        /// </summary>
        /// <param name="id">The GUID of the hospital visit</param>
        [HttpDelete]
        [Route("api/visits/{id:guid}")]
        public void DeleteExistingVisit(Guid id)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.PatientCannotModifyVisitation);
            Execute(dataContext => DeleteExistingVisit(id, dataContext));
        }

        private static void DeleteExistingVisit(Guid id, PersistenceClassesDataContext dataContext)
        {
            var visit = dataContext.HistoricalVisits.FirstOrDefault(v => v.Guid.Equals(id));
            dataContext.HistoricalVisits.DeleteOnSubmit(
                visit ?? throw GetResponseException(HttpStatusCode.NotFound, Messages.VisitDoesNotExist));
            dataContext.SubmitChanges();
        }
    }
}