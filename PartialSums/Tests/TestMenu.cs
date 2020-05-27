using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.UI
{
    class TestMenu : IMenu
    {
        public void HandleChoice(string input)
        {
           
        }

        public void WriteOptions()
        {
            Console.WriteLine("Test Menu");
            Console.WriteLine("Run a test by typing corresponding number or type 'back' to get to main menu");
            Console.WriteLine();

            int i = 0;
            //foreach (var partialSumDS in _testRunner.PartialSumDataStructures)
            //{
            //    Console.WriteLine($"{i++}: {partialSumDS}");
            //}
        }
    }
}
