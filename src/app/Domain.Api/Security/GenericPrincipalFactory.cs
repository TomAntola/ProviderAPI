using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Domain.Api.Security
{
    public class GenericPrincipalFactory : IPrincipalFactory
    {
        public GenericPrincipalFactory()
        {
        }

        public IIdentity CreateIdentity(string username, string authentication_type)
        {
            var identity = new GenericIdentity(username, authentication_type);

            return identity;
        }

        public IPrincipal CreatePrincipal(IIdentity identity)
        {
            return CreatePrincipal(identity, new List<string> { "User" });
        }

        public IPrincipal CreatePrincipal(IIdentity identity, IEnumerable<string> roles)
        {
            var role_names = new string[] { "User" };

            if (roles != null && roles.Count() > 0)
            {
                role_names = roles.ToArray();
            }

            return new GenericPrincipal(identity, role_names);
        }
    }
}
