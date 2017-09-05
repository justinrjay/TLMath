using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LottoStuff
{
    class cashfive : lottofunctions
    {
        public cashfive()
        {

        }

        public List<int[]> GenerateCashFiveNumbers(string previous_filepath)
        {
            return GenerateCashFive(37, previous_filepath);
        }

        public List<int[]> SortListFromFile(string filepath, int startindex)
        {
            return base.SortListFromFile(filepath, startindex, 5);
        }


        public List<int[]> GenerateCashFive(int pool, string previous_filepath)
        {
            var previousdraw = SortListFromFile(previous_filepath, 0);
            List<int[]> highfreqcomb = new List<int[]>();
            highfreqcomb.Add(new int[] { 1, 2, 11, 18 });
            highfreqcomb.Add(new int[] { 1, 5, 20, 2 });
            highfreqcomb.Add(new int[] { 4, 9, 16, 17 });
            //var highestfrequencycombinations = SortListFromFile(frequency_filepath, 0, 4);
            List<int[]> numlist = new List<int[]>();
            int num1 = 1;
            while (num1 <= pool - 4)
            {
                int num2 = num1 + 1;
                while (num2 <= pool - 3)
                {
                    int num3 = num2 + 1;
                    while (num3 <= pool - 2)
                    {
                        int num4 = num3 + 1;
                        while (num4 <= pool - 1)
                        {
                            int num5 = num4 + 1;
                            while (num5 <= pool)
                            {
                                int[] newnum = new int[] { num1, num2, num3, num4, num5 };
                                if (
                                    //(CheckMatchesToint(newnum, new int[] { 1, 2, 11, 18 }, 4) || CheckMatchesToint(newnum, new int[] { 1, 5, 20, 2 }, 4) || CheckMatchesToint(newnum, new int[] { 4, 9, 16, 17 }, 4))
                                    //&&
                                    (!CheckRange(newnum, 1, 9, new int[] { 4, 5 }) && !CheckRange(newnum, 10, 19, new int[] { 4, 5 }) && !CheckRange(newnum, 20, 29, new int[] { 4, 5 }) && !CheckRange(newnum, 30, 37, new int[] { 4, 5 }))
                                    &&
                                    (CheckRange(newnum, 1, 9, new int[] { 0 }) || CheckRange(newnum, 10, 19, new int[] { 0 }) || CheckRange(newnum, 20, 29, new int[] { 0 }) || CheckRange(newnum, 30, 37, new int[] { 0 }))
                                    &&
                                    (CheckRange(newnum, 1, 9, new int[] { 2 }) || CheckRange(newnum, 10, 19, new int[] { 2 }) || CheckRange(newnum, 20, 29, new int[] { 2 }) || CheckRange(newnum, 30, 37, new int[] { 2 }))
                                    &&
                                    (CheckFactor(newnum, 2, new int[] { 2, 3 }))
                                    &&
                                    (CheckFactor(newnum, 3, new int[] { 2, 1 }))
                                    &&
                                    (!CheckNumberEndings(newnum, new int[] { 4, 5 }))
                                    &&
                                    (AnalyzePrevious(newnum, previousdraw, 8, new int[] { 2, 3, 4, 5 }))
                                    &&
                                    (CheckPrimeMatches(newnum, new int[] { 1, 2 }))
                                    &&
                                    (!CheckPreviousDraw(newnum, previous_filepath, new int[] { 4, 5 }, 5))
                                    )
                                {
                                    numlist.Add(newnum);
                                }
                                num5++;
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

       public void abcd()
        {
            //int count = 1;
            //while (x < comparelist.Count())
            //{
            //    if (
            //        comparelist[x][0] == comparelist[x-1][0]
            //        && comparelist[x][1] == comparelist[x - 1][1]
            //        && comparelist[x][2] == comparelist[x - 1][2]
            //        && comparelist[x][3] == comparelist[x - 1][3]
            //        )
            //    { count++; }
            //    else
            //    {
            //        if (count > 15)
            //        {
            //            numcoms.Add(new int[] { comparelist[x - 1][0], comparelist[x - 1][1], comparelist[x - 1][2], comparelist[x - 1][3] });
            //        }
            //        count = 1;
            //    }
            //    x++;
            //}
        }

    }
    
}
