using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Models
{
    public class UserMetadataDto
    {
        /// <summary>
        /// Globally unique identifier of the user
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Role (Patient / Doctor / Hospital / Administrator)
        /// </summary>
        public string UserRole { get; set; }
    }
}