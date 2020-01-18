using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web.Http;
using PS.Models;
using PS.Persistence;

namespace PS.Controllers
{
    public static class ControllerUtils
    {
        public static HttpResponseException GetResponseException(HttpStatusCode statusCode, string message)
        {
            var responseMessage = new HttpResponseMessage(statusCode)
            { Content = new ObjectContent(message.GetType(), message, new JsonMediaTypeFormatter()) };
            throw new HttpResponseException(responseMessage);
        }

        public static void EnsureInRole(IPrincipal user, UserRole userRole, string messageIfNotFulfilled)
        {
            if (!IsUserInRole(user, userRole)) throw GetResponseException(HttpStatusCode.Forbidden, messageIfNotFulfilled);
        }

        public static void EnsureNotInRole(IPrincipal user, UserRole userRole, string messageIfNotFulfilled)
        {
            if (IsUserInRole(user, userRole)) throw GetResponseException(HttpStatusCode.Forbidden, messageIfNotFulfilled);
        }

        public static bool IsUserInRole(IPrincipal user, UserRole userRole)
        {
            return user.IsInRole(userRole.ToString());
        }

        public static void EnsureId(IPrincipal requestUser, Guid guid, string messageIfNotFulfilled)
        {
            var databaseGuid = DataContext.Get(GetConcreteIdForUser(requestUser));
            if (!databaseGuid.Equals(guid)) throw GetResponseException(HttpStatusCode.Unauthorized, messageIfNotFulfilled);
        }

        private static Func<PersistenceClassesDataContext, Guid> GetConcreteIdForUser(IPrincipal requestUser)
        {
            return dataContext =>
            {
                var sysUser = dataContext.SysUsers.First(user => user.Username.Equals(requestUser.Identity.Name));
                if (sysUser.Patients.Any())
                    return sysUser.Patients.ElementAt(0).Guid;
                if (sysUser.Doctors.Any())
                    return sysUser.Doctors.ElementAt(0).Guid;
                return sysUser.Hospitals.Any() ? sysUser.Hospitals.ElementAt(0).Guid : Guid.Empty;
            };
        }

        public static void EnsurePatientWithEgnNotExists(string egn)
        {
            if (DataContext.Get(dataContext => dataContext.Patients.Any(p => p.Egn.Equals(egn))))
                throw GetResponseException(HttpStatusCode.Conflict, Messages.PatientWithEgnAlreadyExists);
        }

        public static void EnsureDoctorWithEgnNotExists(string egn)
        {
            if (DataContext.Get(dataContext => dataContext.Doctors.Any(doctor => doctor.Egn.Equals(egn))))
                throw GetResponseException(HttpStatusCode.Conflict, Messages.DoctorWithEgnAlreadyExists);
        }

        public static SysUser CreateNewSysUser(UserRole userRole)
        {
            return new SysUser
            {
                Username = CreateRandomUsername(),
                Password = CreateRandomPassword(),
                CreationDate = DateTime.Now,
                RoleId = DataContext.Get(dataContext =>
                    dataContext.SysUserRoles.First(role => role.Name.Equals(userRole.ToString())).Guid)
            };
        }

        private static string CreateRandomUsername()
        {
            var randomUsername = RandomSecureString();
            return DataContext.Get(dataContext => dataContext.SysUsers.Any(user => user.Username.Equals(randomUsername)))
                ? CreateRandomUsername()
                : randomUsername;
        }

        private static string CreateRandomPassword()
        {
            var randomPassword = RandomSecureString();
            return DataContext.Get(dataContext => dataContext.SysUsers.Any(user => user.Password.Equals(randomPassword)))
                ? CreateRandomPassword()
                : randomPassword;
        }

        private static string RandomSecureString()
        {
            var length = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder();
            using (var rng = new RNGCryptoServiceProvider())
            {
                var uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    var num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
    }
}