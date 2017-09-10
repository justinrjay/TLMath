using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LottoStuff
{
    public class LottoCsvFileHandling
    {
        public List<List<int>> SortedList { get; set; }
        public LottoCsvFileHandling(string filepath)
        {
            SortedList = SortListFromFile(filepath);
            //SortedList.Sort();
        }

        public List<List<int>> SortListFromFile(string filepath)
        {
            var reader = new StreamReader(File.OpenRead(filepath));
            List<List<int>> numlist = new List<List<int>>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                int x = 0;
                List<int> sortList = new List<int>();
                while (x < values.Length)
                {
                    sortList.Add(Convert.ToInt16(values[x]));
                    x++;
                }
                sortList.Sort();
                numlist.Add(sortList);
            }
            return numlist;
        }

    }
}
