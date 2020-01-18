using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PS_Hospital_System_Project_2019
{
  public abstract class Person
    {
        [ScriptIgnore]
        public string Guid { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public int Age { get; set; }
        public string Egn { get; set; }
        
        public string Address { get; set; }
 
        public string MobilePhone { get; set; }
        [ScriptIgnore]
        public string FullName 
        { 
            get
            {
                return Name.ToString() + " " + FamilyName.ToString();
            } 
        }
        public Person()
        {

        }
       
        public Person(string guid, string firstName, string secondName, string lastName, int age,string egn,string address, string mobilePhone)
        {
            this.Guid = guid;
            this.Name = firstName;
            this.MiddleName = secondName;
            this.FamilyName = lastName;
           this.Age = age;
            this.Egn = egn; 
            this.Address = address;
            this.MobilePhone = mobilePhone;
        }

        public Person(string firstName, string secondName, string lastName, int age, string egn,string address,string mobilePhone)
        {
            this.Name = firstName;
            this.MiddleName = secondName;
            this.FamilyName = lastName;
            this.Age = age;
            this.Egn = egn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
        }


    }
}
