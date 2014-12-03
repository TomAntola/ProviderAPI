using DAL.Entities;

namespace DAL.Repositories
{
    public interface IProviderApiUserRepository
    {
        ProviderApiUser GetUser(string Username);
    }
}
