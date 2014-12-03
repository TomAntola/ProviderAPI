using Domain.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Web.Common.Security;

namespace Web.Inbound.Common.MessageHandlers
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        private readonly IPrincipalFactory _principalFactory;
        private readonly ISecurityService _securityService;
        private readonly HashAlgorithm _hashAlgorithm = new SHA256Cng();

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
            var authHeader = request.Headers.Authorization;

            if (authHeader == null)
            {
                return CreateUnauthorizedResponse(request);
            }

            if (authHeader.Scheme != BASIC_AUTHENTICATION)
            {
                return CreateUnauthorizedResponse(request);
            }

            var encodedCredentials = authHeader.Parameter;

            if (encodedCredentials == null)
            {
                return CreateUnauthorizedResponse(request);
            }

            byte[] credentialBytes;

            try
            {
                credentialBytes = Convert.FromBase64String(encodedCredentials);
            }
            catch (FormatException)
            {
                return CreateUnauthorizedResponse(request);
            }

            var credentials = Encoding.ASCII.GetString(credentialBytes);
            var credentialParts = credentials.Split(AUTHORIZATION_HEADER_SEPARATOR);

            if (credentialParts.Length != 2)
            {
                return CreateUnauthorizedResponse(request);
            }

            var username = credentialParts[0].Trim();
            var password = credentialParts[1].Trim();

            var providerApiUser = _securityService.GetUser(username);

            if (providerApiUser == null)
            {
                return CreateUnauthorizedResponse(request);
            }

            var passwordHash = _securityService.HashSaltedPassword(Encoding.UTF8.GetBytes(password), providerApiUser.Salt, _hashAlgorithm);

            if (!_securityService.ValidPassword(passwordHash, providerApiUser.Password))
            {
                return CreateUnauthorizedResponse(request);
            }

            IIdentity identity = _principalFactory.CreateIdentity(username, BASIC_AUTHENTICATION);
            IPrincipal principal = _principalFactory.CreatePrincipal(identity);

            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                HttpContext.Current.User = principal;
            }

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> CreateUnauthorizedResponse(HttpRequestMessage request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.Add(CHALLENGE_AUTHENTICATION_HEADER_NAME, BASIC_AUTHENTICATION);

            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(response);

            return taskCompletionSource.Task;
        }
    }
}