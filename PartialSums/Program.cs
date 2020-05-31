using BenchmarkDotNet.Running;
using PartialSums.Data_Structures;
using PartialSums.Tests;
using System;
using System.Diagnostics;

namespace PartialSums
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BasicTest>();
        }
    }
}
