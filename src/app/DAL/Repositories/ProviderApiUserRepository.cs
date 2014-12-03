using Common.HttpStatusCodeExceptions;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class ProviderApiUserRepository : IProviderApiUserRepository
    {
        private const string GET_USER = "execute dbo.GetProviderApiUser '{0}';";
        private const string ADD_EDIT_USER = "execute dbo.AddEditProviderApiUser @Username, @Password, @Salt;";

        public ProviderApiUser GetUser(string username)
        {
            DAL.Entities.ProviderApiUser providerApiUser = null;

            using (var context = new ProviderContext())
            {
                providerApiUser = context.Database.SqlQuery<DAL.Entities.ProviderApiUser>(string.Format(GET_USER, username)).FirstOrDefault();
            }

            if (providerApiUser == null)
            {
                throw new NotFoundException(string.Format("Provider API user was not found. Username = '{0}'.", username));
            }

            return ProviderApiUser.Create(providerApiUser.Username, providerApiUser.Password, providerApiUser.Salt);
        }

        public void AddEditUser(ProviderApiUser providerApiUser)
        {
            using (var context = new ProviderContext())
            {
               var usernameParm = new SqlParameter("Username", providerApiUser.Username);
               var passwordParm = new SqlParameter("Password", providerApiUser.Password);
               var saltParm = new SqlParameter("Salt", providerApiUser.Salt);

                context.Database.ExecuteSqlCommand(ADD_EDIT_USER, usernameParm, passwordParm, saltParm);
            }
        }
    }
}
