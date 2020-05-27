using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PartialSums.UI
{
    class OverviewMenu : IMenu
    {
        private DataStructureSelector _dataStructureSelector;
        private DataSelector _dataSelector;
        private MenuSelector _menuSelector;

        public OverviewMenu(MenuSelector menuSelector, DataStructureSelector dSSelector, DataSelector dataSelector)
        {
            _dataStructureSelector = dSSelector;
            _dataSelector = dataSelector;
            _menuSelector = menuSelector;
        }


        public void HandleChoice(String input)
        {
            try
            {
                int choice = int.Parse(input);
                if(choice == 0)
                {
                    _menuSelector.GoToDataMenu();
                } else if (choice == 1)
                {
                    _menuSelector.GoToDataStructureMenu();
                } else if (choice == 2)
                {
                    _menuSelector.GoToManualCommandsMenu();

                } else if (choice == 3)
                {
                    SimpleAlternatingTest();
                }

            }catch (FormatException)
            {
                Console.WriteLine("Error, wrong input format");
            }
        }
        
        public void WriteOptions()
        {
            Console.WriteLine("Partial Sums Overview Menu");
            Console.WriteLine($"Current dataset: {_dataSelector.SelectedDataSet}");
            Console.WriteLine($"Current data structure: {_dataStructureSelector.SelectedPartialSumDataStructure}");
            Console.WriteLine("Select a choice by typing corresponding number:");
            Console.WriteLine("0: choose initialization data");
            Console.WriteLine("1: choose data structure");
            Console.WriteLine("2: run manual commands");
            Console.WriteLine("3: run simple alternating test");
        }

        private void SimpleAlternatingTest()
        {
            //General Initialization
            Random r = new Random(42);
            int trigger = 10;
            int fenwicksize = trigger * 1000 * 1000;
            int plainArraySize = trigger * 1000 * 10;
            Stopwatch s = new Stopwatch();

            //Fenwick initialization
            IIntegerPartialSumDataStructure fenwick = new IntegerFenwickSum();
            fenwick.InitializeRandomly(fenwicksize, r);

            //Fenwick test
            s.Start();
            AlternatingTest.Test(fenwick);
            s.Stop();
            Console.WriteLine($"Fenwick time: {s.ElapsedMilliseconds}");

            //PlainArray initialization
            s.Reset();
            r = new Random(42);
            IIntegerPartialSumDataStructure plainArray = new IntegerPlainArray();
            plainArray.InitializeRandomly(plainArraySize, r);
            
            //PlainArray test
            s.Start();
            AlternatingTest.Test(plainArray);
            s.Stop();
            Console.WriteLine($"Plain time: {s.ElapsedMilliseconds}");
        }
    }
}
