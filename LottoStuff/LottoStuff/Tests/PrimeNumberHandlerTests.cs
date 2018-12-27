using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LottoStuff.Tests
{
    public class PrimeNumberHandlerTests
    {
        private PrimeNumberHandler primeNumberHandler;
        public PrimeNumberHandlerTests() 
        {
            primeNumberHandler = new PrimeNumberHandler(10);
        }


        [Fact]
        public void findsCorrectNumberOfPrimes()
        {
            Assert.Equal(4, primeNumberHandler.primeNumbersInDraw.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void isPrimeReturnsFalse(int testValue)
        {
            Assert.False(primeNumberHandler.isPrime(testValue));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void isPrimeReturnsTrue(int testValue)
        {
            Assert.True(primeNumberHandler.isPrime(testValue));
        }

        [Fact]
        public void isNumberInPrimeList()
        {
            Assert.False(primeNumberHandler.isNumberInPrimeList(1));
            Assert.True(primeNumberHandler.isNumberInPrimeList(2));
            Assert.True(primeNumberHandler.isNumberInPrimeList(3));
            Assert.False(primeNumberHandler.isNumberInPrimeList(4));
            Assert.True(primeNumberHandler.isNumberInPrimeList(5));
            Assert.False(primeNumberHandler.isNumberInPrimeList(6));
            Assert.True(primeNumberHandler.isNumberInPrimeList(7));
            Assert.False(primeNumberHandler.isNumberInPrimeList(8));
            Assert.False(primeNumberHandler.isNumberInPrimeList(9));
            Assert.False(primeNumberHandler.isNumberInPrimeList(10));
        }

        [Fact]
        public void getsCorrectNumberOfPrimesInRandomList()
        {
            List<int> numList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.True(primeNumberHandler.numberOfPrimesInList(numList) == 4);
        }

        [Fact]
        public void getFrequencyOfPrimesCollectionTest()
        {
            List<int> numlist1 = new List<int> { 1, 4, 6, 8 };
            List<int> numlist2 = new List<int> { 2, 4, 6, 8 };
            List<int> numlist3 = new List<int> { 2, 3, 6, 8 };
            List<int> numlist4 = new List<int> { 2, 3, 5, 8 };
            List<int> numlist5 = new List<int> { 2, 3, 5, 7 };
            List<List<int>> numcollection = new List<List<int>>();
            numcollection.Add(numlist1);
            numcollection.Add(numlist2);
            numcollection.Add(numlist3);
            numcollection.Add(numlist4);
            numcollection.Add(numlist5);

            Assert.Equal(1, primeNumberHandler.getFrequencyOfPrimesCollection(numcollection, 0));
            Assert.Equal(1, primeNumberHandler.getFrequencyOfPrimesCollection(numcollection, 1));
            Assert.Equal(1, primeNumberHandler.getFrequencyOfPrimesCollection(numcollection, 2));
            Assert.Equal(1, primeNumberHandler.getFrequencyOfPrimesCollection(numcollection, 3));
            Assert.Equal(1, primeNumberHandler.getFrequencyOfPrimesCollection(numcollection, 4));
        }
    }
}
