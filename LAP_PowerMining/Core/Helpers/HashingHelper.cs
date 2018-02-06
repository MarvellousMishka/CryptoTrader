using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LAP_PowerMining.Core.Helpers
{
    public class HashingHelper
    {
        private static string HexString(byte[] bytes)
        {
            var hashSB = new StringBuilder(64);

            foreach (var b in bytes)
            {
                hashSB.Append(b.ToString("X2"));
            }
            return hashSB.ToString();
        }

        public static string SaltErzeugen()
        {
            var salt = new byte[32];

            // Randon number generator 
            var rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(salt);

            return HexString(salt);
        }

        public static string HashBerechnen(string s)
        {
            //Daten (in userem Fall ein String)  in ein ByteArray umwandeln!
            var bytes = Encoding.UTF8.GetBytes(s);

            using (SHA256 sha = new SHA256Managed())
            {
                var hash = sha.ComputeHash(bytes);
                return HexString(hash);
            }
        }

        public static string SaltAndHashPassword(string password, out string salt)
        {
            salt=SaltErzeugen();
            password += salt;
            password = HashingHelper.HashBerechnen(password);
            return password;
        }
    }
}