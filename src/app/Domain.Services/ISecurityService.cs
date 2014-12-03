﻿using System.Security.Cryptography;

namespace Domain.Services
{
    public interface ISecurityService
    {
        ProviderApiUser GetUser(string username);

        byte[] HashSaltedPassword(byte[] Password, byte[] Salt, HashAlgorithm HashAlgorithm);

        bool ValidPassword(byte[] AttemptedPassword, byte[] ActualPassword);

        void AddEditUser(ProviderApiUser providerApiUser);
    }
}
