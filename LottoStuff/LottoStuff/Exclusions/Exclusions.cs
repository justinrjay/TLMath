using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class Exclusions
    {
        public int[] rangeFrequencyExclusions { get; set; } = new int[0];
        public int[] primeNumberFrequencyExclusions { get; set; } = new int[0];
        public Dictionary<int, int[]> multipleExclusions { get; set; } = new Dictionary<int, int[]>();
        public int[] lastDigitExclusions { get; set; } = new int[0];
        public Exclusions()
        {
            
        }

        public Exclusions(int[] rangeFrequencyExclusions, int[] primeNumberFrequencyExclusions, Dictionary<int, int[]> multipleExclusions, int[] lastDigitExclusions)
        {
            this.rangeFrequencyExclusions = rangeFrequencyExclusions;
            this.primeNumberFrequencyExclusions = primeNumberFrequencyExclusions;
            this.multipleExclusions = multipleExclusions;
            this.lastDigitExclusions = lastDigitExclusions;
        }
    }
}
