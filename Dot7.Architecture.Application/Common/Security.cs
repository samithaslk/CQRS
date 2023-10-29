using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dot7.Architecture.Application.Common
{

    public static class Security
    {
        public static string HashPassword(string salt, string password)
        {
            //            const int passwordIterations = 10000;
            //#pragma warning disable SYSLIB0041 // Type or member is obsolete


            //            var rfcKey = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt))
            //            {
            //                IterationCount = passwordIterations
            //            };
            //#pragma warning restore SYSLIB0023 // Type or member is obsolete
            //            var hash = rfcKey.GetBytes(20);

            //            return Convert.ToBase64String(hash);
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string GenerateSalt()
        {
            return SecureRandomString(25);
        }

        private static string SecureRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

#pragma warning disable SYSLIB0023 // Type or member is obsolete
            //Generate a securely random number
            var random = new RNGCryptoServiceProvider();
#pragma warning restore SYSLIB0023 // Type or member is obsolete

            var buffer = new byte[4];

            var result = "";
            for (var i = 0; i < length; i++)
            {
                random.GetBytes(buffer);
                var intRandom = BitConverter.ToInt32(buffer, 0);

                result += chars.Substring(Math.Abs(intRandom) % chars.Length, 1);
            }

            return result;
        }
    }
}
