using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LottoStuff.Tests
{
    public class NumberGeneratorTests
    {
        public NumberGeneratorTests()
        {
            
        }

        [Theory]
        [InlineData(5, 35, 324632)]
        [InlineData(4, 35, 52360)]
        public void shouldGenerateCorrectAmountOfDrawingNumbers(int drawSize, int drawPool, int result)
        {
            NumberGenerator numberGenerator = new NumberGenerator(drawSize, drawPool);
            Assert.Equal(result, numberGenerator.numberCollection.Count);
        }
    }
}
