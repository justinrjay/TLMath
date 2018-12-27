using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class PrimeNumberHandler
    {
        private int _drawSize;
        private List<int> _primeNumbersInDraw;

        public List<int> primeNumbersInDraw {
            get
            {
                return _primeNumbersInDraw;
            }
        }

        public PrimeNumberHandler(int drawSize) 
        {
            _drawSize = drawSize;
            _primeNumbersInDraw = new List<int>();
            _primeNumbersInDraw.Add(2);
            buildPrimeNumbersInDraw();
        }

        public bool isPrime(int drawPossibility)
        {
            if (drawPossibility == 1 || drawPossibility == 0 || (drawPossibility != 2 && drawPossibility % 2 == 0))
            {
                return false;
            }
            if (drawPossibility == 2)
            {
                return true;
            }
            for (int i = 3; i <= Math.Sqrt(drawPossibility); i = i + 2)
            {
                if (drawPossibility % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void buildPrimeNumbersInDraw()
        {
            for (int i = 3; i <= _drawSize; i = i + 2)
            {
                if (isPrime(i))
                {
                    primeNumbersInDraw.Add(i);
                }
            }
        }

        public bool isNumberInPrimeList(int drawNumber)
        {
            return _primeNumbersInDraw.Contains(drawNumber);
        }

        public int numberOfPrimesInList(List<int> drawNumbers)
        {
            return _primeNumbersInDraw.Intersect(drawNumbers).Count();
        }

        public int getFrequencyOfPrimesCollection(List<List<int>> drawcollection, int numberOfOccurrencesToCheck)
        {
            int numberOfOccurrences = 0;
            for (int i = 0; i < drawcollection.Count; i++)
            {
                if (numberOfPrimesInList(drawcollection[i]) == numberOfOccurrencesToCheck)
                {
                    numberOfOccurrences++;
                }
            }
            return numberOfOccurrences;
        }
    }
}
