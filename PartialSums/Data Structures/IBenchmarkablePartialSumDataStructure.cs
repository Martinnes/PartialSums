using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Data_Structures
{
    public interface IBenchmarkablePartialSumDataStructure
    {
        int Size { get; }

        //@TODO int Search() 

        void Sum(int index);

        void IncreaseIndexWithRandomValue(int index, Random random);
    }
}
