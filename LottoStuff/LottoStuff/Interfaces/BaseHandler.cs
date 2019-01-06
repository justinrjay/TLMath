using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class BaseHandler : HandlerInterface
    {
        protected int drawPoolSize;
        protected List<int> frequencyComparisonList { get; set; } 
        public BaseHandler(int drawPoolSize)
        {
            this.drawPoolSize = drawPoolSize;
            frequencyComparisonList = new List<int>();
        }

        public bool checkFrequency(List<int> drawNumber, int[] frequenciesToCheck)
        {
            foreach (int frequency in frequenciesToCheck)
            {
                if (frequencyComparisonList.Intersect(drawNumber).Count() == frequency)
                {
                    return true;
                }
            }
            return false;
        }

        public int getFrequencyOfOccurrence(List<List<int>> drawcollection, int numberOfOccurrencesToCheck)
        {
            int numberOfOccurrences = 0;
            for (int i = 0; i < drawcollection.Count; i++)
            {
                if (frequencyComparisonList.Intersect(drawcollection[i]).Count() == numberOfOccurrencesToCheck)
                {
                    numberOfOccurrences++;
                }
            }
            return numberOfOccurrences;
        }
    }
}
