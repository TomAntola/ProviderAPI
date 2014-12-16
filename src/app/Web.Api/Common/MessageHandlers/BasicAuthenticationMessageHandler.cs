using Domain.Api.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Web.Api.Common.MessageHandlers
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        private readonly IPrincipalFactory _principalFactory;
        private readonly ISecurityService _securityService;
        private readonly HashAlgorithm _hashAlgorithm = new SHA256Managed();

        public const string BASIC_AUTHENTICATION = "Basic";
        public const string CHALLENGE_AUTHENTICATION_HEADER_NAME = "WWW-Authenticate";
        public const char AUTHORIZATION_HEADER_SEPARATOR = ':';

        public BasicAuthenticationMessageHandler(IPrincipalFactory principal_factory, ISecurityService securityService)
        {
            _principalFactory = principal_factory;
            _securityService = securityService;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var authHeader = request.Headers.Authorization;

                if (authHeader == null)
                {
                    return CreateUnauthorizedResponse(request, "Authorization header is missing.");
                }

                if (authHeader.Scheme != BASIC_AUTHENTICATION)
                {
                    return CreateUnauthorizedResponse(request, "Authorizaiton header mechanism must be 'Basic'.");
                }

                var encodedCredentials = authHeader.Parameter;

                if (encodedCredentials == null)
                {
                    return CreateUnauthorizedResponse(request, "Authorization header credentials are missing.");
                }

                byte[] credentialBytes;

                credentialBytes = Convert.FromBase64String(encodedCredentials);

                var credentials = Encoding.ASCII.GetString(credentialBytes);
                var credentialParts = credentials.Split(AUTHORIZATION_HEADER_SEPARATOR);

                if (credentialParts.Length != 2)
                {
                    return CreateUnauthorizedResponse(request, "Authorization header does not contain a username and a password separated by a colon. Are you missing a colon?");
                }

                var username = credentialParts[0].Trim();
                var password = credentialParts[1].Trim();

                var providerApiUser = _securityService.GetUser(username);

                if (providerApiUser == null)
                {
                    return CreateUnauthorizedResponse(request, "Username was not found.");
                }

                var passwordHash = _securityService.HashSaltedPassword(Encoding.UTF8.GetBytes(password), providerApiUser.Salt, _hashAlgorithm);

                if (!_securityService.IsValidPassword(passwordHash, providerApiUser.Password))
                {
                    return CreateUnauthorizedResponse(request, "Username was not found.");
                }

                IIdentity identity = _principalFactory.CreateIdentity(username, BASIC_AUTHENTICATION);
                IPrincipal principal = _principalFactory.CreatePrincipal(identity);

                Thread.CurrentPrincipal = principal;

                if (HttpContext.Current != null && HttpContext.Current.User != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            catch (Exception exception)
            {
                return CreateUnauthorizedResponse(request, exception.GetBaseException().Message);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> CreateUnauthorizedResponse(HttpRequestMessage request, string reason)
        {
            var response = request.CreateResponse<HttpError>(HttpStatusCode.Unauthorized, new HttpError(reason));

            response.Headers.Add(CHALLENGE_AUTHENTICATION_HEADER_NAME, BASIC_AUTHENTICATION);

            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(response);

            return taskCompletionSource.Task;
        }
    }
}