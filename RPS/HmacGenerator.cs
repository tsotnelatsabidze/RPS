using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


    public class HmacGenerator
    {
        private readonly byte[] _key;

        public HmacGenerator(byte[] key)
        {
            _key = key;
        }

        public byte[] ComputeHmac(string message)
        {
            var hmac = new HMACSHA256(_key);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        }
    }

