using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class LottoMath
    {
        /// <summary>
        /// How many numbers are in the pool to be drawn from
        /// </summary>
        public int NumbersInDraw { get; set; }

        /// <summary>
        /// How many numbers will be drawn
        /// </summary>
        public int NumbersDrawn { get; set; }

        /// <summary>
        /// Returns the total number of combinations that are in the drawing
        /// </summary>
        public long OddsOfDraw {
            get {
                return GetOdds(NumbersInDraw, NumbersDrawn);
            }
        }

        /// <summary>
        /// A list of integers that contains all of the prime numbers in the pool
        /// </summary>
        public List<int> PrimeListInDraw { get; set; }

        /// <summary>
        /// The odds table for prime numbers.  Returns a list the size of the numbers drawn + 1.  Ex 5 number drawing has 6 entries.  One for 5 numbers drawn, 4 numbers drawn, and so on until 0
        /// Table contains the number in draw, the number of combinations that number drawn can create, and the odds of that happening
        /// </summary>
        public List<LottoOddsTable> PrimeTableList { get; set; }

        /// <summary>
        /// This is a list, of each list of factors up to the max factor(highest factor that produces at least enough to fill the drawing).  
        /// For example, if there drawing is 54 numbers, and 6 drawn, it would contain lists of all factors from 2 to 9.
        /// </summary>
        public List<List<int>> FactorLists { get; set; }

        /// <summary>
        /// Similar to the primetablelist, except this odds tables for all factors from 2 to the max factor.
        /// Has a 1:1 relationship with the factorlists table
        /// </summary>
        public List<List<LottoOddsTable>> FactorTableLists { get; set; }

        /// <summary>
        /// The max factor in the drawing that can produce the number drawn.  Foe example, a drawing of 54 numbers and 6 drawn would have a max of 9
        /// 9, 18, 27, 36, 45, 54.  Any larger number would only return 5 numbers
        /// </summary>
        public int HighFactor { get { return NumbersInDraw / NumbersDrawn; } }

        
        /// <summary>
        /// The number of primes from the Prime List in Draw.  Just a simple property to return the exact number of primes in a given drawing
        /// </summary>
        public int PrimesInDraw
        {
            get
            {
                return PrimeListInDraw.Count;
            }
        }
        public LottoMath(int numbersInDraw, int numbersDrawn)
        {
            NumbersInDraw = numbersInDraw;
            NumbersDrawn = numbersDrawn;
            PrimeListInDraw = GetPrimeNumbersInDraw();
            FactorLists = ReturnFactorLists();
            PrimeTableList = PrimeTable();
            FactorTableLists = FactorTable();
        }

        /// <summary>
        /// Gets the results for a partial number of drawn.  For instance if we wanted to know how many multiples of a number were within a draw
        /// </summary>
        /// <param name="amountOfNumbers">Number of numbers we're drawing from</param>
        /// <param name="numPartial">The size of the draw</param>
        /// <returns></returns>
        public long GetDrawingOddsPartial(int amountOfNumbers, int numPartial)
        {
            long poolResult = GetOdds(amountOfNumbers, numPartial);
            long remainderResult = GetOdds(NumbersInDraw - amountOfNumbers, NumbersDrawn - numPartial);
            return poolResult * remainderResult;
        }

        /// <summary>
        /// Calculates the numbers of numbers from an amount of numbers and a drawsize
        /// </summary>
        /// <param name="amountOfNumbers"></param>
        /// <param name="drawSize"></param>
        /// <returns></returns>
        private long GetOdds(int amountOfNumbers, int drawSize)
        {
            int numDrawn = drawSize - 1;
            long topResult = 1;
            long bottomResult = 1;
            while (numDrawn >= 0)
            {
                topResult = topResult * (amountOfNumbers - numDrawn);
                bottomResult = bottomResult * (drawSize - numDrawn);
                numDrawn--;
            }
            return topResult / bottomResult;
        }

        /// <summary>
        /// Simple function to divide the numbers of a draw, by a factor so we can determine how many multiples are within that draw
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public int GetNumberOfFactors(int factor)
        {
            return NumbersInDraw / factor;
        }


        /// <summary>
        /// Returns a list that contains the number the possiblilty for each draw of a pool of numbers.  
        /// For example, if we wanted to know the odds of the balance between even and odd numbers 
        /// </summary>
        /// <param name="amountOfNumbers"></param>
        /// <returns></returns>
        private List<LottoOddsTable> OddsOfPool(int amountOfNumbers)
        {
            int draw = NumbersDrawn;
            List<LottoOddsTable> oddsList = new List<LottoOddsTable>();
            while (draw >= 0)
            {
                oddsList.Add(new LottoOddsTable(draw, GetDrawingOddsPartial(amountOfNumbers, draw), OddsOfDraw));
                draw--;
            }
            return oddsList;
        }

        /// <summary>
        /// Returns a table of all factors if number of factors is greater or equal to the numbers drawn.  
        /// For example, a pool of 54 numbers, with 6 numbers drawn, would return a table all the way up to 9 
        /// </summary>
        /// <returns></returns>
        public List<List<LottoOddsTable>> FactorTable()
        {
            int x = 2;
            List<List<LottoOddsTable>> factorTable = new List<List<LottoOddsTable>>();
            while (x <= HighFactor)
            {
                factorTable.Add(OddsOfPool(GetNumberOfFactors(x)));
                x++;
            }
            return factorTable;
        }

        /// <summary>
        /// Returns the list of integers that are a certain factor within a number pool
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public List<int> ReturnFactors(int factor)
        {
            List<int> factorList = new List<int>();
            int num = factor;
            while (num <= NumbersInDraw)
            {
                factorList.Add(num);
                num += factor;
            }
            return factorList;
        }

        /// <summary>
        /// Creates a list of all factors from 2 to the max factor (highest factor that can divide into the pool the same number of draws ex 54 / 9 = 6)
        /// </summary>
        /// <returns></returns>
        public List<List<int>> ReturnFactorLists()
        {
            List<List<int>> factorLists = new List<List<int>>();
            int factor = 2;
            while (factor <= HighFactor)
            {
                factorLists.Add(ReturnFactors(factor));
                factor++;
            }
            return factorLists;
        }
        /// <summary>
        /// Returns the odds of how many numbers per combination of each prime
        /// </summary>
        /// <returns></returns>
        private List<LottoOddsTable> PrimeTable()
        {
            return OddsOfPool(PrimesInDraw);
        }
        /// <summary>
        /// Returns the largest prime factor of a given number.  If it has no prime factors, the number is returned as prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private int Esieve(int number)
        {
            long sqrrt = (long)Math.Round(Math.Sqrt(number));
            List<int> numlist = new List<int>();
            int x = 2;
            while (x <= sqrrt)
            {
                numlist.Add(x);
                int y = 0;
                while (numlist.Contains(x) && (y < numlist.Count - 1))
                {
                    if (x % numlist[y] == 0)
                    {
                        numlist.Remove(x);
                    }
                    else
                    {
                        y++;
                    }
                }
                if (number % x != 0)
                {
                    numlist.Remove(x);
                }
                x++;
            }
            return numlist.Count > 0 ? numlist[numlist.Count - 1] : number;
        }

        /// <summary>
        /// Generates a list of Prime Numbers from the given pool of numbers using the Esieve method.
        /// </summary>
        /// <returns></returns>
        private List<int> GetPrimeNumbersInDraw()
        {
            List<int> PrimeNumbers = new List<int>();
            int x = NumbersInDraw;
            while (x >= 2)
            {
                int primeFactor = Esieve(x);
                if (!PrimeNumbers.Contains(primeFactor))
                {
                    PrimeNumbers.Add(primeFactor);
                }
                x--;
            }
            PrimeNumbers.Sort();
            return PrimeNumbers;
        }
    }


    /// <summary>
    /// Simple class to store how many numbers are coming from a pool, the number of possible combinations from that pool with that drawing size, and it's percent chance from an overall pool
    /// </summary>
    public class LottoOddsTable
    {
        public int numDrawn { get; set; }
        public long numPossible { get; set; }
        public decimal percentChance { get; set; }

        public LottoOddsTable(int numDrawn, long numPossible, long totalPool)
        {
            this.numDrawn = numDrawn;
            this.numPossible = numPossible;
            this.percentChance = Math.Round(((decimal)numPossible * 100 / (decimal)totalPool), 0, MidpointRounding.AwayFromZero);
        }


    }

}


