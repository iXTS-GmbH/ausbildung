﻿using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class NormalizeParameters
    {
        public static String[] Normalize(String[] parameters)
        {
            List<String> allParameters = new List<String>();

            foreach (String parameter in parameters)
            {
                if (parameter != "" && parameter != " ")
                {
                    allParameters.Add(parameter);
                }
            }
            String[] normalizedParameters = new String[3];

            normalizedParameters[0] = allParameters[0];

            normalizedParameters[1] = allParameters[0] == "STOP" ? null : allParameters[1];

            for (int i = 2; i < allParameters.Count; i++)
            {
                normalizedParameters[2] += string.Format(" {0}", allParameters[i]);
            }

            if (normalizedParameters[2] != null)
            {
                normalizedParameters[2] = normalizedParameters[2].Substring(1);
                normalizedParameters[2] = normalizedParameters[2].Replace("ä", "ae-").Replace("ö","oe-").Replace("ü","ue-");
                normalizedParameters[2] = normalizedParameters[2].Replace("Ä", "Ae-").Replace("Ö", "Oe-").Replace("Ü", "Ue-").Replace("ß", "ss-");
            }

            return normalizedParameters;
        }
    }
}
