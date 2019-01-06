using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class NumberGenerator
    {
        public List<List<int>> numberCollection;

        private int drawSize;
        private int drawPoolSize;
        public int highestStartPoint;
        private RangeHandler rangeHandler;
        private PrimeNumberHandler primeNumberHandler;
        private MultiplesHandler multiplesHandler;
        private LastDigitHandler lastDigitHandler;
        public Exclusions exclusions { get; set; }
        public NumberGenerator(int drawSize, int drawPoolSize)
        {
            this.drawPoolSize = drawPoolSize;
            this.drawSize = drawSize;
            numberCollection = new List<List<int>>();
            highestStartPoint = drawPoolSize - drawSize + 1;
            rangeHandler = new RangeHandler(drawPoolSize);
            primeNumberHandler = new PrimeNumberHandler(drawPoolSize);
            multiplesHandler = new MultiplesHandler(drawPoolSize);
            lastDigitHandler = new LastDigitHandler(drawPoolSize);
            exclusions = new Exclusions();
        }

        public void generateList(List<int> defaultList, int listIndex, int startPoint, int endPoint, bool checkNumbersForRemoval)
        {
            int i = startPoint;
            int nextIndex = listIndex + 1;
            int nextEndpoint = endPoint + 1;
            while(i <= endPoint && listIndex < drawSize)
            {
                List<int> newList = defaultList.ToList();
                addNumberToList(newList, listIndex, i);
                addNewNumberToCollection(newList, listIndex, checkNumbersForRemoval, nextIndex, i + 1, nextEndpoint);
                i++;
            }
        }

        private void addNumberToList(List<int> newList, int listIndex, int newNumber)
        {
            if (newList.Count - 1 < listIndex)
            {
                newList.Add(newNumber);
            }
            else
            {
                newList[listIndex] = newNumber;
            }
        }

        private void addNewNumberToCollection(List<int> newList, int listIndex, bool checkNumbersForRemoval, int nextIndex, int nextStartPoint, int nextEndpoint)
        {
            if (listIndex == (drawSize - 1))
            {
                bool numberShouldBeAdded = checkNumbersForRemoval ? !shouldNumberBeRemoved(newList) : true;
                if (numberShouldBeAdded)
                {
                    numberCollection.Add(newList);
                }
            }
            else
            {
                generateList(newList, nextIndex, nextStartPoint, nextEndpoint, checkNumbersForRemoval);
            }
        }

        private bool shouldNumberBeRemoved(List<int> drawNumber)
        {
            if (rangeHandler.checkFrequency(drawNumber, exclusions.rangeFrequencyExclusions))
            {
                return true;
            }
            if (primeNumberHandler.checkFrequency(drawNumber, exclusions.primeNumberFrequencyExclusions))
            {
                return true;
            }
            if (multiplesHandler.checkMultiplesFrequencies(drawNumber, exclusions.multipleExclusions))
            {
                return true;
            }
            if (lastDigitHandler.checkFrequenciesForAllEndingDigits(drawNumber, exclusions.lastDigitExclusions))
            {
                return true;
            }
            return false;
        }
    }
}
