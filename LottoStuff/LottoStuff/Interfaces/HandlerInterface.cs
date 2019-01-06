using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public interface HandlerInterface
    {
        bool checkFrequency(List<int> drawNumber, int[] frequenciesToCheck);
        int getFrequencyOfOccurrence(List<List<int>> drawcollection, int numberOfOccurrencesToCheck);
    }
}
