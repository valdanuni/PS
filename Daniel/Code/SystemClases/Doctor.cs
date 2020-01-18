using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019
{
    public class Doctor:Person
    {
        public string Specialization { set; get; }
        public Doctor()
        {

        }

        public Doctor(string guid) : base(guid, null, null, null, 0, null, null,null)
        {

        }

        public Doctor(string guid, string firstName, string secondName, string lastName, int age, string egn, string address, string mobilePhone,string specialization) : base(guid, firstName, secondName, lastName, age, egn, address, mobilePhone)
        {
            this.Specialization = specialization;
        }
        public Doctor(string firstName, string secondName, string lastName, int age, string egn, string address, string mobilePhone, string specialization) : base(firstName, secondName, lastName, age, egn, address, mobilePhone)
        {
            this.Specialization = specialization;
        }
    }
}
