using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS.Models;

namespace PS.Mapping.DTOs
{
    public class HistoricalDiagnosisDto
    {
        /// <summary>
        /// Globally unique identifier for the diagnosis
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// The patient the diagnosis has been posed for
        /// </summary>
        public PatientDto Patient { get; set; }
        /// <summary>
        /// The doctor that has made the diagnosis
        /// </summary>
        public DoctorDto Doctor { get; set; }
        /// <summary>
        /// Description of the diagnosis
        /// </summary>
        public string DiagnosisDescription { get; set; }
        /// <summary>
        /// Time of the diagnosis
        /// </summary>
        public DateTime DiagnosisTime { get; set; }
        public HistoricalDiagnosisDto() { }
    }
}