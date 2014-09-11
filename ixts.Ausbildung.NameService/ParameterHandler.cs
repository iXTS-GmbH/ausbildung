using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class ParameterHandler
    {
        public static String[] Normalize(String[] parameters)
        {
            var allParameters = new List<String>();

            foreach (var parameter in parameters)
            {
                if (parameter != "" && parameter != " ")
                {
                    allParameters.Add(parameter);
                }
            }
            var normalizedParameters = new String[3];

            normalizedParameters[0] = allParameters[0];

            normalizedParameters[1] = allParameters.Count <= 1 ? null : allParameters[1];

            for (var i = 2; i < allParameters.Count; i++)
            {
                normalizedParameters[2] += string.Format(" {0}", allParameters[i]);
            }

            if (normalizedParameters[2] != null)
            {
                normalizedParameters[2] = normalizedParameters[2].Substring(1);
            }

            return normalizedParameters;
        }
    }
}
