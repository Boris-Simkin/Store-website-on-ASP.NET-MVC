using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Hashing
    {
        internal string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buffer = new byte[10];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        internal string HashPassword(string password, string saltkey)
        {
            string saltAndPassword = String.Concat(password, saltkey);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
