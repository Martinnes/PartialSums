using BenchmarkDotNet.Running;
using PartialSums.Data_Structures;
using PartialSums.Tests;
using System;
using System.Diagnostics;

namespace PartialSums
{
    class Program
    {
        private static readonly PartialSumApplication app = new PartialSumApplication();
        private const string startupMessage = "Welcome to the Partial Sums test application\nType \"exit\" at any time to exit application\n";
        static void Main(string[] args)
        {
            Console.WriteLine(startupMessage);
            DisplayTimerProperties();
 
            //do initial code invocations to execute JIT compilation     

            bool Continue = true;
            /*while (Continue)
            {
                app.WriteOptions();
                string userInput = Console.ReadLine();
                Continue = app.HandleChoice(userInput);
            }*/
            BenchmarkRunner.Run<BasicTest>();
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=netframework-4.8
        public static void DisplayTimerProperties()
        {
            // Display the timer frequency and resolution.
            if (Stopwatch.IsHighResolution)
            {
                const string Value = "Operations timed using the system's high-resolution performance counter.";
                Console.WriteLine(Value);
            }
            else
            {
                Console.WriteLine("Operations timed using the DateTime class.");
            }

            long frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}",
                frequency);
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds",
                nanosecPerTick);
        }
    }
}
