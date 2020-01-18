using System;

namespace PS.Mapping.DTOs
{
    public class PatientDto
    {
        /// <summary>
        /// Globally unique identifier for the patient
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// First name of the patient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Middle name of the patient
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Family name of the patient
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// Age of the patient
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Personal Identification number
        /// </summary>
        public string Egn { get; set; }

        /// <summary>
        /// Mobile phone of the patient
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Specific address location
        /// </summary>
        public string Address { get; set; }

        public PatientDto() { }
    }
}