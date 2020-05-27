using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Tests
{
    class AdvancedTest : AbstractBaseTest
    {
        [Params(K100, M10, B1)] 
        public int N { get; set; }

        [Params(8, 32, 64)]
        public int K { get; set; }

        [Params(K100, M10, B1)] 
        public int NumberOfOperations { get; set; }

        [Params(5,50,95)]
        public int PercentOfQueryOperations { get; set; }

        [Params(PlainArray, FenwickTree)]
        public PartialSumDataStructure DataStructureType { get; set; }

        [Benchmark]
        public void DoTest()
        {
            base.ExecuteTest();
        }

        [IterationSetup]
        public void TestSetup()
        {
            base.InitializeVariablesBeforeTest();
        }
    }
}
