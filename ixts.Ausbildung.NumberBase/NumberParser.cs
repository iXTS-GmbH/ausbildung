using System;

namespace ixts.Ausbildung.NumberBase
{
    public class NumberParser
    {
        public static string Parse(String startBase, String endBase, int number)
        {
            switch (startBase)
            {
                case "2":
                    switch (endBase)
                    {
                        case "8":
                            return BinToOkt.Parse(number);
                        case "10":
                            return BinToDez.Parse(number);
                        case "16":
                            return BinToHex.Parse(number);
                    }
                    break;
                case "8":
                    switch (endBase)
                    {
                        case "2":
                            return OktToBin.Parse(number);
                        case "10":
                            return OktToDez.Parse(number);
                        case "16":
                            return OktToHex.Parse(number);
                    }
                    break;
                case "10":
                    switch (endBase)
                    {
                        case "2":
                            return DezToBin.Parse(number);
                        case "8":
                            return DezToOkt.Parse(number);
                        case "16":
                            return DezToHex.Parse(number);
                    }
                    break;
                case "16":
                    switch (endBase)
                    {
                        case "2":
                            return HexToBin.Parse(number);
                        case "8":
                            return HexToOkt.Parse(number);
                        case "10":
                            return HexToDez.Parse(number);
                    }
                    break;
            }

            throw new Exception("Invalid Base");
        }
    }
}
