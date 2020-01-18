using PS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Models
{
    public class UserCredentialsDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserCredentialsDto(SysUser sysUser)
        {
            Username = sysUser.Username;
            Password = sysUser.Password;
        }
    }
}