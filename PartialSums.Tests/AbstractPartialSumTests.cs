using PartialSums.Data_Structures;
using System;
using Xunit;

namespace PartialSums.Tests
{
    public abstract class AbstractPartialSumTests
    {
        protected abstract ITestablePartialSumDataStructure GetDataStructure(int size);

        [Theory]
        [InlineData(5,10,20)]
        [InlineData(13, 33, 10)]
        [InlineData(42, 43, 3)]
        public void Increase_SpecificIndexWithDelta_IndexValueShouldBeOldPlusDelta(int index, int dataStructureSize, byte delta)
        {
            if (!(index < dataStructureSize))
            {
                throw new ArgumentException("Index has to be lower than data structure size");
            }
            //Arrange
            ITestablePartialSumDataStructure ds = GetDataStructure(dataStructureSize);
            int initialValue = ds.Sum(index);

            //Act
            ds.Increase(index, delta);

            //Assert
            int valueAfterIncrease = ds.Sum(index);
            Assert.Equal(valueAfterIncrease, initialValue + delta);
        }

        [Theory]
        [InlineData(17, 18, 20, 10)]
        [InlineData(1, 18, 20, 10)]
        public void Increase_SpecificIndexWithDelta_IndexAfterShouldBeOldPlusDelta(int index, int indexAfter, int dataStructureSize, byte delta)
        {
            if (!(indexAfter > index))
            {
                throw new ArgumentException("IndexAfter needs to be larger than index");
            }
            if (!(index < dataStructureSize))
            {
                throw new ArgumentException("Index has to be lower than data structure size");
            }

            //Arrange
            ITestablePartialSumDataStructure ds = GetDataStructure(dataStructureSize);
            int initialValue = ds.Sum(indexAfter);

            //Act
            ds.Increase(index, delta);

            //Assert
            int valueAfterIncrease = ds.Sum(indexAfter);
            Assert.Equal(valueAfterIncrease, initialValue + delta);
        }

        [Theory]
        [InlineData(17, 16, 20, 10)]
        [InlineData(15, 1, 37, 10)]
        public void Increase_SpecificIndexWithDelta_IndexBeforeShouldNotBeChanged(int index, int indexBefore, int dataStructureSize, byte delta)
        {
            if (!(indexBefore < index))
            {
                throw new ArgumentException("IndexBefore needs to be less than index");
            }
            if (!(index < dataStructureSize))
            {
                throw new ArgumentException("Index has to be lower than data structure size");
            }
            //Arrange
            ITestablePartialSumDataStructure ds = GetDataStructure(dataStructureSize);
            int initialValue = ds.Sum(indexBefore);

            //Act
            ds.Increase(index, delta);

            //Assert
            int valueAfterIncrease = ds.Sum(indexBefore);
            Assert.Equal(valueAfterIncrease, initialValue);
        }


    }
}
