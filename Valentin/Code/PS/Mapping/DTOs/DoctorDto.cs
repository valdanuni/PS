using System;

namespace PS.Mapping.DTOs
{
    public class DoctorDto
    {
        /// <summary>
        /// Globally unique identifier for the doctor
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// First name of the doctor
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Middle name of the doctor
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Family name of the doctor
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// Mobile phone of the doctor
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Personal Identification number
        /// </summary>
        public string Egn { get; set; }
        /// <summary>
        /// Specific field of expertise
        /// </summary>
        public string Specialization { get; set; }

        public DoctorDto() { }
    }
}