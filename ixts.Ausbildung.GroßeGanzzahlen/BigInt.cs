using System;

namespace ixts.Ausbildung.GroßeGanzzahlen
{
    public class BigInt
    {
        private readonly String value;

        public BigInt(String d)
        {
            value = d;
        }

        public BigInt(int i)
        {
            value = i.ToString();
        }

        public override String ToString()
        {
            return value;
        }

        public override Boolean Equals(object x)
        {
            var b = (BigInt) x;

            return value == b.ToString();
        }

        public Boolean Less(BigInt b)
        {
            if (value.Length < b.ToString().Length)
            {
                return true;
            }
            if (value.Length > b.ToString().Length)
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (int.Parse(value[i].ToString()) < int.Parse(b.ToString()[i].ToString()))
                {
                    return true;
                }
                if (int.Parse(value[i].ToString()) > int.Parse(b.ToString()[i].ToString()))
                {
                    return false;
                }
            }
            return false;//nicht erreichbar
        }

        public BigInt Add(BigInt b)
        {
            var longerCharArray = new char[0]; 
            var overflow = 0;
            var shorterCharArray = new char[0]; 


            if (b.ToString().ToCharArray().Length < value.ToCharArray().Length)//wenn value länger oder gleich lang ist
            {
                longerCharArray = value.ToCharArray(); 
                shorterCharArray = b.ToString().ToCharArray();
            }
            else //wenn b länger ist
            {
                longerCharArray = b.ToString().ToCharArray();
                shorterCharArray = value.ToCharArray();
            }

            for (var i = shorterCharArray.Length - 1; i >= 0; i--)
            {
                var sum = int.Parse(shorterCharArray[i].ToString()) + int.Parse(longerCharArray[i + longerCharArray.Length - shorterCharArray.Length].ToString());
                sum += overflow; 
                overflow = sum / 10; 
                longerCharArray[i+ longerCharArray.Length - shorterCharArray.Length] = (sum % 10).ToString().ToCharArray()[0]; 
            }

            var j = longerCharArray.Length - shorterCharArray.Length - 1; 

            while (overflow != 0) 
            {
                if (j >= 0)
                {
                    var sum = int.Parse(longerCharArray[j].ToString());
                    sum += overflow;
                    overflow = sum / 10;
                    longerCharArray[j] = (sum % 10).ToString().ToCharArray()[0];
                    j--;
                }
                else
                {
                    var longerString = CharArrayToString(longerCharArray); 
                    longerString = overflow + longerString ;
                    longerCharArray = longerString.ToCharArray();
                    overflow = 0;
                }
            }

            var result = CharArrayToString(longerCharArray);

            return new BigInt(result);
        }

        private String CharArrayToString(char[] charArray)
        {
            var result = "";

            foreach (var item in charArray) 
            {
                result = result + int.Parse(item.ToString());
            }

            return result;
        }

    }
}