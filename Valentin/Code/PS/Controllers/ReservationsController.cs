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
    public class ReservationsController : ApiController
    {
        /// <summary>
        /// Retrieve all available reservations in the system
        /// </summary>
        [HttpGet]
        [Route("api/reservations")]
        public IEnumerable<HistoricalReservationDto> GetAllReservations()
        {
            if (IsUserInRole(User, UserRole.Patient))
                return Get(dataContext =>
                    dataContext.Patients.First(patient => patient.SysUser.Username.Equals(User.Identity.Name))
                        .HistoricalReservations.Select(Map<HistoricalReservation, HistoricalReservationDto>)
                        .Select(HideDoctorsEgn)
                        .ToList());
            if (IsUserInRole(User, UserRole.Doctor))
                return Get(dataContext => dataContext.Doctors.First(doctor => doctor.SysUser.Username.Equals(User.Identity.Name))
                    .HistoricalReservations.Select(Map<HistoricalReservation, HistoricalReservationDto>).ToList());

            if (IsUserInRole(User, UserRole.Hospital))
                return Get(dataContext =>
                    dataContext.Hospitals.First(hospital => hospital.SysUser.Username.Equals(User.Identity.Name))
                        .HistoricalReservations.Select(Map<HistoricalReservation, HistoricalReservationDto>).ToList());

            if (!IsUserInRole(User, UserRole.Admin))
                throw GetResponseException(HttpStatusCode.BadRequest, "Unrecognized role");
            return Get(dataContext => dataContext.HistoricalReservations
                .Select(Map<HistoricalReservation, HistoricalReservationDto>).ToList());
        }


        private HistoricalReservationDto HideDoctorsEgn(HistoricalReservationDto historicalReservation)
        {
            if (IsUserInRole(User, UserRole.Patient)) historicalReservation.Doctor.Egn = "HIDDEN";
            return historicalReservation;
        }

        /// <summary>
        /// Retrieve a specific reservation from the system
        /// </summary>
        /// <param name="id">The GUID of the reservation</param>
        [HttpGet]
        [Route("api/reservations/{id:guid}")]
        public HistoricalReservationDto GetReservation(Guid id)
        {
            var reservation = Get(dataContext => dataContext.HistoricalReservations
                .Where(historicalReservation => historicalReservation.Guid.Equals(id)).AsEnumerable()
                .Select(Map<HistoricalReservation, HistoricalReservationDto>).Select(HideDoctorsEgn).FirstOrDefault());
            if (reservation == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.ReservationDoesNotExist);
            return reservation;
        }

        /// <summary>
        /// Submit a new reservation in the system.
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        /// <param name="historicalReservationDto">Reservation details</param>
        [HttpPost]
        [Route("api/reservations")]
        public void CreateNewReservation([FromBody] HistoricalReservationDto historicalReservationDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.TalkToDoctorToCreateReservation);
            Execute(dataContext =>
            {
                var reservation =
                    Map<HistoricalReservationDto, HistoricalReservation>(historicalReservationDto);

                if (IsUserInRole(User, UserRole.Doctor))
                    if (!dataContext.SysUsers.First(user => user.Username.Equals(User.Identity.Name)).Doctors
                        .Any(doctor => doctor.Guid.Equals(reservation.DoctorId)))
                        throw GetResponseException(HttpStatusCode.Forbidden,
                            Messages.DoctorNotAllowedToPostReservationOnOtherDoctors);
                if (IsUserInRole(User, UserRole.Hospital))
                    if (!dataContext.SysUsers.First(user => user.Username.Equals(User.Identity.Name)).Hospitals
                        .Any(hospital => hospital.Guid.Equals(reservation.HospitalId)))
                        throw GetResponseException(HttpStatusCode.Forbidden,
                            Messages.HospitalNotAllowedToPostReservationOnOtherHospitals);
                if (!dataContext.Patients.Any(patient => patient.Guid.Equals(reservation.PatientId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.PatientDoesNotExist);
                if (!dataContext.Doctors.Any(doctor => doctor.Guid.Equals(reservation.DoctorId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.DoctorDoesNotExist);
                if (!dataContext.Hospitals.Any(hospital => hospital.Guid.Equals(reservation.HospitalId)))
                    throw GetResponseException(HttpStatusCode.NotFound, Messages.HospitalDoesNotExist);
                if (!dataContext.Hospitals.First(hospital => hospital.Guid.Equals(reservation.HospitalId)).HospitalDoctors
                    .Any(hospitalDoctorLink => hospitalDoctorLink.DoctorId.Equals(reservation.DoctorId)))
                    throw GetResponseException(HttpStatusCode.NotFound,
                        Messages.DoctorNotPartOfHospitalForReservations);

                reservation.Guid = Guid.Empty;
                dataContext.HistoricalReservations.InsertOnSubmit(reservation);
                dataContext.SubmitChanges();
            });
        }

        /// <summary>
        /// Update specific reservation information
        /// Restrictions: Endpoint is not accessible for patients
        /// </summary>
        /// <param name="id">The GUID of the reservation</param>
        /// <param name="historicalReservationDto">Modified reservation information</param>
        [HttpPut]
        [Route("api/reservations/{id:guid}")]
        public void UpdateReservation(Guid id, HistoricalReservationDto historicalReservationDto)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.TalkToDoctorToUpdateReservation);
            Execute(dataContext => UpdateExistingReservationFields(id, historicalReservationDto, dataContext));
        }

        private static void UpdateExistingReservationFields(Guid id, HistoricalReservationDto historicalReservationDto,
            PersistenceClassesDataContext dataContext)
        {
            var reservation = dataContext.HistoricalReservations.FirstOrDefault(r => r.Guid.Equals(id));
            if (reservation == null) throw GetResponseException(HttpStatusCode.NotFound, Messages.ReservationDoesNotExist);
            if (historicalReservationDto.ReservationTime != DateTime.MinValue) // Is assigned? (Non nullable)
                reservation.ReservationTime = historicalReservationDto.ReservationTime;
            if (historicalReservationDto.Reason != null) reservation.Reason = historicalReservationDto.Reason;
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Delete specific reservation from the system
        /// Restrictions: Endpoint is accessible only for Administrators
        /// </summary>
        /// <param name="id">The GUID of the reservation</param>
        [HttpDelete]
        [Route("api/reservations/{id:guid}")]
        public void DeleteExistingReservation(Guid id)
        {
            EnsureNotInRole(User, UserRole.Patient, Messages.TalkToDoctorToCancelReservation);
            Execute(dataContext => DeleteExistingReservation(id, dataContext));
        }

        private static void DeleteExistingReservation(Guid id, PersistenceClassesDataContext dataContext)
        {
            var reservation = dataContext.HistoricalReservations.FirstOrDefault(r => r.Guid.Equals(id));
            dataContext.HistoricalReservations.DeleteOnSubmit(
                reservation ?? throw GetResponseException(HttpStatusCode.NotFound, Messages.ReservationDoesNotExist));
            dataContext.SubmitChanges();
        }
    }
}