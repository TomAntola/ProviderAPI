using Domain;

namespace DAL.Repositories
{
    public interface IProviderApiUserRepository
    {
        ProviderApiUser GetUser(string username);

        void AddEditUser(ProviderApiUser providerApiUser);
    }
}
