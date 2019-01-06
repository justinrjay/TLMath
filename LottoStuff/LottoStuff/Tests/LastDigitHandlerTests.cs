using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LottoStuff.Tests
{
    public class LastDigitHandlerTests
    {
        public LastDigitHandlerTests()
        {

        }

        [Theory]
        [InlineData(60, 1, new int[] { 1, 11, 21, 31, 41, 51 })]
        [InlineData(30, 1, new int[] { 1, 11, 21 })]
        [InlineData(40, 2, new int[] { 2, 12, 22, 32 })]
        [InlineData(60, 0, new int[] { 10, 20, 30, 40, 50, 60 })]
        public void testThatEndingListBuildsCorrectly(int poolsize, int endingDigit, int[] result)
        {
            List<int> resultList = result.ToList();
            LastDigitHandler lastDigitHandler = new LastDigitHandler(poolsize);
            lastDigitHandler.endingDigit = endingDigit;
            Assert.Equal(result, lastDigitHandler.endingDigitNumberList);
        }

        [Theory]
        [InlineData(60, 1, new int[] { 1, 11, 21, 31, 41, 51 }, 6)]
        [InlineData(30, 1, new int[] { 1, 13, 21 }, 2)]
        [InlineData(40, 2, new int[] { 3, 6, 9, 15 }, 0)]
        [InlineData(60, 0, new int[] { 10, 20, 30, 40, 50 }, 5)]
        [InlineData(60, 0, new int[] { 11, 21, 31, 41, 50 }, 1)]
        public void numberOfEndingDigitsThatMatchFromNumberTest(int poolsize, int endingDigit, int[] drawingNumber, int result)
        {
            List<int> drawingNumberList = drawingNumber.ToList();
            LastDigitHandler lastDigitHandler = new LastDigitHandler(poolsize);
            lastDigitHandler.endingDigit = endingDigit;
            Assert.Equal(result, lastDigitHandler.numberOfEndingDigitsThatMatchFromNumber(drawingNumberList));
        }

        [Fact]
        public void getFrequencyOfOccurrenceTest()
        {
            LastDigitHandler lastDigitHandler = new LastDigitHandler(60);
            List<int> test1 = new List<int> { 1, 11, 21, 22, 32, 43 };
            List<int> test2 = new List<int> { 5, 7, 9, 11, 13, 15 };
            List<int> test3 = new List<int> { 1, 11, 21, 23, 32, 43 };
            List<int> test4 = new List<int> { 5, 15, 25, 35, 45, 55 };
            List<List<int>> testCollection = new List<List<int>> { test1, test2, test3, test4 };

            lastDigitHandler.endingDigit = 1;
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 6));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 5));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 4));
            Assert.Equal(2, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 3));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 2));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 1));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 0));

            lastDigitHandler.endingDigit = 2;
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 6));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 5));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 4));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 3));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 2));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 1));
            Assert.Equal(2, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 0));

            lastDigitHandler.endingDigit = 3;
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 6));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 5));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 4));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 3));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 2));
            Assert.Equal(2, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 1));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 0));

            lastDigitHandler.endingDigit = 5;
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 6));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 5));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 4));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 3));
            Assert.Equal(1, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 2));
            Assert.Equal(0, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 1));
            Assert.Equal(2, lastDigitHandler.getFrequencyOfOccurrence(testCollection, 0));
        }

        [Theory]
        [InlineData(new int[] { 1, 11, 21, 31, 41, 51 }, new int[] { 5, 6 }, true )]
        [InlineData(new int[] { 1, 12, 22, 31, 41, 51 }, new int[] { 5, 6 }, false)]
        [InlineData(new int[] { 1, 12, 22, 31, 41, 51 }, new int[] { 4 }, true)]
        public void checkFrequencyOfEndingDigitTest(int[] drawNumber, int[] frequencies, bool result)
        {
            List<int> drawNumberList = drawNumber.ToList();
            LastDigitHandler lastDigitHandler = new LastDigitHandler(60);
            lastDigitHandler.endingDigit = 1;
            Assert.Equal(result, lastDigitHandler.checkFrequency(drawNumberList, frequencies));
        }
        
    }
}
