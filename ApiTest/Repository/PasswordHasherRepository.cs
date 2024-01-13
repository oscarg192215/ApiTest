using ApiTest.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace ApiTest.Repository
{
    public class PasswordHasherRepository : IPasswordHasherRepository
    {
        private const int SaltSize = 32; // Tamaño del salt en bytes
        private const int Iterations = 10000; // Número de iteraciones

        public string HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    byte[] hash = pbkdf2.GetBytes(32); // Tamaño del hash en bytes
                    byte[] hashBytes = new byte[SaltSize + 32]; // Salt + Hash

                    Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
                    Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, 32);

                    return Convert.ToBase64String(hashBytes);
                }
            }
        }

        public bool VerifyPassword(string hashedPassword, string passwordToCheck)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];

            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordToCheck, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashToCheck = pbkdf2.GetBytes(32);

                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + SaltSize] != hashToCheck[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
