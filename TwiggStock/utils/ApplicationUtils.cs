using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TwiggStock.utils
{
    public class HashedPassword
    {
        public string hashedPassword { get; set;}
        public string salt { get; set;}
    }
    public static class ApplicationUtils
    {

        public static byte[] GenerateHashSalt()
        {
            // generate a 128-bit salt using a cryptographically strong random sequence
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
            // saltString = Convert.ToBase64String(salt);
        }


        public static byte[] GetSatlByteFromString(string saltString)
        {
            return Encoding.UTF8.GetBytes(saltString);
        }

        // return hased password
        public static string HashPassword(string password, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashedPassword;
        }

        // return the password validation
        public static bool ValidatePassword(string password, byte[] salt, string _hashedPassword)
        {
            Console.WriteLine("Password: "+ _hashedPassword);
            Console.WriteLine("HashPassword JIT: "+ HashPassword(password, salt));

            if(HashPassword(password, salt).Equals(_hashedPassword)){
                return true;
            }
            return false;

        }
    }
}
