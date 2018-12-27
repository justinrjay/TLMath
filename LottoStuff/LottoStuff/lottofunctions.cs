using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LottoStuff
{
    public class lottofunctions
    {
        public List<int[]> returnmatch(List<int[]> checklist, int[] disqualifiers, int matchamount)
        {
            List<int[]> returnlist = new List<int[]>();
            int startindex = 0;
            while (startindex < checklist.Count)
            {
                int x = 0;
                int containcount = 0;
                while (x < disqualifiers.Length)
                {
                    if (checklist[startindex].Contains(disqualifiers[x])) { containcount++; }
                    x++;
                }
                if (containcount >= matchamount)
                {
                    returnlist.Add(checklist[startindex]);
                }
                startindex++;
            }
            return returnlist;
        }

        public void RemoveMatches(List<int[]> checklist, int[] disqualifiers, int matchamount)
        {
            int startindex = 0;
            while (startindex < checklist.Count)
            {
                int containcount = 0;
                int x = 0;
                while (x < disqualifiers.Length)
                {
                    if (checklist[startindex].Contains(disqualifiers[x])) { containcount++; }
                    if (containcount >= matchamount) { break; }
                    x++;
                }
                if (containcount >= matchamount)
                {
                    checklist.RemoveAt(startindex);
                }
                else
                {
                    startindex++;
                }
            }
        }

        public void CompareTwoLists(List<int[]> checklist, List<int[]> disqualifierlist, int matchamount)
        {
            foreach (int[] disqualifiers in disqualifierlist)
            {
                RemoveMatches(checklist, disqualifiers, matchamount);
            }
        }
        public void OutputListToCSV(List<int[]> numlist, string filepath)
        {
            var csv = new StringBuilder();
            foreach (int[] sortedlist in numlist)
            {
                int x = 0;
                string newline = "";
                while (x < sortedlist.Length)
                {
                    newline += x == sortedlist.Length - 1 ? sortedlist[x].ToString() : sortedlist[x].ToString() + ",";
                    x++;
                }
                csv.AppendLine(newline);
            }
            File.WriteAllText(filepath, csv.ToString());
        }

        public List<int[]> SortListFromFile(string filepath, int startindex, int numvalues)
        {
            var reader = new StreamReader(File.OpenRead(filepath));
            List<int[]> numlist = new List<int[]>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                int x = 0;
                int[] newarray = new int[numvalues];
                while (x < numvalues)
                {
                    newarray[x] = Convert.ToInt16(values[startindex + x]);
                    x++;
                }
                Array.Sort(newarray);
                numlist.Add(newarray);
            }
            return numlist;
        }

        public List<List<int>> GetListFromFile(string filepath, int startindex, int numvalues)
        {
            var reader = new StreamReader(File.OpenRead(filepath));
            List<List<int>> numlist = new List<List<int>>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                int x = 0;
                List<int> newList = new List<int>();
                while (x < numvalues)
                {
                   newList.Add(Convert.ToInt16(values[startindex + x]));
                    x++;
                }
                numlist.Add(newList);
            }
            return numlist;
        }

        public List<int[]> GenerateFour(int pool)
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
                            numlist.Add(new int[] { num1, num2, num3, num4 });
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

        public List<int[]> GenerateFive(int pool)
        {
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

        public List<int[]> GenerateSix(int pool)
        {
            List<int[]> numlist = new List<int[]>();
            int num1 = 1;
            while (num1 <= pool - 5)
            {
                int num2 = num1 + 1;
                while (num2 <= pool - 4)
                {
                    int num3 = num2 + 1;
                    while (num3 <= pool - 3)
                    {
                        int num4 = num3 + 1;
                        while (num4 <= pool - 2)
                        {
                            int num5 = num4 + 1;
                            while (num5 <= pool - 1)
                            {
                                int num6 = num5 + 1;
                                while (num6 <= pool)
                                {
                                    numlist.Add(new int[] { num1, num2, num3, num4, num5, num6 });
                                    num6++;
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

        public bool CheckNumberEndings(int[] numlist, int[] matches)
        {
            int[] endinglist = new int[numlist.Length];
            int x = 0;
            while (x < numlist.Length)
            {
                endinglist[x] = numlist[x] % 10;
                x++;
            }
            var dictionary = new Dictionary<int, int>();

            foreach (int n in endinglist)
            {
                if (!dictionary.ContainsKey(n))
                    dictionary[n] = 0;
                dictionary[n]++;
            }

            bool numberendingsmatch = false;
            foreach (var pair in dictionary)
            {
                if (matches.Contains(pair.Value))
                {
                    numberendingsmatch = true;
                    break;
                }
            }
            return numberendingsmatch;
        }

        public bool CheckOldMatches(int[] numlist, int[] checklist, int[] matches)
        {
            int matchcount = 0;
            int x = 0;
            while (x < numlist.Length)
            {
                int y = 0;
                while (y < checklist.Length)
                {
                    if (numlist[x] == checklist[y])
                    {
                        matchcount++;
                        break;
                    }
                    y++;
                }
                x++;
            }
            return matches.Contains(matchcount);
        }

        public List<int> NumberFrequency(List<int[]> comparelist, int comparenum)
        {
            int x = 0;
            List<int> frequencyindex = new List<int>();
            while (x < comparelist.Count())
            {
                if (comparelist[x].Contains(comparenum))
                {
                    frequencyindex.Add(x);
                }
                x++;
            }
            return frequencyindex;
        }
        
        public int NumberFrequencyCount(List<int[]> comparelist, int comparenum)
        {
            return NumberFrequency(comparelist, comparenum).Count();
        }

        public List<int[]> NumberFrequencyCountSorted(List<int[]> comparelist, int pool)
        {
            int x = 1;
            List<int[]> frequencies = new List<int[]>();
            while (x < pool)
            {
                frequencies.Add(new int[] { x, NumberFrequencyCount(comparelist, x) });
                x++;
            }
            return frequencies.OrderByDescending(y => y[1]).ToList();
        }

        public List<int> FrequencyDifference(List<int[]> comparelist, int comparenum)
        {
            List<int> frequencyindex = NumberFrequency(comparelist, comparenum);
            List<int> frequencydifference = new List<int>();
            int x = frequencyindex.Count - 1;
            while (x > 0)
            {
                frequencydifference.Add(frequencyindex[x] - frequencyindex[x - 1]);
                x--;
            }
            return frequencydifference;
        }

        public int FrequencyAverage(List<int[]> comparelist, int comparenum)
        {
            List<int> frequencydifference = FrequencyDifference(comparelist, comparenum);
            int frequencyaverage = 0;
            foreach (int diff in frequencydifference)
            {
                frequencyaverage += diff;
            }
            return frequencydifference.Count() > 0 ? frequencyaverage / frequencydifference.Count() : 99999;
        }

        public int FrequencyMode(List<int[]> comparelist, int comparenum)
        {
            List<int> frequencydifference = FrequencyDifference(comparelist, comparenum);
            int mode = frequencydifference.GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
            return mode;
        }

        public bool IsInPreviousDrawings(int[] numlist, int numdraws, List<int[]> comparelist)
        {
            int x = comparelist.Count - 1;
            int y = 1;
            List<int[]> lastresults = new List<int[]>();
            while (y <= numdraws)
            {
                lastresults.Add(comparelist[x - y]);
                y++;
            }
            return true;
        }

        public void AnalyzePreviousResults(List<int[]> previousdraws)
        {
            List<int[]> howmanyindraw = new List<int[]>();
            int x = 0;
            while (x < previousdraws.Count())
            {
                int y = 0;
                int count = 0;
                while (y < previousdraws[x].Length)
                {
                    if (previousdraws[x][y] > 0)
                    {
                        count++;
                    }
                    y++;
                }
                howmanyindraw.Add(new int[] { count });
                x++;
            }
            OutputListToCSV(howmanyindraw, @"G:\PowerBall\previousresultsanalyzed.csv");
        }

        public bool AnalyzePrevious(int[] num, List<int[]> previousresults, int increment, int[] matches)
        {
            int x = previousresults.Count - 1;
            int y = 0;
            List<int[]> lastresults = new List<int[]>();
            while (y < increment)
            {
                lastresults.Add(previousresults[x - y]);
                y++;
            }
            int[] newfreq = new int[num.Length];
            y = 0;
            int count = 0;
            while (y < newfreq.Length)
            {
                if(NumberFrequency(lastresults, num[y]).Count() > 0)
                {
                    count++;
                }
                y++;
            }
            return matches.Contains(count);
        }

        public bool CheckPreviousDraw(int[] numlist, string previous_filepath, int[] matches, int numvalues)
        {
            var checklist = SortListFromFile(previous_filepath, 0, numvalues);
            bool matchesprevious = false;
            foreach (var check in checklist)
            {
                if (CheckOldMatches(numlist, check, matches))
                {
                    matchesprevious = true;
                    break;
                }
            }
            return matchesprevious;
        }

        public bool CheckGenericMatches(int[] numlist, List<int[]> checklist, int matches)
        {
            int matchcount = 0;
            foreach (var check in checklist)
            {
                int x = 0;
                while (x < check.Length)
                {
                    if (numlist.Contains(check[x]))
                    {
                        matchcount++;
                    }
                    x++;
                }
                if (matches == matchcount)
                {
                    break;
                }
            }
            return matches == matchcount;
        }
        public bool CheckMatches(int[] numlist, List<int[]> checklist, int[] matches)
        {
            int matchcount = 0;
            foreach (var check in checklist)
            {
                int x = 0;
                while (x < check.Length)
                {
                    if (numlist.Contains(check[x]))
                    {
                        matchcount++;
                    }
                    x++;
                }
                
            }
            return matches.Contains(matchcount);
        }
        public bool CheckMatchesToint(int[] numlist, int[] check, int matches)
        {
            int matchcount = 0;
            int x = 0;
            while (x < numlist.Length)
            {
                int y = 0;
                while (y < check.Length)
                {
                    if(numlist[x] == check[y])
                    {
                        matchcount++;
                    }
                    y++;
                }
                x++;
            }
            return matchcount == matches;
        }

        public bool CheckFromPreviousDraw(List<int[]> previousnums, int[] newnum, int[] matches)
        {
            int x = 0;
            while (x < previousnums.Count())
            {
                int y = 0;
                int matchcount = 0;
                while (y < previousnums[x].Length)
                {
                    if (newnum.Contains(previousnums[x][y])) { matchcount++; }
                    y++;
                    
                }
                if (matches.Contains(matchcount)) { return true; }
                else { x++; }
            }
            return false;
        }

        public List<int[]> KeepIfInAnotherList(List<int[]> originallist, List<int[]> removelist, int[] matches)
        {
            List<int[]> keeplist = new List<int[]>();
            foreach (var newnum in originallist)
            {
                if (CheckFromPreviousDraw(removelist, newnum, matches))
                {
                    keeplist.Add(newnum);
                }
            }
            return keeplist;
        }
    }
}
