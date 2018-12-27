using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class RangeHandler
    {
        private int _drawSize;
        public int numberOfRanges { get; set; }
        public List<List<int>> rangeLists { get; }
        
        public RangeHandler(int drawSize)
        {
            _drawSize = drawSize;
            setNumberOfRanges();
            rangeLists = new List<List<int>>();
            buildRangeLists();
        }

        public void setNumberOfRanges()
        {
            int precision = 10;
            while (_drawSize % precision != _drawSize)
            { 
                precision = precision * 10;
            }
            precision = precision / 10;
            numberOfRanges = _drawSize / precision + 1; 
        }

        public void buildRangeLists()
        {
            int i = 0;
            while (i < numberOfRanges)
            {
                rangeLists.Add(buildRange(i));
                i++;
            }
        }

        public List<int> buildRange(int rangePosition)
        {
            List<int> newRange = new List<int>();
            for (int j = 0; j <= 9; j++)
            {
                int newNumberInRange = j + 10 * rangePosition;
                if (newNumberInRange != 0 && newNumberInRange <= _drawSize)
                {
                    newRange.Add(newNumberInRange);
                }
            }
            return newRange;
        }

        public List<int> getCountsOfNumbersInRanges(List<int> drawNumberList)
        {
            List<int> rangeCounts = new List<int>();
            int i = 0;
            while (i < numberOfRanges)
            {
                rangeCounts.Add(rangeLists[i].Intersect(drawNumberList).Count());
                i++;
            }
            return rangeCounts;
        }

        public bool checkIfAnyRangeOccursSpecificNumberOfTimes(List<int> drawNumberList, int numberOfOccurencesToCheck)
        {
            List<int> ranges = getCountsOfNumbersInRanges(drawNumberList);
            for (int j = 0; j < numberOfRanges; j++)
            {
                if (ranges[j] == numberOfOccurencesToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public int getSpecificFrequencyForRanges(List<List<int>> drawCollection, int numberOfOccurrencesToCheck)
        {
            int numberOfOccurrencesOfFrequency = 0;
            for (int i = 0; i < drawCollection.Count; i++)
            {
                if (checkIfAnyRangeOccursSpecificNumberOfTimes(drawCollection[i], numberOfOccurrencesToCheck))
                {
                    numberOfOccurrencesOfFrequency++;
                }
            }
            return numberOfOccurrencesOfFrequency;
        }
    }
}
