using DAL.Repositories;
using Domain;
using Services.Security;
using System;
using System.Security.Cryptography;
using System.Text;

namespace LocalTools
{
    class ProviderApiUserManager
    {
        static void Main(string[] args)
        {
            string option = string.Empty;

            try
            {
                var _providerApiUserRepository = new ProviderApiUserRepository();
                var _securityService = new SecurityService(_providerApiUserRepository);

                option = DisplayMenu();

                switch (option)
                {
                    case "A":
                        AddUser();
                        return;
                    case "Q":
                        return;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(exception.GetBaseException().Message);
            }
            finally
            {
                if (option != "Q")
                {
                    Console.Write("\nHit any key to exit.");
                    Console.Read();
                }
            }
        }

        static string DisplayMenu()
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.WriteLine("\n\nWhat would you like to do?");
                Console.WriteLine("Enter an 'A' to add/modify a user.");
                Console.WriteLine("Enter an 'Q' to exit.");
                Console.Write("Please type the letter of your option: ");
                cki = Console.ReadKey();
            } while (!(cki.Key == ConsoleKey.A || cki.Key == ConsoleKey.E || cki.Key == ConsoleKey.Q));

            return cki.Key.ToString();
        }

        static void AddUser()
        {
            var securityService = new SecurityService(new ProviderApiUserRepository());
            var _hashAlgorithm = new SHA256Managed();

            // Get username.
            Console.Write("\n\nEnter username: ");
            var username = Console.ReadLine();

            // Get password.
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            // Encode password into a byte array.
            var encodedPassword = Encoding.UTF8.GetBytes(password);

            // Create a unique salt for this user, this occurrence.
            var salt = SecurityService.CreateSalt();

            // Hash the encoded user's password.  The hashing algorithm needs to match the one used in the BasicAuthenticationMessageHandler.
            var hashedSaltedPassword = securityService.HashSaltedPassword(encodedPassword, salt, _hashAlgorithm);

            // Create the domain provider api user.
            var providerApiUser = ProviderApiUser.Create(username, hashedSaltedPassword, salt);

            // Persist the user.
            securityService.AddEditUser(providerApiUser);

            Console.WriteLine("\nUser added/modified successfully.");
        }
    }
}
