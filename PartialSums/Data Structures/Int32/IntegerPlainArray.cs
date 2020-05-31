using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    public class IntegerPlainArray : IBenchmarkablePartialSumDataStructure, ITestablePartialSumDataStructure
    {
        public int Size { get => _items.Length; }

        private int[] _items;

        public IntegerPlainArray(int size)
        {
            _items = new int[size];
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
