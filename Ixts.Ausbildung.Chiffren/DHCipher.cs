using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ixts.Ausbildung.Potenzieren;

namespace Ixts.Ausbildung.Chiffren
{
    public class DHCipher:ICipher
    {
        private readonly int secretKey;
        private readonly int publicKey;
        private readonly int prime;
        

        public DHCipher(int prime,int generator)
        {
            var random = new Random();
            secretKey = random.Next();
            publicKey = Potenz.Pow(generator,secretKey,prime);
            this.prime = prime;
        }

        public string Encrypt(string plainText, int key)
        {
            var cryptkey = Potenz.Pow(key, secretKey, prime);
            var sc = new StreamCipher();
            return sc.Encrypt(plainText, cryptkey);
        }

        public string Decrypt(string cryptText, int key)
        {
            var cryptkey = Potenz.Pow(key, secretKey, prime);
            var sc = new StreamCipher();
            return sc.Decrypt(cryptText, cryptkey);
        }

        public int GetPublicKey()
        {
            return publicKey;
        }
    }
}
