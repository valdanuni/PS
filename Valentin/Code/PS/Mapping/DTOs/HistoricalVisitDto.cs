using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS.Models;
using PS.Persistence;

namespace PS.Mapping.DTOs
{
    public class HistoricalVisitDto
    {
        /// <summary>
        /// Globally unique identifier for the visit
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// The patient
        /// </summary>
        public PatientDto Patient { get; set; }
        /// <summary>
        /// The doctor who handled the visitation
        /// </summary>
        public DoctorDto Doctor { get; set; }
        /// <summary>
        /// The hospital at which the visitation occurred
        /// </summary>
        public HospitalDto Hospital { get; set; }
        /// <summary>
        /// Specific time the visitation occurred at
        /// </summary>
        public DateTime VisitTime { get; set; }

        public HistoricalVisitDto() { }
    }
}