using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    [MemoryDiagnoser]
    public class TestRunner
    {
        private IIntegerPartialSumDataStructure ds;
        private readonly Random Random = new Random(42);

        [Params(1000, 1000000, 1000000000/*, 10000, 100000*/)]
        public int N { get; set; }

        [Params(32)]
        public int K { get; set; }

        [Params(/*1000,*/ 10000/*, 100000*/)]
        public int NumberOfOperations { get; set; }

        [Params(/*5, 50, */95)]
        public int PercentOfQueryOperations { get; set; }

        public const string PlainArray = "Plain Array";

        public const string FenwickTree = "Fenwick Tree";

        [Params(PlainArray/*,FenwickTree*/)]
        public string DataStructure { get; set; }

        //public IEnumerable<IIntegerPartialSumDataStructure>

        [Benchmark]
        public void DoTest()
        {
            //ds = new IntegerFenwickSum(N);
            //Todo: this should not be part of test, but should be preprocessing
            /*if (DataStructure.Equals(PlainArray))
            {
                ds = new IntegerPlainArray();
            }
            else
            {
                ds = new IntegerFenwickSum();
            }
            ds.Initialize(N);
            

            //loop for number of operations
            for (int i = 0; i < NumberOfOperations; i++)
            {
                if (Random.Next(1, 100) > PercentOfQueryOperations) //Update
                {
                    //Console.WriteLine($"Ds size: {ds.Size}");
                    ds.Increase(Random.Next(0, ds.Size - 1), Random.Next()); //Random.Next() returns nonnegative integer
                } else //Query
                {
                    ds.Sum(Random.Next(0, ds.Size - 1));
                }
            }*/
        }
    }
}
