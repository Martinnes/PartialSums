using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialSums
{
    //http://algo.pw/algo/87/

    public class IntegerFenwickSum : IBenchmarkablePartialSumDataStructure, ITestablePartialSumDataStructure
    {
        public int Size { get => _items.Length; }

        private int[] _items;

        public IntegerFenwickSum(int size)
        {
            _items = new int[size];
        }

        public void Increase(int i, int delta)
        {
            for (; i < Size; i = i | (i + 1))
                _items[i] += delta;
        }

        public int Sum(int r)
        {
            if (r < 0) return 0;
            if (r >= Size) r = Size - 1;
            var result = 0;
            for (; r >= 0; r = (r & (r + 1)) - 1)
                result += _items[r];
            return result;
        }

        void IBenchmarkablePartialSumDataStructure.Sum(int index)
        {
            Sum(index);
        }

        void IBenchmarkablePartialSumDataStructure.IncreaseIndexWithRandomValue(int index, Random random)
        {
            Increase(index, random.Next()); //TODO: is this problem?: Random.Next() returns nonnegative integer
        }

        void ITestablePartialSumDataStructure.Increase(int index, byte delta)
        {
            Increase(index, Convert.ToInt32(delta));
        }

        byte ITestablePartialSumDataStructure.Sum(int index)
        {
            return Convert.ToByte(Sum(index));
        }
    }
}
