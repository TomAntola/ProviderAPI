using Common.HttpStatusCodeExceptions;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class ProviderApiUserRepository : IProviderApiUserRepository
    {
        private const string GET_VEHICLE = "execute dbo.GetProviderApiUser '{0}';";

        public ProviderApiUser GetUser(string username)
        {
            ProviderApiUser providerApiUser = null;

            using (var context = new ProviderContext())
            {
                providerApiUser = context.Database.SqlQuery<ProviderApiUser>(string.Format(GET_VEHICLE, username)).FirstOrDefault();
            }

            if (providerApiUser == null)
            {
                throw new NotFoundException(string.Format("Provider API user was not found. Username = '{0}'.", username));
            }

            return providerApiUser;
        }
    }
}
