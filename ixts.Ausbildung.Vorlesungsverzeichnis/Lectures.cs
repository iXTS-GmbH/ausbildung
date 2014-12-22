using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Vorlesungsverzeichnis
{
    public class Lectures
    {
        private List<String[]> datas = new List<string[]>(); 

        public Lectures(String datapath,IFileStream file = null)
        {
            file = file ?? new FileStreamImpl();

            var fileData = file.ReadAllLines(datapath);

            var dataList = new List<String[]>();

            foreach (var s in fileData)
            {
                dataList.Add(s.Split(':'));
            }
            datas = dataList;
        }

        public List<String> Titles()
        {
            var titles = new List<String>();

            foreach (var data in datas)
            {
                if (!titles.Contains(data[1]))
                {
                    titles.Add(data[1]);
                }
            }

            titles.Sort();

            return titles;
        }

        public List<String> Workaholics()
        {
            var workers = new List<String>();

            foreach (var data in datas)
            {
                workers.Add(data[2]);
            }

            var copy = new List<String>();
            var doubles = new List<String>();

            foreach (var worker in workers)
            {
                if (!copy.Contains(worker))
                {
                    copy.Add(worker);
                }
                else
                {
                    doubles.Add(worker);
                }
            }

            var result = new List<String>();

            foreach (var d in doubles)
            {
                if (!result.Contains(d))
                {
                    result.Add(d);
                }
            }

            return result;
        }

        public List<String> GroupToTiles(String groupTitle)
        {
            var result = new List<String>();

            foreach (var data in datas)
            {
                if (data[0] == groupTitle && !result.Contains(data[1]))
                {
                    result.Add(data[1]);
                }
            }

            return result;
        }
    }
}
