using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PS_Hospital_System_Project_2019
{
   public class Hospital
    {
        [ScriptIgnore]
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public Hospital()
        {

        }

        public Hospital(string hospitalName, string hospitalOwner, string address,string mobilePhone)
        {
            this.Name = hospitalName;
            this.Owner = hospitalOwner;
            this.Address = address;
            this.MobilePhone = mobilePhone;
        }
    }
}
