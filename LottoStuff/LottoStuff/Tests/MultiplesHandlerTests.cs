using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LottoStuff.Tests
{
    public class MultiplesHandlerTests
    {
        private MultiplesHandler multiplesHandler;
        public MultiplesHandlerTests()
        {
            multiplesHandler = new MultiplesHandler(60);
        }

        [Theory]
        [InlineData(2, 6)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 1)]
        [InlineData(6, 2)]
        public void testMultipleCount(int divisor, int result)
        {
            List<int> numlist = new List<int> { 2, 4, 6, 8, 10, 12 };
            multiplesHandler.MultipleDivisor = divisor;
            Assert.Equal(result, multiplesHandler.getCountOfMultiplesInNumberList(numlist));
        }
    }
}
