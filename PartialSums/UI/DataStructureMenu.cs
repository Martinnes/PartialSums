using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialSums.UI
{ 
    class DataStructureMenu : IMenu
    {
        private readonly DataStructureSelector _dataStructureSelector;
        public DataStructureMenu(DataStructureSelector dSSelector)
        {
            _dataStructureSelector = dSSelector;
        }

        public void HandleChoice(string input)
        {

            try
            {
                int choice = int.Parse(input);
                if (choice < 0)
                    choice = 0;
                if (choice >= _dataStructureSelector.PartialSumDataStructures.Count)
                    choice = _dataStructureSelector.PartialSumDataStructures.Count-1;

                _dataStructureSelector.SelectedPartialSumDataStructure = _dataStructureSelector.PartialSumDataStructures.ElementAt(choice);
                //application.SelectOverviewMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error, wrong input format");
            }
        }

        public void WriteOptions()
        {
            Console.WriteLine("Data Structure Selection Menu");
            Console.WriteLine($"Current selected data structure: {_dataStructureSelector.SelectedPartialSumDataStructure}");
            Console.WriteLine("Select a choice by typing corresponding number or type 'back' to get to main menu");
            Console.WriteLine();

            int i = 0;
            foreach (var partialSumDS in _dataStructureSelector.PartialSumDataStructures)
            {
                Console.WriteLine($"{i++}: {partialSumDS}");
            }

        }
    }
}
