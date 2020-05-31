using PartialSums.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Data_Structures
{
    public class LongFenwickSum : IBenchmarkablePartialSumDataStructure, ITestablePartialSumDataStructure
    {

        public int Size { get => _items.Length; }

        private long[] _items = Array.Empty<long>();

        public LongFenwickSum(int size = -1)
        {
            if (size > 0)
                Initialize(size);
        }

        public void Initialize(int size)
        {
            _items = new long[size];
        }

        public void Increase(int i, long delta)
        {
            for (; i < Size; i = i | (i + 1))
                _items[i] += delta;
        }

        public long Sum(int r)
        {
            if (r < 0) return 0;
            if (r >= Size) r = Size - 1;
            long result = 0;
            for (; r >= 0; r = (r & (r + 1)) - 1)
                result += _items[r];
            return result;
        }

        void IBenchmarkablePartialSumDataStructure.Sum(int index)
        {
            Sum(index);
        }

        //https://stackoverflow.com/questions/6651554/random-number-in-long-range-is-this-the-way
        public void IncreaseIndexWithRandomValue(int index, Random random)
        {
            Increase(index, random.NextLong());
        }

        void ITestablePartialSumDataStructure.Increase(int index, byte delta)
        {
            Increase(index, Convert.ToInt64(delta));
        }

        byte ITestablePartialSumDataStructure.Sum(int index)
        {
            return Convert.ToByte(Sum(index));
        }
    }
}
