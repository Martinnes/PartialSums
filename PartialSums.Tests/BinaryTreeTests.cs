﻿using PartialSums.Data_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Tests
{
    public class BinaryTreeTests : AbstractPartialSumTests
    {
        protected override ITestablePartialSumDataStructure GetDataStructure(int size)
        {
            return new IntegerCompleteBinaryTree(size);
        }
    }
}