using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class LottoBaseClass : LottoBase
    {
        public int NumbersInDraw { get; set; }
        public int NumbersDrawn { get; set; }

        public int HighFactor { get { return NumbersInDraw / NumbersDrawn; } }
        
    }
}
