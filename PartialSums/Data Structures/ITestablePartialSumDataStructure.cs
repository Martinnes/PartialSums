﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Data_Structures
{
    public interface ITestablePartialSumDataStructure
    {
        void Increase(int index, byte delta);

        byte Sum(int index);
    }
}
