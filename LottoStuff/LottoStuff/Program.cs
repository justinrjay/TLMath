using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            lottofunctions lottoFunctions = new lottofunctions();
            //lottoFunctions.OutputListToCSV(lottoFunctions.SortListFromFile(@"D:\Users\hukto\Documents\lottotexas.csv", 0, 6), @"D:\Users\hukto\Documents\sortedlottotexas.csv");
            List<List<int>> sortedList = lottoFunctions.GetListFromFile(@"D:\Users\hukto\Documents\lottotexas.csv", 0, 6);
            LastDigitHandler lastDigitHandler = new LastDigitHandler(60);
            lastDigitHandler.endingDigit = 3;
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 0));
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 1));
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 2));
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 3));
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 4));
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 5));
            Console.WriteLine(lastDigitHandler.getFrequencyOfOccurrence(sortedList, 6));
            //NumberRemoval numberRemoval = new NumberRemoval(5, 35);
            //numberRemoval.FindFirstNumberWhereRangesChange();
            //List<int> rangeFrequenciesToRemove = new List<int>{ 4, 5 };
            //Console.WriteLine(numberRemoval.cleanNumList.Count);
            //numberRemoval.CleanNumberList(rangeFrequenciesToRemove);
            //Console.WriteLine(numberRemoval.cleanNumList.Count);
            //LottoCsvFileHandling lcsv = new LottoCsvFileHandling(@"C:\Users\Fonix\Downloads\lottotexas.csv");
            //LottoComparison lc = new LottoComparison(54, 6);
            //int numberFailed = 0;
            //foreach (List<int> lottoDraw in lcsv.SortedList)
            //{
            //    if (lc.IsNumberDisqualifed(lottoDraw))
            //        numberFailed++;
            //}
            //Console.WriteLine(numberFailed);
            //Console.WriteLine(lcsv.SortedList.Count);
        }
        
        static void WriteTable(LottoOddsTable lot)
        {
            Console.WriteLine(lot.numDrawn + " " + lot.numPossible + " " + lot.percentChance);
        }
        
    }
}
