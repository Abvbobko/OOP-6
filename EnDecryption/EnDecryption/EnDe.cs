using CipherInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnDecryption
{
    public class EnDe : ICipher
    {
        public string Encrypt(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Decrypt(string cipherText) {
            var base64EncodedBytes = System.Convert.FromBase64String(cipherText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
