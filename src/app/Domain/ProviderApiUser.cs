namespace Domain
{
    public class ProviderApiUser
    {
        public string Username { get; private set; }

        public byte[] Password { get; private set; }

        public byte[] Salt { get; private set; }

        public static ProviderApiUser Create (string username, byte[] password, byte[] salt)
        {
            return new ProviderApiUser
            {
                Username = username,
                Password = password,
                Salt = salt
            };
        }
    }
}
