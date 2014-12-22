using System;

namespace Ixts.Ausbildung.Chiffren
{
    public interface ICipher
    {
        String Encrypt(String plainText, int key);
        String Decrypt(String cryptText, int key);
    }
}
