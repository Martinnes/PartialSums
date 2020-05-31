using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialSums.Data_Structures
{
    public class IntegerCompleteBinaryTree : IBenchmarkablePartialSumDataStructure, ITestablePartialSumDataStructure
    {
        public int Size { get; }

        private readonly int[] _items;

        private readonly int numberOfLeaves;

        private int internalNodes => numberOfLeaves - 1;

        public IntegerCompleteBinaryTree(int n)
        {
            Size = n;
            numberOfLeaves = RoundUpToPowerOf2(n);
            _items = new int[2 * numberOfLeaves];
        }

        /*
         * TODO: Loop with bitshifting in stead of division:
         * 
         * Multiplication, as well as bit shifting, is faster because is a native operation for the CPU too. 
         * It takes one cycle while bit shifting takes about four which is why it is faster. 
         * Division takes something between 11 and 18 cycles.
         * 
         * Shifts have extra overhead in C#, explained in this answer. 
         * Not running with the optimizer enabled is a standard benchmark mistake. 
         * Use Agner Fog's instruction timing manual to get insight. 
         * Cycle times are an estimate: shifting a memory value by an arbitrary amount roughly takes 4 cycles, multiplication takes 1, dividing takes between 11 and 18 cycles. 
         * These big differences are blurred by the for(;;) loop overhead.
         * */
        public void Increase(int i, int delta)
        {
            i += internalNodes;
            for (; i > 0; i = i >> 1) //leaf to root path,
            {
                _items[i] += delta; 
            }
        }

        public void IncreaseIndexWithRandomValue(int index, Random random)
        {
            Increase(index, random.Next());
        }

        public int Sum(int index)
        {
            int RightChildrenSum = 0;
            for (int binaryTreeIndex = index + internalNodes; binaryTreeIndex > 1; binaryTreeIndex = binaryTreeIndex >> 1) //leaf to root path, stop before root
            {
                if (binaryTreeIndex % 2 == 0) //current node is left child
                    RightChildrenSum += _items[binaryTreeIndex + 1]; //add value of sibling
            }
            return _items[1] - RightChildrenSum;
        }

        void IBenchmarkablePartialSumDataStructure.Sum(int index)
        {
            Sum(index);
        }

        //https://stackoverflow.com/questions/31997707/rounding-value-to-nearest-power-of-two
        private int RoundUpToPowerOf2(int x)
        {
            if (x < 0) { return 0; }
            --x;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x + 1;
        }

        
    }
}
