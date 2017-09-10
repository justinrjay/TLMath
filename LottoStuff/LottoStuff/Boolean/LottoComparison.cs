using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class LottoComparison : LottoMath
    {
        private int PercentDisqualify { get; set; }
        public LottoComparison(int numbersInDraw, int numbersDrawn) : base(numbersInDraw, numbersDrawn)
        {
            PercentDisqualify = 15;   
        }

        public int ReturnMatchCount(List<int> compareSet, List<int> Disqualifiers)
        {
            return compareSet.Intersect(Disqualifiers).Count();
        }

        public int ReturnMatchCountOfFactors(List<int> drawList, int factor)
        {
            return ReturnMatchCount(drawList, base.ReturnFactors(factor));
        }

        private bool NumberDisqualified(List<int> drawList, List<int> compareList, List<LottoOddsTable> lot)
        {
            LottoOddsTable tableOfNumDrawn = lot.Where(x => x.numDrawn == ReturnMatchCount(drawList, compareList)).FirstOrDefault();
            return tableOfNumDrawn.percentChance < PercentDisqualify;
        }

        //Returns true if the number is disqualified
        public bool PrimeDisqualified(List<int> drawList)
        {
            return NumberDisqualified(drawList, PrimeListInDraw, PrimeTableList);
        }

        //Loops through the factor lists tables and returns true if any condition causes the number to be disqualified
        public bool FactorsDisqualified(List<int> drawList)
        {
            bool disqualified = false;
            int counter = 0;
            while (!disqualified && counter < FactorLists.Count)
            {
                disqualified = NumberDisqualified(drawList, FactorLists[counter], FactorTableLists[counter]);
                counter++;
            }
            return disqualified;
        }

        //Loops through the range lists, and disqualifies it if the conditions do not match.  Returns true when conditions don't match
        public bool RangesDisqualified(List<int> drawList)
        {
            bool disqualified = false;
            int counter = 0;
            while (!disqualified && counter < RangeLists.Count)
            {
                disqualified = NumberDisqualified(drawList, RangeLists[counter], RangeTableLists[counter]);
                counter++;
            }
            return disqualified;
        }

        public bool IsNumberDisqualifed(List<int> drawList)
        {
            return !PrimeDisqualified(drawList) 
               &&
                !FactorsDisqualified(drawList) 
                && 
                RangesDisqualified(drawList)
                ;
        }
        
    }
}
