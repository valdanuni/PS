using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using PS.Persistence;

namespace PS.Filters
{
    public class BasicAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authorization = context.Request.Headers.Authorization;
            if (authorization != null &&
                string.Equals(authorization.Scheme, "Basic", StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrEmpty(authorization.Parameter))
            {
                if (ExtractUserNameAndPassword(authorization.Parameter, out var userName, out var password))
                    DataContext.Execute(dataContext =>
                    {
                        var user = dataContext.SysUsers.FirstOrDefault(sysUser => sysUser.Username.Equals(userName));
                        if (user != null && user.Password.Equals(password))
                        {
                            var identity = new GenericIdentity(userName, "Basic");
                            context.Principal = new GenericPrincipal(identity, new[] { user.SysUserRole.Name });
                        }
                        else
                        {
                            context.ErrorResult =
                                new AuthenticationFailureResult("Invalid username or password", context.Request);
                        }
                    });
                else
                    context.ErrorResult = new AuthenticationFailureResult("Unable to extract authentication details from request",
                        context.Request);
            }
            else
            {
                context.ErrorResult =
                    new AuthenticationFailureResult("Authentication details are missing from request", context.Request);
            }

            return Task.FromResult(0);
        }

        private static bool ExtractUserNameAndPassword(string authorizationParameter, out string userName, out string password)
        {
            userName = null;
            password = null;
            byte[] credentialBytes;
            try
            {
                credentialBytes = Convert.FromBase64String(authorizationParameter);
            }
            catch (FormatException)
            {
                return false;
            }

            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var decodedCredentials = encoding.GetString(credentialBytes);
            if (string.IsNullOrEmpty(decodedCredentials)) return false;

            var colonIndex = decodedCredentials.IndexOf(':');
            if (colonIndex == -1) return false;

            userName = decodedCredentials.Substring(0, colonIndex);
            password = decodedCredentials.Substring(colonIndex + 1);
            return true;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var host = context.Request.RequestUri.DnsSafeHost;
            context.Result =
                new AddChallengeOnUnauthorizedResult(new AuthenticationHeaderValue("Basic", "realm=\"" + host + "\""),
                    context.Result);
            return Task.CompletedTask;
        }

        public class AddChallengeOnUnauthorizedResult : IHttpActionResult
        {
            private readonly AuthenticationHeaderValue _challenge;
            private readonly IHttpActionResult _innerResult;

            public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
            {
                _challenge = challenge;
                _innerResult = innerResult;
            }

            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = await _innerResult.ExecuteAsync(cancellationToken);
                if (response.StatusCode == HttpStatusCode.Unauthorized &&
                    response.Headers.WwwAuthenticate.All(h => h.Scheme != _challenge.Scheme))
                    response.Headers.WwwAuthenticate.Add(_challenge);
                return response;
            }
        }
    }
}