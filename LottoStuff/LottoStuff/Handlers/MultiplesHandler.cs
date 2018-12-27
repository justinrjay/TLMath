using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class MultiplesHandler
    {
        public int MultipleDivisor { get; set; }
        public MultiplesHandler()
        {

        }
        public MultiplesHandler(int divisor)
        {
            MultipleDivisor = divisor;
        }

        public int getCountOfMultiplesInNumberList(List<int> drawNumber)
        {
            int multipleCount = 0;
            for (int i = 0; i < drawNumber.Count; i++)
            {
                if (drawNumber[i] % MultipleDivisor == 0)
                {
                    multipleCount++;
                }
            }
            return multipleCount;
        }

        public int getFrequencyOfMultipleCollection(List<List<int>> drawCollection, int numberOfOccurrencesToCheck)
        {
            int numberOfOccurrences = 0;
            for (int i = 0; i < drawCollection.Count; i++)
            {
                if (getCountOfMultiplesInNumberList(drawCollection[i]) == numberOfOccurrencesToCheck)
                {
                    numberOfOccurrences++;
                }
            }
            return numberOfOccurrences;
        }
    }
}
