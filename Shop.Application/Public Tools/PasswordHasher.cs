using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Public_Tools
{
  public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var saltByte = new byte[16];
            using var rng=RandomNumberGenerator.Create();
            rng.GetBytes(saltByte);

            var saltText = Convert.ToBase64String(saltByte);
            var combined = Encoding.UTF8.GetBytes(saltText + password);
            using var sha256=SHA256.Create();
            var hashByte = sha256.ComputeHash(combined);
            var hashPassword = Convert.ToBase64String(hashByte);
            return $"{hashPassword}:{hashByte}";
        }

        public static bool verifyPassword(string password, string sortedhashPassword)
        {
            var parts = sortedhashPassword.Split(':');
            if (parts.Length != 2)
                return false;
            var saltText = parts[0];
            var sortedHas = parts[1];

            var combined = Encoding.UTF8.GetBytes(password + saltText);
            using var sha256=SHA256.Create();
            var hashByte = sha256.ComputeHash(combined);
            var hashPassword = Convert.ToBase64String(hashByte);
            return sortedHas == hashPassword;

        }


    }
}
