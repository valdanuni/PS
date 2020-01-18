using PS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Mapping.DTOs
{
    public class HistoricalReservationDto
    {
        /// <summary>
        /// Globally unique identifier for the reservation
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// The patient who requested the reservation
        /// </summary>
        public PatientDto Patient { get; set; }
        /// <summary>
        /// The doctor who is to handle the reservation
        /// </summary>
        public DoctorDto Doctor { get; set; }
        /// <summary>
        /// The hospital which is to be visited by the patient
        /// </summary>
        public HospitalDto Hospital { get; set; }
        /// <summary>
        /// Specific time of the reservation
        /// </summary>
        public DateTime ReservationTime { get; set; }
        /// <summary>
        /// Needs description of the patient
        /// </summary>
        public string Reason { get; set; }
        public HistoricalReservationDto() { }
    }
}