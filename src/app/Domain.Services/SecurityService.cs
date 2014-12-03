using DAL.Repositories;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Domain.Services
{
    public class SecurityService : ISecurityService
    {
        private const int SALT_BYTE_SIZE = 64;
        private const int MINIMUM_SALT_LENGTH = 1;
        private const int MINIMUM_PASSWORD_LENGTH = 1;

        private readonly IProviderApiUserRepository _providerApiUserRepository;

        public SecurityService(IProviderApiUserRepository providerApiUserRepository)
        {
            _providerApiUserRepository = providerApiUserRepository;
        }

        public ProviderApiUser GetUser(string username)
        {
            return _providerApiUserRepository.GetUser(username);
        }

        public static byte[] CreateSalt()
        {
            // Generate a new random salt.
            var csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);
            return salt;
        }

        public byte[] HashSaltedPassword(byte[] Password, byte[] Salt, HashAlgorithm HashAlgorithm)
        {
            #region Parameter Validation.
            if (Password == null)
            {
                throw new ArgumentNullException("Password", "Password is required.");
            }

            if (Password.Length < MINIMUM_PASSWORD_LENGTH)
            {
                throw new ArgumentException(string.Format("Password is required to be at {0} one characters in length.", MINIMUM_PASSWORD_LENGTH));
            }

            if (Salt == null)
            {
                throw new ArgumentNullException("Salt", "Salt is required.");
            }

            if (Salt.Length < MINIMUM_SALT_LENGTH)
            {
                throw new ArgumentException(string.Format("Salt is required to be at least {0} characters in length.", MINIMUM_SALT_LENGTH));
            }

            if (HashAlgorithm == null)
            {
                throw new ArgumentNullException("HashAlgorithm", "HashAlgorithm is required.");
            }
            #endregion Parameter Validation.

            var passwordWithSalt = Password.Concat(Salt).ToArray();

            return HashAlgorithm.ComputeHash(passwordWithSalt);
        }

        public bool ValidPassword(byte[] AttemptedPassword, byte[] ActualPassword)
        {
            #region Parameter Validation.
            if (AttemptedPassword == null)
            {
                throw new ArgumentNullException("AttemptedPassword", "AttemptedPassword is required.");
            }

            if (AttemptedPassword.Length == 0)
            {
                throw new ArgumentException("AttemptedPassword is required to be at least one character in length.");
            }

            if (ActualPassword == null)
            {
                throw new ArgumentNullException("ActualPassword", "ActualPassword is required.");
            }

            if (ActualPassword.Length == 0)
            {
                throw new ArgumentException("ActualPassword is required to be at least one character in length.");
            }
            #endregion Parameter Validation.

            return AttemptedPassword.SequenceEqual(ActualPassword);
        }

        public void AddEditUser(ProviderApiUser providerApiUser)
        {
            _providerApiUserRepository.AddEditUser(providerApiUser);
        }
    }
}
