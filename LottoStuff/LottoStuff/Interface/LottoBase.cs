using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    interface LottoBase
    {
        int NumbersInDraw { get; set; }
        int NumbersDrawn { get; set; }
        int HighFactor { get; }
    }
}
