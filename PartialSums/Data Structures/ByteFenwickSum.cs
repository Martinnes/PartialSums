using PartialSums.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Data_Structures
{
    class ByteFenwickSum : IBenchmarkablePartialSumDataStructure
    {

        public int Size { get => _items.Length; }

        private byte[] _items = Array.Empty<byte>();

        public ByteFenwickSum(int size = -1)
        {
            if (size > 0)
                Initialize(size);
        }

        public void Initialize(int size)
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

        /*public int Sum(int l, int r)
        {
            return Sum(r) - Sum(l - 1);
        }*/

        //public override string ToString() => "Fenwick Tree";

        void IBenchmarkablePartialSumDataStructure.Sum(int index)
        {
            Sum(index);
        }

        public void IncreaseIndexWithRandomValue(int index, Random random)
        {
            Increase(index, random.NextByte()); 
        }
    }
}
