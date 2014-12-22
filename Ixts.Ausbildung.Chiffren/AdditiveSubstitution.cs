
namespace Ixts.Ausbildung.Chiffren
{
    public class AdditiveSubstitution:Sustitution
    {
        public override byte Encrypt(byte c, int key)
        {
            return (byte) (c + key);
        }

        public override byte Decrypt(byte c, int key)
        {
            return (byte) (c - key);
        }
    }
}
