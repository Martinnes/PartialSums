using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Tests
{
    public class ByteFenwickTests : AbstractPartialSumTests
    {
        protected override ITestablePartialSumDataStructure GetDataStructure(int size)
        {
            return new ByteFenwickSum(size);
        }
    }
}
