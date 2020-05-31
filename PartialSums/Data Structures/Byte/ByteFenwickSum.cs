using PartialSums.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Data_Structures
{
    public class ByteFenwickSum : IBenchmarkablePartialSumDataStructure, ITestablePartialSumDataStructure
    {
        public int Size { get => _items.Length; }

        private byte[] _items;

        public ByteFenwickSum(int size)
        {
            _items = new byte[size];
        }

        public void Increase(int i, byte delta)
        {
            for (; i < Size; i = i | (i + 1))
                _items[i] += delta;
        }

        public byte Sum(int r)
        {
            if (r < 0) return 0;
            if (r >= Size) r = Size - 1;
            byte result = 0;
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
            Increase(index, random.NextByte()); 
        }
    }
}
