using System;
using System.IO;

namespace ixts.Ausbildung.Filesystemsuche
{
    public abstract class FTW
    {
        protected void Walk(String path)
        {
            if (File.Exists(path))
            {
                AtFile(path);
            }else if (Directory.Exists(path))
            {
                EnterDir(path);
                var content = ArrayFusion(Directory.GetFiles(path), Directory.GetDirectories(path));

                if (content.Length != 0)
                {
                    foreach (var s in content)
                    {
                        Walk(string.Format("{0}\\{1}",path,s));
                    }
                }
                LeaveDir(path);
            }
        }

        protected abstract void EnterDir(String directoryPath);

        protected abstract void LeaveDir(String directoryPath);

        protected abstract void AtFile(String filePath);

        protected String[] ArrayFusion(String[] array1,String[] array2)
        {
            var result = new String[array1.Length + array2.Length];

            for (var i = 0; i < array2.Length - 1; i++)
            {
                result[i] = array2[i];
            }

            for (var i = array2.Length; i < result.Length - 1; i++)
            {
                result[i] = array1[i - array2.Length];
            }

            return result;
        }

    }
}
