﻿namespace DAL.Entities
{
    public class ProviderApiUser
    {
        public string Username { get; set; }

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }
    }
}