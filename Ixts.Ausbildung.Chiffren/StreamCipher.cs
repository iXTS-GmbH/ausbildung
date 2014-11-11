using System;

namespace Ixts.Ausbildung.Chiffren
{
    public class StreamCipher:ICipher
    {
        private Random keyGenerator;

        public string Encrypt(string plainText, int key)
        {
            keyGenerator = new Random(key);

            var bytes = new byte[plainText.Length];

            for (var i = 0; i < plainText.Length; i++)
            {
                bytes[i] = Convert.ToByte(plainText[i]);
            }

            var cipher = new XorSubstitution();
            for (var i = 0; i < bytes.Length; i++)
            {
                var runkey = keyGenerator.Next();
                bytes[i] = cipher.Encrypt(bytes[i], runkey);
            }
            var cryptText = "";
            for (var i = 0; i < bytes.Length; i++)
            {
                cryptText = Convert.ToChar(bytes[i]) + cryptText;
            }
            return cryptText;
        }

        public string Decrypt(string cryptText, int key)
        {
            keyGenerator = new Random(key);

            var bytes = new byte[cryptText.Length];

            for (var i = 0; i < cryptText.Length; i++)
            {
                bytes[i] = Convert.ToByte(cryptText[i]);
            }

            var cipher = new XorSubstitution();
            for (var i = 0; i < bytes.Length; i++)
            {
                var runkey = keyGenerator.Next();
                bytes[i] = cipher.Decrypt(bytes[i], runkey);
            }
            var plainText = "";
            for (var i = 0; i < bytes.Length; i++)
            {
                plainText = Convert.ToChar(bytes[i]) + plainText;
            }
            return plainText;
        }
    }
}
