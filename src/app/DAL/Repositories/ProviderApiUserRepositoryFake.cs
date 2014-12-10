using Domain;
using System;

namespace DAL.Repositories
{
    public class ProviderApiUserRepositoryFake : IProviderApiUserRepository
    {
        public ProviderApiUser GetUser(string Username)
        {
            var password = new byte[] { 188, 79, 82, 121, 1, 126, 36, 112, 12, 93, 48, 26, 152, 52, 217, 131, 37, 222, 76, 24, 45, 118, 151, 117, 63, 24, 229, 248, 187, 98, 84, 64 };

            return ProviderApiUser.Create("Test", password, new byte[] { 1 });
        }

        public void AddEditUser(ProviderApiUser providerApiUser)
        {
            throw new NotImplementedException("ProviderApiUserRepositoryStub has not implemented the AddEditUser method.");
        }
    }
}
