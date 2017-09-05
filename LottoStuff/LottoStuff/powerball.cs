using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    class powerball : lottofunctions
    {
        public powerball()
        {

        }

        public void SortPowerball(string previousfilepath, string newfilepath)
        {
            OutputListToCSV(SortListFromFile(previousfilepath, 0, 5), newfilepath);
        }

        public int PreviousMatchesToCriteria(string previousfilepath)
        {
            var sortedlist = SortListFromFile(previousfilepath, 0, 5);
            int count = 0;
            foreach (var sorted in sortedlist)
            {
                if (CheckCriteria(sorted))
                {
                    count++;
                }
            }
            return count;
        }

        public bool CheckCriteria(int[] newnum)
        {
            return (
                        (!CheckRange(newnum, 1, 9, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 10, 19, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 20, 29, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 30, 39, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 40, 49, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 50, 59, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 60, 69, new int[] { 3, 4, 5 }))
                                    &&
                                    (CheckRange(newnum, 1, 9, new int[] { 2 }) || CheckRange(newnum, 10, 19, new int[] { 2 }) || CheckRange(newnum, 20, 29, new int[] { 2 }) || CheckRange(newnum, 30, 39, new int[] { 2 }) || CheckRange(newnum, 40, 49, new int[] { 2 }) || CheckRange(newnum, 50, 59, new int[] { 2 }) || CheckRange(newnum, 60, 69, new int[] { 2 }))
                                    &&
                                    (!CheckFactor(newnum, 2, new int[] { 0, 5 }))
                                    &&
                                    (CheckFactor(newnum, 3, new int[] { 0, 1, 2, 3 }))
                                    &&
                                    (CheckFactor(newnum, 4, new int[] { 0, 1, 2, 3 }))
                                    &&
                                    (CheckFactor(newnum, 5, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 6, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 7, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 8, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 9, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 10, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 11, new int[] { 0, 1, 2 }))
                                    &&
                                    (CheckFactor(newnum, 12, new int[] { 0, 1 }))
                                    &&
                                    (CheckFactor(newnum, 13, new int[] { 0, 1 }))
                                    &&
                                    (CheckFactor(newnum, 17, new int[] { 0, 1 }))
                                    &&
                                    (CheckPrimeMatches(newnum, new int[] { 0, 1, 2, 3 }))
                                    &&
                                    (!CheckNumberEndings(newnum, new int[] { 3, 4, 5 }))
                                   );
        }

        public List<int[]> SortIntoTopFourCombinations(List<int[]> numlist)
        {
            List<int[]> listoffour = new List<int[]>();
            foreach (var num in numlist)
            {
                listoffour.Add(new int[] { num[0], num[1], num[2], num[3] });
                listoffour.Add(new int[] { num[0], num[1], num[2], num[4] });
                listoffour.Add(new int[] { num[0], num[1], num[3], num[4] });
                listoffour.Add(new int[] { num[0], num[2], num[3], num[4] });
                listoffour.Add(new int[] { num[1], num[2], num[3], num[4] });
            }
            listoffour = listoffour.OrderBy(y => y[0]).ThenBy(y => y[1]).ThenBy(y => y[2]).ThenBy(y => y[3]).ToList();
            int x = 0;
            int count = 1;
            List<int[]> numcoms = new List<int[]>();
            while (x < listoffour.Count()-1)
            {
                if (
                    listoffour[x][0] == listoffour[x + 1][0]
                    && listoffour[x][1] == listoffour[x + 1][1]
                    && listoffour[x][2] == listoffour[x + 1][2]
                    && listoffour[x][3] == listoffour[x + 1][3]
                    )
                {
                    count++;
                }
                else
                {
                    numcoms.Add(new int[] { listoffour[x][0], listoffour[x][1], listoffour[x][2], listoffour[x][3], count});
                    count = 1;
                }
                x++;
            }
            return numcoms.OrderByDescending(y=>y[4]).ToList();
        }

        public List<int[]> SortIntoTopThreeCombinations(List<int[]> numlist)
        {
            List<int[]> listoffour = new List<int[]>();
            foreach (var num in numlist)
            {
                listoffour.Add(new int[] { num[0], num[1], num[2] });
                listoffour.Add(new int[] { num[0], num[1], num[3] });
                listoffour.Add(new int[] { num[0], num[1], num[4] });
                listoffour.Add(new int[] { num[0], num[2], num[3] });
                listoffour.Add(new int[] { num[0], num[2], num[4] });
                listoffour.Add(new int[] { num[0], num[3], num[4] });
                listoffour.Add(new int[] { num[1], num[2], num[3] });
                listoffour.Add(new int[] { num[1], num[2], num[4] });
                listoffour.Add(new int[] { num[1], num[3], num[4] });
                listoffour.Add(new int[] { num[2], num[3], num[4] });
            }
            listoffour = listoffour.OrderBy(y => y[0]).ThenBy(y => y[1]).ThenBy(y => y[2]).ToList();
            int x = 0;
            int count = 1;
            List<int[]> numcoms = new List<int[]>();
            while (x < listoffour.Count() - 1)
            {
                if (
                    listoffour[x][0] == listoffour[x + 1][0]
                    && listoffour[x][1] == listoffour[x + 1][1]
                    && listoffour[x][2] == listoffour[x + 1][2]
                    )
                {
                    count++;
                }
                else
                {
                    numcoms.Add(new int[] { listoffour[x][0], listoffour[x][1], listoffour[x][2], count });
                    count = 1;
                }
                x++;
            }
            return numcoms.OrderByDescending(y => y[3]).ToList();
        }

        public List<int[]> KeepSingleHighFreqCombination(List<int[]> olist, int[] klist)
        {
            List<int[]> keeplist = new List<int[]>();
            int x = 0;
            while (x < olist.Count())
            {
                int matchcount = 0;
                int y = 0;
                while (y < klist.Count())
                {
                    if (olist[x].Contains(klist[y]))
                    {
                        matchcount++;
                    }
                    y++;
                }
                if (matchcount == 5)
                {
                    keeplist.Add(olist[x]);
                }
                x++;
            }
            return keeplist;
        }
        public List<int[]> GeneratePowerBall(int pool, List<int[]> previousdraw)
        {
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
                                    //CheckMatchesToint(new int[] { 34, 38, 50, 58, 65, 25, 20, 68, 52, 22, 55, 8, 44, 40, 16, 64, 49, 32, 14, 39, 57, 51, 9, 35, 15, 28, 33, 37, 6, 45 }, newnum, 5)
                                    //&&
                                    CheckCriteria(newnum)
                                    &&
                                    (!newnum.Contains(16) || !newnum.Contains(32) || !newnum.Contains(47))
                                    &&
                                    (newnum.Contains(1) || newnum.Contains(3) || newnum.Contains(8) || newnum.Contains(21) || newnum.Contains(23) || newnum.Contains(24) || newnum.Contains(35) || newnum.Contains(39) || newnum.Contains(51))
                                    &&
                                    !CheckFromPreviousDraw(previousdraw, newnum, new int[] { 3, 4, 5 })
                                    &&
                                    CheckFromPreviousDraw(previousdraw, newnum, new int[] { 2 })
                                    
                                    //&&
                                    //CheckFromPreviousDraw(
                                     //&& 
                                    //!CheckPreviousDraw(newnum, previous_filepath, new int[] {3, 4, 5}, 5)
                                //    ////(CheckMatchesToint(newnum, new int[] { 1, 2, 11, 18 }, 4) || CheckMatchesToint(newnum, new int[] { 1, 5, 20, 2 }, 4) || CheckMatchesToint(newnum, new int[] { 4, 9, 16, 17 }, 4))
                                //    ////&&
                                //    //(!CheckRange(newnum, 1, 9, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 10, 19, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 20, 29, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 30, 39, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 40, 49, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 50, 59, new int[] { 3, 4, 5 }) && !CheckRange(newnum, 60, 69, new int[] { 3, 4, 5 }))
                                //    //&&
                                //    //(CheckRange(newnum, 1, 9, new int[] { 2 }) || CheckRange(newnum, 10, 19, new int[] { 2 }) || CheckRange(newnum, 20, 29, new int[] { 2 }) || CheckRange(newnum, 30, 39, new int[] { 2 }) || CheckRange(newnum, 40, 49, new int[] { 2 }) || CheckRange(newnum, 50, 59, new int[] { 2 }) || CheckRange(newnum, 60, 69, new int[] { 2 }))
                                //    //&&
                                //    //(CheckFactor(newnum, 2, new int[] { 2, 3 }))
                                //    //&&
                                //    //(CheckFactor(newnum, 3, new int[] { 2, 1 }))
                                //    //&&
                                //    //(!CheckNumberEndings(newnum, new int[] { 4, 5 }))
                                //    //&&
                                //    //(AnalyzePrevious(newnum, previousdraw, 8, new int[] { 2, 3, 4, 5 }))
                                //    //&&
                                //    //(CheckPrimeMatches(newnum, new int[] { 1, 2 }))
                                //    //&&
                                //    //(!CheckPreviousDraw(newnum, previous_filepath, new int[] { 4, 5 }, 5))
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
    }
}
