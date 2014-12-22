using System;

namespace Ixts.Ausbildung.Chiffren
{
    public abstract class Sustitution:ICipher
    {
        public string Encrypt(string plainText, int key)
        {
            var cryptText = "";

            foreach (var symbol in plainText)
            {
                cryptText = Convert.ToString(Encrypt(Convert.ToByte(symbol),key)) + cryptText;
            }

            return cryptText;
        }

        public string Decrypt(string cryptText, int key)
        {
            var plainText = "";

            foreach (var symbol in cryptText)
            {
                plainText = Convert.ToString(Decrypt(Convert.ToByte(symbol), key)) + plainText;
            }

            return plainText;
        }

        public abstract Byte Encrypt(byte c, int key);
        public abstract Byte Decrypt(byte c, int key);
    }
}
