using PS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Models
{
    public class HospitalDto
    {
        /// <summary>
        /// Globally unique identifier for the hospital
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Name of the hospital
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mobile phone of the hospital
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 
        /// Specific address location of the hospital
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Owner of the hospital
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// GUIDs of the doctors working at the hospital
        /// </summary>
        public List<Guid> DoctorGuids { get; set; }

        public HospitalDto() { }
    }
}