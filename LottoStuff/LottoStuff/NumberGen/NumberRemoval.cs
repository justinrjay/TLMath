using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class NumberRemoval
    {
        private NumberGenerator numberGenerator;
        private MultiplesHandler multiplesHandler;
        private PrimeNumberHandler primeNumberHandler;
        private RangeHandler rangeHandler;
        public List<List<int>> cleanNumList;
        public NumberRemoval(int drawSize, int drawPool)
        {
            numberGenerator = new NumberGenerator(drawSize, drawPool);
            cleanNumList = numberGenerator.numberCollection.ToList();
            multiplesHandler = new MultiplesHandler();
            primeNumberHandler = new PrimeNumberHandler(drawPool);
            rangeHandler = new RangeHandler(drawPool);
        }

        public void CleanNumberList(List<int> rangeFrequenciesToRemove)
        {
            int i = 0;
            while (i < cleanNumList.Count)
            {
                List<int> drawNumber = cleanNumList[i];
                if (!RemoveRangeFrequencies(rangeFrequenciesToRemove, drawNumber))
                {
                    i++;
                }
            }
        }

        public bool RemoveRangeFrequencies(List<int> rangeFrequenciesToRemove, List<int> drawNumber)
        {
            bool numberRemoved = false;
            int i = 0;
            while (i < rangeFrequenciesToRemove.Count && !numberRemoved)
            {
                numberRemoved = RemoveRangeFrequency(rangeFrequenciesToRemove[i], drawNumber);
                i++;
            }
            return numberRemoved;
        } 

        public bool RemoveRangeFrequency(int frequency, List<int> drawNumber)
        {
            if (rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(drawNumber, frequency))
            {
                cleanNumList.Remove(drawNumber);
                return true;
            }
            return false;
        }
    }
}
