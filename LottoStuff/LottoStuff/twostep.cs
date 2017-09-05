using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    class twostep : lottofunctions
    {
        public twostep()
        {

        }

        public List<int[]> SortedFrequencies(List<int[]> comparelist)
        {
            return NumberFrequencyCountSorted(comparelist, 35);
        }

        public List<int[]> GenerateTwoStep(int pool)
        {
            List<int[]> numlist = new List<int[]>();
            int num1 = 1;
            while (num1 <= pool - 3)
            {
                int num2 = num1 + 1;
                while (num2 <= pool - 2)
                {
                    int num3 = num2 + 1;
                    while (num3 <= pool - 1)
                    {
                        int num4 = num3 + 1;
                        while (num4 <= pool)
                        {
                            int[] newnum = new int[] { num1, num2, num3, num4 };
                            if (
                               TwoStepCheck(newnum)
                            )
                            {
                                numlist.Add(newnum);
                            }
                            num4++;
                        }
                        num3++;
                    }
                    num2++;
                }
                num1++;
            }
            return numlist;
        }

        public bool TwoStepCheck(int[] newnum)
        {
            return (CheckRange(newnum, 1, 9, new int[] { 0, 1, 2 }) || CheckRange(newnum, 10, 19, new int[] { 0, 1, 2 }) || CheckRange(newnum, 20, 29, new int[] { 0, 1, 2 }) || CheckRange(newnum, 30, 35, new int[] { 0, 1 }))
                   &&
                   (!CheckFactor(newnum, 2, new int[] { 0, 4 }))
                   &&
                   (CheckFactor(newnum, 3, new int[] { 0, 1, 2 }))
                   &&
                   (CheckPrimeMatches(newnum, new int[] { 0, 1, 2}));
        }

        public int TwoStepPreviousCheck(List<int[]> twostepnums)
        {
            int matchcount = 0;
            foreach (var twostepnum in twostepnums)
            {
                if (TwoStepCheck(twostepnum))
                {
                    matchcount++;
                }
            }
            return matchcount;
        }
    }
}
