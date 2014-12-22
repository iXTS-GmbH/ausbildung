using System;
using System.Collections.Generic;
using System.IO;

namespace ixts.Ausbildung.Filesystemsuche
{
    class Dublets:FTW
    {
        private Dictionary<String,String> found = new Dictionary<String, String>(); 

        protected override void EnterDir(string directoryPath)
        {
            AtFile(directoryPath);
        }

        protected override void LeaveDir(string directoryPath)
        {
            throw new NotImplementedException();
        }

        protected override void AtFile(string filePath)
        {
            var name = Path.GetFileNameWithoutExtension(filePath);

            if (!found.ContainsKey(name))
            {
                found.Add(name,filePath);
            }
            else
            {
                Console.WriteLine("{0} - {1}",found[name],filePath);
            }
        }
    }
}
