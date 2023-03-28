using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Classic_RPS
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            using var rng = new RNGCryptoServiceProvider();
            var key = new byte[32];
            rng.GetBytes(key);
            return key;
        }
    }
}
