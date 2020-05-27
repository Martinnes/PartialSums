using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.Extensions
{
    static class RandomExtensions
    {
        public static long NextLong(this Random r)
        {
            byte[] buf = new byte[8];
            r.NextBytes(buf);
            return BitConverter.ToInt64(buf, 0);
        }

        public static byte NextByte(this Random r)
        {
            byte[] buf = new byte[1];
            r.NextBytes(buf);
            return buf[0];
        }
    }
}
