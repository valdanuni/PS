using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019
{
    class NewCreatedUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public NewCreatedUser(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

        }
        public NewCreatedUser()
        {

        }

       
    }
    
}
