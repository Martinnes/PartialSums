using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums.UI
{
    class ManualCommandsMenu : IMenu
    {
        private DataStructureSelector _dataStructureSelector;
        private DataSelector _dataSelector;

        public ManualCommandsMenu(DataStructureSelector dSSelector, DataSelector dataSelector)
        {
            _dataStructureSelector = dSSelector;
            _dataSelector = dataSelector;
        }

        public void HandleChoice(string input)
        {
            (int,int)? inputParameters= ExtractInputParameters(input);
            if(inputParameters==null)
                return;

            (int index, int delta) = inputParameters.Value;
            if (!ValidateIndex(index))
            {
                Console.WriteLine("Index was not within array range");
                return;
            }

            IIntegerPartialSumDataStructure ds = _dataStructureSelector.SelectedPartialSumDataStructure;
            ds.Increase(index, delta);
        }

        private (int,int)? ExtractInputParameters(string input)
        {
            string[] splittedInput = input.Split(' ');
            if (splittedInput.Length < 3)
            {
                Console.WriteLine("Wrong input format, expected format: \"i <index> <delta>\", your's contained fewer spaces");
                return null;
            }
            if (splittedInput.Length > 3)
            {
                Console.WriteLine("Wrong input format, expected format: \"i <index> <delta>\", your's contained more spaces");
                return null;
            }
            if (splittedInput[0] != "i")
            {
                Console.WriteLine("Wrong input format, expected format: \"i <index> <delta>\", the specified action was not 'i'");
                return null;
            }
            int index;
            try
            {
                index = int.Parse(splittedInput[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input format, expected format: \"i <index> <delta>\", but the specified index was not an integer");
                return null;
            }

            int delta;
            try
            {
                delta = int.Parse(splittedInput[2]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input format, expected format: \"i <index> <delta>\", but the specified delta was not an integer");
                return null;
            }
            return (index,delta);
        }

        private bool ValidateIndex(int index)
        {
            return index >= 0 && index < _dataStructureSelector.SelectedPartialSumDataStructure.Size;
        }

        public void WriteOptions()
        {
            IIntegerPartialSumDataStructure ds = _dataStructureSelector.SelectedPartialSumDataStructure;
            
            //Reset DS to use initialization data if not initialized
            if(!ds.IsInitialized)
                ds.Initialize(_dataSelector.SelectedDataSet.Data);

            Console.WriteLine($"Manual Commands Menu");
            PrintArray(ds);
            Console.WriteLine($"Write \"i <index> <delta>\" to increase value at index (int) with delta (int)");
        }

        private void PrintArray(IIntegerPartialSumDataStructure ds)
        {
            Console.Write('[');
            if (ds.Size > 0)
            {
                for (int i = 0; i < ds.Size - 1; i++)
                {
                    Console.Write($"{ds.Sum(i)},");
                }
                Console.Write($"{ds.Sum(ds.Size - 1)}"); //fencepost
            }
            Console.WriteLine(']');
        }
    }
}
