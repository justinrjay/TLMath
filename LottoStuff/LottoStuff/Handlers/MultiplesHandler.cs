using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class MultiplesHandler : BaseHandler
    {
        private int _multipleDivisor;
        public int MultipleDivisor
        {
            get
            {
                return _multipleDivisor;
            }
            set
            {
                if (_multipleDivisor != value || multiplesList == null)
                {
                    _multipleDivisor = value;
                    frequencyComparisonList = buildMultiplesList();
                }
                
            }
        }

        public List<int> multiplesList
        {
            get
            {
                return frequencyComparisonList != null ? frequencyComparisonList : new List<int>();
            }
        }

        public MultiplesHandler(int drawPoolSize) : base(drawPoolSize)
        {
            this.drawPoolSize = drawPoolSize;
        }
        public MultiplesHandler(int drawPoolSize, int divisor) : base(drawPoolSize)
        {
            this.drawPoolSize = drawPoolSize;
            MultipleDivisor = divisor;
        }

        public List<int> buildMultiplesList()
        {
            List<int> multiplesInDrawPool = new List<int>();
            int multiple = MultipleDivisor;
            while (multiple <= drawPoolSize && multiple != 0)
            {
                multiplesInDrawPool.Add(multiple);
                multiple += MultipleDivisor;
            }
            return multiplesInDrawPool;
        }

        public int getCountOfMultiplesInNumberList(List<int> drawNumber)
        {
            return multiplesList.Intersect(drawNumber).Count();
        }

        public bool checkMultiplesFrequencies(List<int> drawNumber, Dictionary<int, int[]> multiplesDictionary)
        {
            foreach (KeyValuePair<int, int[]> multipleFrequency in multiplesDictionary)
            {
                MultipleDivisor = multipleFrequency.Key;
                if (checkFrequency(drawNumber, multipleFrequency.Value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
