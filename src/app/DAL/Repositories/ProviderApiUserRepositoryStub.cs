using DAL.Entities;

namespace DAL.Repositories
{
    public class ProviderApiUserRepositoryStub : IProviderApiUserRepository
    {
        public ProviderApiUser GetUser(string Username)
        {
            return new ProviderApiUser
            {
                Username = "Test",
                Password = new byte[] { 188, 79, 82, 121, 1, 126, 36, 112, 12, 93, 48, 26, 152, 52, 217, 131, 37, 222, 76, 24, 45, 118, 151, 117, 63, 24, 229, 248, 187, 98, 84, 64 },
                Salt = new byte[] { 1 }
            };
        }
    }
}
