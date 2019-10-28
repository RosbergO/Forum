using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Forum.Security
{
    public class Security
    {
        private const int SALTSIZE = 128;
        public static byte[] Salt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[SALTSIZE];

                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] Hash(byte[] data, byte[] salt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(data);
            }
        }

        public static string get_unique_string(int string_length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bit_count = (string_length * 6);
                var byte_count = ((bit_count + 7) / 8); // rounded up
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
