using System;
using System.Security.Cryptography;
using System.Text;

namespace ClubAssist.Security
{
    internal static class PasswordHasher
    {
        // Genereert salt + hash
        public static (string Hash, string Salt) HashPassword(string password)
        {
            // Maak willekeurige salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            // Combineer wachtwoord + salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32); // 256-bit hash

            // Converteer naar base64 voor opslag in DB
            string salt = Convert.ToBase64String(saltBytes);
            string hash = Convert.ToBase64String(hashBytes);

            return (hash, salt);
        }

        // Controleer later of een ingevoerd wachtwoord klopt
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 100_000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);

            string newHash = Convert.ToBase64String(hashBytes);

            return newHash == storedHash;
        }
    }
}
