using System;

namespace ixts.Ausbildung.FilterSamples
{
    public class DataHandler
    {

        public static String Handle(String data)
        {
            var dataArray = data.Split(new[]{" ", ",", ";",Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var nullLine = false;
            var result = "";

            for (var i = 0; i < dataArray.Length - 3; i++)
            {
                if (dataArray[i] == "0")
                {
                    nullLine = true;
                }
                else
                {
                    if (nullLine && int.Parse(dataArray[i]) != 0)
                    {
                        result += "0 ";
                        nullLine = false;

                    }

                    if (int.Parse(dataArray[i]) > 0)
                    {
                        result += dataArray[i] + " ";
                    }
                }
            }

            return result;
        }

    }
}
