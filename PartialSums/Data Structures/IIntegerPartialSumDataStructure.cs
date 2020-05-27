using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    public interface IIntegerPartialSumDataStructure
    {
        int Size { get; }

        //@TODO int Search() 

        int Sum(int index);

        void Increase(int index, int delta);
        void Initialize(IList<int> items);
        void Initialize(int size);

        void InitializeRandomly(int size, Random r);

        void ResetData();

        bool IsInitialized { get; }
    }
}
