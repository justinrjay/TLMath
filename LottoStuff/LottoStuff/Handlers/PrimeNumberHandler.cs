using System;
using System.Collections.Generic;
using System.Linq;

namespace LottoStuff
{
    public class PrimeNumberHandler : BaseHandler
    {
        public List<int> primeNumbersInDraw {
            get
            {
                return frequencyComparisonList;
            }
        }

        public PrimeNumberHandler(int drawPoolSize) : base(drawPoolSize)
        {
            frequencyComparisonList = buildPrimeNumbersInDraw();
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

        private List<int> buildPrimeNumbersInDraw()
        {
            List<int> primeNumbersInDraw = new List<int>();
            primeNumbersInDraw.Add(2);
            for (int i = 3; i <= drawPoolSize; i = i + 2)
            {
                if (isPrime(i))
                {
                    primeNumbersInDraw.Add(i);
                }
            }
            return primeNumbersInDraw;
        }

        public bool isNumberInPrimeList(int drawNumber)
        {
            return primeNumbersInDraw.Contains(drawNumber);
        }

        public int numberOfPrimesInList(List<int> drawNumbers)
        {
            return primeNumbersInDraw.Intersect(drawNumbers).Count();
        }
    }
}
