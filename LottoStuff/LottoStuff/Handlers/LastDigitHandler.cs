using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class LastDigitHandler : BaseHandler
    {
        private int numberOfRanges;
        private static int _endingDigit;
        public int endingDigit
        {
            get { return _endingDigit; }
            set {
                if (_endingDigit != value || endingDigitNumberList == null)
                {
                    _endingDigit = value;
                    this.frequencyComparisonList = buildEndingNumbersList();
                }
            }
        }
        public List<int> endingDigitNumberList {
            get
            {
                return this.frequencyComparisonList;
            }
        }
            
        public LastDigitHandler(int drawPoolSize, int precision = 10) : base(drawPoolSize)
        {
            this.drawPoolSize = drawPoolSize;
            numberOfRanges = drawPoolSize / precision + 1;
        }

        public List<int> buildEndingNumbersList()
        {
            List<int> newEndingNumbersList = new List<int>();
            for (int i = 0; i < numberOfRanges; i++)
            {
                int newNumber = 10 * i + endingDigit;
                if (newNumber <= drawPoolSize && newNumber != 0)
                {
                    newEndingNumbersList.Add(newNumber);
                }
            }
            return newEndingNumbersList;
        }

        public int numberOfEndingDigitsThatMatchFromNumber(List<int> drawNumber)
        {
            return endingDigitNumberList.Intersect(drawNumber).Count();
        }

        public bool checkFrequenciesForAllEndingDigits(List<int> drawNumber, int[] frequenciesToCheck)
        {
            for (int i = 0; i < 10; i++)
            {
                endingDigit = i;
                if (checkFrequency(drawNumber, frequenciesToCheck))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
