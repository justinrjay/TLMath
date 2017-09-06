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
            LottoNumberGeneration lng = new LottoNumberGeneration();
            Console.WriteLine(lng.NumberPool.Count);
        }

        static void WriteTable(LottoOddsTable lot)
        {
            Console.WriteLine(lot.numDrawn + " " + lot.numPossible + " " + lot.percentChance);
        }
        
    }
}
