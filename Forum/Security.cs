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
                var randomNumber = new byte[SALTSIZE];

                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] Hash(byte[] data, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
}
