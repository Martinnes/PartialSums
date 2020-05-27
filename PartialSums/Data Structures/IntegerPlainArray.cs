using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    class IntegerPlainArray : IIntegerPartialSumDataStructure, IPartialSumDataStructure
    {
        public int Size { get => _items.Length; }

        public bool IsInitialized { get => Size > 0; }

        private int[] _items = Array.Empty<int>();

        public IntegerPlainArray(int size=-1)
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
            for (var i = 0; i < items.Count; i++)
                Increase(i, items[i]);
        }

        public void Initialize(int size)
        {
            _items = new int[size];
        }

        public void InitializeRandomly(int size, Random r)
        {
            Initialize(size);
            for (var i = 0; i < _items.Length; i++)
                Increase(i, r.Next());
        }


        public void Increase(int index, int delta)
        {
            _items[index] += delta;
        }

        public int Sum(int index)
        {
            int sum=0;
            for(int i=0; i <= index; i++)
            {
                sum += _items[i];
            }
            return sum;
        }

        public override string ToString() => "Plain Array";

        void IPartialSumDataStructure.Sum(int index)
        {
            Sum(index);
        }

        public void IncreaseIndexWithRandomValue(int index, Random random)
        {
            Increase(index, random.Next()); //TODO: is this problem?: Random.Next() returns nonnegative integer
        }
    }
}
