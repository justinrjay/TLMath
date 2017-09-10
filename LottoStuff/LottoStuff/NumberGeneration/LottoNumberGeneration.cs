using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class LottoNumberGeneration
    {
        public List<List<int>> NumberPool { get; set; }
        public LottoNumberGeneration()
        {
            NumberPool = new List<List<int>>();
            GenerateNum(69, 5);
        }

        /// <summary>
        /// Recursively generates a list of numbers for the given pool
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="drawSize"></param>
        /// <param name="start"></param>
        /// <param name="numList"></param>
        public void GenerateNum(int pool, int drawSize, int start = 1, List<int> numList = null)
        {
            int stopPoint = pool - drawSize + 1;
            if (numList == null)
            {
                numList = new List<int>();
            }
            while (start <= stopPoint)
            {
                numList.Add(start);
                if (drawSize > 1)
                {
                    GenerateNum(pool, drawSize - 1, start + 1, numList);
                }
                if (drawSize == 1)
                {
                    NumberPool.Add(numList);
                }
                numList.Remove(start);
                start++;
            }
        }

       
    }
}
