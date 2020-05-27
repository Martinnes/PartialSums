using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.DataStructures
{
    interface IBytePartialSumDataStructure
    {
        int Size { get; }

        //@TODO int Search() 

        byte Sum(int index);

        void Increase(int index, byte delta);
        void Initialize(IList<byte> items);
        void Initialize(int size);

        void InitializeRandomly(int size, Random r);

        void ResetData();

        bool IsInitialized { get; }
    }
}
