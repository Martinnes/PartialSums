using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.DataStructures
{
    interface ILongPartialSumDataStructure
    {
        int Size { get; }

        //@TODO int Search() 

        long Sum(int index);

        void Increase(int index, long delta);
        void Initialize(IList<long> items);
        void Initialize(int size);

        void InitializeRandomly(int size, Random r);

        void ResetData();

        bool IsInitialized { get; }
    }
}
