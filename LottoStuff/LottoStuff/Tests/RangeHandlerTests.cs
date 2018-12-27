using System.Collections.Generic;
using Xunit;

namespace LottoStuff.Tests
{
    public class RangeHandlerTests
    {
        private RangeHandler rangeHandler;
        public RangeHandlerTests()
        {
            rangeHandler = new RangeHandler(60);
        }

        [Fact]
        public void getsCorrectNumberOfRanges()
        {
            Assert.Equal(7, rangeHandler.numberOfRanges);
        }

        [Theory]
        [InlineData(0)]
        public void setsCorrectRangesForLessThanTen(int value)
        {
            List<int> newRange = rangeHandler.buildRange(value);
            Assert.Equal(1, newRange[0]);
            Assert.Equal(9, newRange[8]);
            Assert.Equal(9, newRange.Count);
            Assert.DoesNotContain(0, newRange);
        }

        [Theory]
        [InlineData(1)]
        public void setsCorrectRangesForTen(int value)
        {
            List<int> newRange = rangeHandler.buildRange(value);
            Assert.Equal(10, newRange[0]);
            Assert.Equal(19, newRange[9]);
            Assert.Equal(10, newRange.Count);
        }

        [Theory]
        [InlineData(6)]
        public void setsCorrectRangesForOnlyOneInRange(int value)
        {
            List<int> newRange = rangeHandler.buildRange(value);
            Assert.Equal(60, newRange[0]);
            Assert.Single(newRange);
        }

        [Fact]
        public void rangesAreBuiltCorrectly()
        {
            Assert.True(rangeHandler.rangeLists.Count == 7);
            Assert.True(rangeHandler.rangeLists[0].Count == 9);
            Assert.True(rangeHandler.rangeLists[1].Count == 10);
            Assert.True(rangeHandler.rangeLists[2].Count == 10);
            Assert.True(rangeHandler.rangeLists[3].Count == 10);
            Assert.True(rangeHandler.rangeLists[4].Count == 10);
            Assert.True(rangeHandler.rangeLists[5].Count == 10);
            Assert.True(rangeHandler.rangeLists[6].Count == 1);
        }

        [Fact]
        public void getRangeCountsOfDrawNumber()
        {
            List<int> num1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> num2 = new List<int> { 1, 11, 21, 31, 41, 51 };
            List<int> num3 = new List<int> { 1, 11, 12, 23, 24, 60 };

            List<int> count1 = rangeHandler.getCountsOfNumbersInRanges(num1);
            List<int> count2 = rangeHandler.getCountsOfNumbersInRanges(num2);
            List<int> count3 = rangeHandler.getCountsOfNumbersInRanges(num3);

            Assert.True(count1[0] == 6);
            Assert.True(count1[1] == 0);
            Assert.True(count1[2] == 0);
            Assert.True(count1[3] == 0);
            Assert.True(count1[4] == 0);
            Assert.True(count1[5] == 0);
            Assert.True(count1[6] == 0);

            Assert.True(count2[0] == 1);
            Assert.True(count2[1] == 1);
            Assert.True(count2[2] == 1);
            Assert.True(count2[3] == 1);
            Assert.True(count2[4] == 1);
            Assert.True(count2[5] == 1);
            Assert.True(count2[6] == 0);

            Assert.True(count3[0] == 1);
            Assert.True(count3[1] == 2);
            Assert.True(count3[2] == 2);
            Assert.True(count3[3] == 0);
            Assert.True(count3[4] == 0);
            Assert.True(count3[5] == 0);
            Assert.True(count3[6] == 1);
        }

        [Fact]
        public void checkIfAnyRangeOccursSpecificNumberOfTimesTest()
        {
            List<int> numlist1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> numlist2 = new List<int> { 1, 2, 3, 4, 5, 60 };
            List<int> numlist3 = new List<int> { 1, 2, 3, 4, 50, 60 };
            List<int> numlist4 = new List<int> { 1, 2, 3, 50, 51, 60 };

            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 6));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 0));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 1));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 2));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 3));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 4));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist1, 5));

            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 5));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 0));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 1));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 2));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 3));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 4));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist2, 6));

            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 4));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 1));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 0));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 2));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 3));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 5));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist3, 6));

            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 3));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 2));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 0));
            Assert.True(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 1));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 4));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 5));
            Assert.False(rangeHandler.checkIfAnyRangeOccursSpecificNumberOfTimes(numlist4, 6));
        }

        [Fact]
        public void getSpecificFrequencyForRangesTest()
        {
            List<int> numlist1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> numlist2 = new List<int> { 1, 2, 3, 4, 5, 60 };
            List<int> numlist3 = new List<int> { 1, 2, 3, 4, 50, 60 };
            List<int> numlist4 = new List<int> { 1, 2, 3, 50, 51, 60 };
            List<List<int>> numlistcollection = new List<List<int>>();
            numlistcollection.Add(numlist1);
            numlistcollection.Add(numlist2);
            numlistcollection.Add(numlist3);
            numlistcollection.Add(numlist4);

            Assert.Equal(4, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 0));
            Assert.Equal(3, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 1));
            Assert.Equal(1, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 2));
            Assert.Equal(1, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 3));
            Assert.Equal(1, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 4));
            Assert.Equal(1, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 5));
            Assert.Equal(1, rangeHandler.getSpecificFrequencyForRanges(numlistcollection, 6));
        }
    } 
}
