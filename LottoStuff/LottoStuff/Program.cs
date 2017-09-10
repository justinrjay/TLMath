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
            LottoCsvFileHandling lcsv = new LottoCsvFileHandling(@"C:\Users\Fonix\Downloads\lottotexas.csv");
            LottoComparison lc = new LottoComparison(54, 6);
            int numberFailed = 0;
            foreach (List<int> lottoDraw in lcsv.SortedList)
            {
                if (lc.IsNumberDisqualifed(lottoDraw))
                    numberFailed++;
            }
            Console.WriteLine(numberFailed);
            Console.WriteLine(lcsv.SortedList.Count);
        }

        static void WriteTable(LottoOddsTable lot)
        {
            Console.WriteLine(lot.numDrawn + " " + lot.numPossible + " " + lot.percentChance);
        }
        
    }
}
