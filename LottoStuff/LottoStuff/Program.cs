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
            LottoComparison lc = new LottoComparison(54, 6);
            List<int> draw1 = new List<int> { 3, 6, 9, 12, 15, 18 };
            Console.WriteLine(lc.FactorsDisqualified(draw1));
        }

        static void WriteTable(LottoOddsTable lot)
        {
            Console.WriteLine(lot.numDrawn + " " + lot.numPossible + " " + lot.percentChance);
        }
        
    }
}
