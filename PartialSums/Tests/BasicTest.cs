using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Engines;
using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Tests
{


    [MemoryDiagnoser]
    //[InliningDiagnoser(logFailuresOnly:true,filterByNamespace:true)]
    [NativeMemoryProfiler]
    [SimpleJob(RunStrategy.Monitoring,targetCount:3)]
    public class BasicTest : AbstractBaseTest
    {
        [Params(K100, M10)]
        public override int N { get; set; }

        [Params(8, 32, 64)]
        public override int K { get; set; }

        [Params(K100)]
        public override int NumberOfOperations { get; set; }

        [Params(50)]
        public override int PercentOfQueryOperations { get; set; }

        [Params(PartialSumDataStructure.PlainArray, PartialSumDataStructure.FenwickTree, PartialSumDataStructure.CompleteBinaryTree)]
        public override PartialSumDataStructure DataStructureType { get; set; }

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
