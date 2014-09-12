using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class ParameterHandler
    {
        private const String SPACE = " ";

        public static String[] GetParameters(ISocket socket)
        {
            var data = string.Empty;

            for (; ; )
            {
                data += socket.Receive();

                if (data.Contains(Environment.NewLine))
                {
                    Console.WriteLine(data);

                    return NormalizeData(data);
                }
            }
        }

        public static String[] Normalize(String[] parameters)
        {

            var allParameters = new List<String>();

            foreach (var parameter in parameters)
            {
                if (parameter != string.Empty && parameter != SPACE)
                {
                    allParameters.Add(parameter);
                }
            }
            var normalizedParameters = new String[3];

            normalizedParameters[0] = allParameters.Count <  1 ? string.Empty : allParameters[0];

            normalizedParameters[1] = allParameters.Count < 2 ?  null: allParameters[1];

            for (var i = 2; i < allParameters.Count; i++)
            {
                normalizedParameters[2] += string.Format("{1}{0}", allParameters[i],SPACE);
            }

            if (normalizedParameters[2] != null) 
            {
                normalizedParameters[2] = normalizedParameters[2].Substring(1);
            }

            return normalizedParameters; 
        }

        private static String[] NormalizeData(String data)
        {
            data = data.Replace(Environment.NewLine, String.Empty);

            while (data.Contains(Constants.DELETED_CHAR_MARKER))
            {
                data = data.Remove(data.IndexOf(Constants.DELETED_CHAR_MARKER, StringComparison.CurrentCulture) - 1, 2);
            }

            return Normalize(data.Split(Constants.PARAMETER_DELIMITER));
        }




    }
}
