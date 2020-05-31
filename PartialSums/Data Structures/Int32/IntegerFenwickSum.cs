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
        
        public bool IsInitialized { get => Size > 0; }

        private int[] _items = Array.Empty<int>();

        public IntegerFenwickSum(int size=-1)
        {
            if (size > 0)
                Initialize(size);
        }

        public void ResetData()
        {
            _items = Array.Empty<int>();
        }

        public void Initialize(IList<int> items)
        {
            Initialize(items.Count);

            for (var i = 0; i < Size; i++)
                Increase(i, items[i]);
        }

        public void Initialize(int size)
        {
            _items = new int[size];
        }

        public void Increase(int i, int delta)
        {
            for (; i < Size; i = i | (i + 1))
                _items[i] += delta;
        }

        public void InitializeRandomly(int size, Random r)
        {
            Initialize(size);
            for (var i = 0; i < _items.Length; i++)
                Increase(i, r.Next());
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

        /*public int Sum(int l, int r)
        {
            return Sum(r) - Sum(l - 1);
        }*/

        public override string ToString() => "Fenwick Tree";

        void IBenchmarkablePartialSumDataStructure.Sum(int index)
        {
            Sum(index);
        }

        public void IncreaseIndexWithRandomValue(int index, Random random)
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
