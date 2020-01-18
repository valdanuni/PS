using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019
{
    public class Patient : Person
    {
        public Patient()
        {
        }
        public Patient(string guid, string firstName, string secondName, string lastName, int age, string egn, string address, string mobilePhone) : base(guid, firstName, secondName, lastName, age, egn, address, mobilePhone)
        {


        }
        public Patient(string firstName, string secondName, string lastName, int age, string egn, string address, string mobilePhone) : base(firstName, secondName, lastName, age, egn, address, mobilePhone)
        {


        }
        public Patient(string guid) : base(guid, null, null,null, 0, null, null, null)
        {

        }
    }
}
