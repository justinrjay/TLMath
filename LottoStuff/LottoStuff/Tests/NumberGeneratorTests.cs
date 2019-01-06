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
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, false);
            Assert.Equal(result, numberGenerator.numberCollection.Count);
        }

        [Theory]
        [InlineData(5, 35, 324632)]
        [InlineData(4, 35, 52360)]
        public void testingThatRangesAreRemovedCorrectly(int drawSize, int drawPool, int result)
        {
            RangeHandler rangeHandler = new RangeHandler(drawPool);
            NumberGenerator numberGenerator = new NumberGenerator(drawSize, drawPool);
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, false);
            Exclusions rangeExclusions = new Exclusions();
            rangeExclusions.rangeFrequencyExclusions = new int[] { 4, 5 };
            numberGenerator.exclusions = rangeExclusions;
            int rangeToRemove1 = rangeHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, 4);
            int rangeToRemove2 = rangeHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, 5);

            numberGenerator.numberCollection = new List<List<int>>();
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, true);
            result = result - rangeToRemove1 - rangeToRemove2;
            Assert.Equal(result, numberGenerator.numberCollection.Count);
        }

        [Theory]
        [InlineData(5, 35, 324632)]
        [InlineData(4, 35, 52360)]
        public void testingThatPrimesAreRemovedCorrectly(int drawSize, int drawPool, int result)
        {
            PrimeNumberHandler primeNumberHandler = new PrimeNumberHandler(drawPool);
            NumberGenerator numberGenerator = new NumberGenerator(drawSize, drawPool);
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, false);
            Exclusions primeExclusions = new Exclusions();
            primeExclusions.primeNumberFrequencyExclusions = new int[] { 4, 5 };
            numberGenerator.exclusions = primeExclusions;
            int numRemoved = primeNumberHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, 4)
                + primeNumberHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, 5);
            numberGenerator.numberCollection = new List<List<int>>();
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, true);
            result = result - numRemoved;
            Assert.Equal(result, numberGenerator.numberCollection.Count);
        }

        [Theory]
        [InlineData(5, 35, 324632, 2, new int[] { 4, 5 })]
        [InlineData(4, 35, 52360, 2, new int[] { 4, 5 })]
        [InlineData(5, 35, 324632, 3, new int[] { 4, 5 })]
        [InlineData(4, 35, 52360, 3, new int[] { 4, 5 })]
        public void testingThatMultiplesAreRemovedCorrectly(int drawSize, int drawPool, int result, int divisor, int[] frequency)
        {
            MultiplesHandler multiplesHandler = new MultiplesHandler(60);
            NumberGenerator numberGenerator = new NumberGenerator(drawSize, drawPool);
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, false);
            Exclusions multipleExclusions = new Exclusions();
            Dictionary<int, int[]> multipleExclusionsToRemove = new Dictionary<int, int[]>();
            multipleExclusionsToRemove.Add(divisor, frequency);
            multipleExclusions.multipleExclusions = multipleExclusionsToRemove;
            numberGenerator.exclusions = multipleExclusions;
            multiplesHandler.MultipleDivisor = divisor;
            int numRemoved = multiplesHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, 4) +
                multiplesHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, 5);
            numberGenerator.numberCollection = new List<List<int>>();
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, true);
            result = result - numRemoved;
            Assert.Equal(result, numberGenerator.numberCollection.Count);
        }

        [Theory]
        [InlineData(5, 35, 324632, new int[] { 4, 5 })]
        [InlineData(4, 35, 52360, new int[] { 3, 4 })]
        public void testingThatLastDigitsRemovedCorrectly(int drawSize, int drawPool, int result, int[] frequency)
        {
            LastDigitHandler lastDigitHandler = new LastDigitHandler(drawPool);
            NumberGenerator numberGenerator = new NumberGenerator(drawSize, drawPool);
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, false);
            Exclusions lastDigitExclusions = new Exclusions();
            lastDigitExclusions.lastDigitExclusions = frequency;
            numberGenerator.exclusions = lastDigitExclusions;
            int numRemoved = 0;
            for (int i = 0; i < 10; i++)
            {
                lastDigitHandler.endingDigit = i;
                numRemoved += lastDigitHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, frequency[0]);
                numRemoved += lastDigitHandler.getFrequencyOfOccurrence(numberGenerator.numberCollection, frequency[1]);
            }
            numberGenerator.numberCollection = new List<List<int>>();
            numberGenerator.generateList(new List<int>(), 0, 1, numberGenerator.highestStartPoint, true);
            result = result - numRemoved;
            Assert.Equal(result, numberGenerator.numberCollection.Count);
        }
    }
}
