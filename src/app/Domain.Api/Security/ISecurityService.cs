using System.Security.Cryptography;

namespace Domain.Api.Security
{
    public interface ISecurityService
    {
        ProviderApiUser GetUser(string username);

        byte[] HashSaltedPassword(byte[] Password, byte[] Salt, HashAlgorithm HashAlgorithm);

        bool IsValidPassword(byte[] AttemptedPassword, byte[] ActualPassword);

        void AddEditUser(ProviderApiUser providerApiUser);
    }
}
