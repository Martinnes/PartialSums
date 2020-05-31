using PartialSums.Data_Structures;
using System;
using Xunit;

namespace PartialSums.Tests
{
    public abstract class AbstractPartialSumTests
    {
        protected abstract ITestablePartialSumDataStructure GetDataStructure(int size);
        
        private int index = 5;
        private int indexBefore = 4;
        private int indexAfter = 6;
        private int size = 10;
        private int delta = 20;

        [Fact]
        public void Increase_SpecificIndexWithDelta_IndexValueShouldBeOldPlusDelta()
        {
            //Arrange
            ITestablePartialSumDataStructure ds = GetDataStructure(size);
            int initialValue = ds.Sum(index);

            //Act
            ds.Increase(index, delta);

            //Assert
            int valueAfterIncrease = ds.Sum(index);
            Assert.Equal(valueAfterIncrease, initialValue + delta);
        }

        [Fact]
        public void Increase_SpecificIndexWithDelta_IndexAfterShouldBeOldPlusDelta()
        {
            //Arrange
            ITestablePartialSumDataStructure ds = GetDataStructure(size);
            int initialValue = ds.Sum(indexAfter);

            //Act
            ds.Increase(index, delta);

            //Assert
            int valueAfterIncrease = ds.Sum(indexAfter);
            Assert.Equal(valueAfterIncrease, initialValue + delta);
        }

        [Fact]
        public void Increase_SpecificIndexWithDelta_IndexBeforeShouldNotBeChanged()
        {
            //Arrange
            ITestablePartialSumDataStructure ds = GetDataStructure(size);
            int initialValue = ds.Sum(indexBefore);

            //Act
            ds.Increase(index, delta);

            //Assert
            int valueAfterIncrease = ds.Sum(indexBefore);
            Assert.Equal(valueAfterIncrease, initialValue);
        }


    }
}
