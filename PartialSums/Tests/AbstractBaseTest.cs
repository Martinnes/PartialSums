using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Tests
{
    public abstract class AbstractBaseTest
    {
        private IBenchmarkablePartialSumDataStructure ds;
        private Random Random;

        public const string PlainArray = "Plain Array";
        public const string FenwickTree = "Fenwick Tree";

        protected const int K1 = 1000;
        protected const int K10 = 10000;
        protected const int K100 = 100000;
        protected const int M1 = 1000000;
        protected const int M10 = 10000000;
        protected const int M100 = 100000000;
        protected const int B1 = 1000000000;

        public virtual int N { get; set; }

        public virtual int K { get; set; }

        public virtual int NumberOfOperations { get; set; }

        public virtual int PercentOfQueryOperations { get; set; }

        public virtual PartialSumDataStructure DataStructureType { get; set; }

        protected void ExecuteTest()
        {
            if (ds == null)
                return;

            //loop for number of operations
            for (int i = 0; i < NumberOfOperations; i++)
            {
                if (Random.Next(1, 100) > PercentOfQueryOperations) //Update
                    ds.IncreaseIndexWithRandomValue(Random.Next(0, ds.Size - 1), Random);
                else //Query
                    ds.Sum(Random.Next(0, ds.Size - 1));
            }
        }

        protected void InitializeVariablesBeforeTest()
        {
            InitializeDataStructureBeforeTest();
            if (ds != null)
                Random = new Random(42);
        }

        //Only relevant ds's are initialized, e.g. not ds. taking too long
        protected void InitializeDataStructureBeforeTest()
        {
            ds = null;
            switch (DataStructureType)
            {
                case PartialSumDataStructure.PlainArray: IntializePlainArray(); break;
                case PartialSumDataStructure.CompleteBinaryTree: IntializeCompleteBinaryTree(); break;
                case PartialSumDataStructure.FenwickTree: InitializeFenwickTree(); break;
            }
        }

        protected void IntializePlainArray()
        {
            if (N > M10 || NumberOfOperations > M10)
                return;
            if (N == M10 && NumberOfOperations == M10)
                return;
            if (N == M10 && PercentOfQueryOperations >= 50)
                return;
            if (NumberOfOperations == M10 && PercentOfQueryOperations >= 50) //This should be included in final test
                return;

            if (K == 32)
                ds = new IntegerPlainArray(N);
        }

        protected void IntializeCompleteBinaryTree()
        {
            if (K == 32)
                ds = new IntegerCompleteBinaryTree(N);
        }

        protected void InitializeFenwickTree()
        {
            if (K == 8)
                ds = new ByteFenwickSum(N);
            else if (K == 32)
                ds = new IntegerFenwickSum(N);
            else if (K == 64)
                ds = new LongFenwickSum(N);
        }
    }
}
