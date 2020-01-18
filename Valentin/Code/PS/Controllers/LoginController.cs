using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using PS.Models;
using PS.Persistence;

namespace PS.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// Authenticate and receive metadata - GUID and role.
        /// </summary>
        [HttpPost]
        [Route("api/login")]
        public UserMetadataDto Login()
        {
            var userMetadataDto = new UserMetadataDto
            {
                Guid = DataContext.Get(dataContext =>
                {
                    var sysUser = dataContext.SysUsers.First(user => user.Username.Equals(User.Identity.Name));
                    if (sysUser.Patients.FirstOrDefault() != null) return sysUser.Patients.First().Guid;
                    if (sysUser.Doctors.FirstOrDefault() != null) return sysUser.Doctors.First().Guid;
                    if (sysUser.Hospitals.FirstOrDefault() != null) return sysUser.Hospitals.First().Guid;
                    return Guid.Empty;
                }),
                UserRole = GetUserRole().ToString()
            };
            return userMetadataDto;
        }

        private UserRole GetUserRole()
        {
            if (User.IsInRole(UserRole.Patient.ToString()))
                return UserRole.Patient;
            if (User.IsInRole(UserRole.Doctor.ToString()))
                return UserRole.Doctor;
            if (User.IsInRole(UserRole.Hospital.ToString()))
                return UserRole.Hospital;
            if (!User.IsInRole(UserRole.Admin.ToString()))
                throw ControllerUtils.GetResponseException(HttpStatusCode.Unauthorized,
                    "Unknown user role! Cannot proceed with login");
            return UserRole.Admin;
        }
    }
}