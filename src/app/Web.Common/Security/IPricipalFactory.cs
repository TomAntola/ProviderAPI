using System.Collections.Generic;
using System.Security.Principal;

namespace Web.Common.Security
{
    public interface IPrincipalFactory
    {
        IIdentity CreateIdentity(string Username, string AuthenticationType);

        IPrincipal CreatePrincipal(IIdentity Identity);

        IPrincipal CreatePrincipal(IIdentity Identity, IEnumerable<string> roles);
    }
}
