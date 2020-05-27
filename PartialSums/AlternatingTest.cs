using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    class AlternatingTest
    {
        public static void Test(IIntegerPartialSumDataStructure ds)
        {
            Random r = new Random(100);
            //do alternating writes and reads
            for (int i = 0; i < ds.Size; i++)
            {
                if (i % 2 == 0)
                    ds.Increase(i, r.Next());
                else
                    ds.Sum(r.Next(0,ds.Size-1));
            }
        }
    }
}
