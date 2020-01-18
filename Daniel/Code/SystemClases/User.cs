using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019
{
   public class User
    {
        public string Guid { get; set; }
        public string UserRole { get; set; }
        public string AuthenticationCredentials { get; set; }
        public string Username { set; get; }
        public string Password { set; get; }
        public User(string Guid, string Role,string AuthenticationCredentials)
        {
            this.Guid = Guid;
            this.UserRole = Role;
            this.AuthenticationCredentials = AuthenticationCredentials;
        }
        public User(string Guid, string Role)
        {
            this.Guid = Guid;
            this.UserRole = Role;
        }
       
        public User()
        {

        }
    }
}
