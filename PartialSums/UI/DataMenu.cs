using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialSums.UI
{
    class DataMenu : IMenu
    {
        private DataSelector _dataSelector;
        private DataStructureSelector _dataStructureSelector;
        public DataMenu(DataSelector dataSelector, DataStructureSelector dataStructureSelector)
        {
            _dataSelector = dataSelector;
            _dataStructureSelector = dataStructureSelector;
        }

        public void HandleChoice(string input)
        {
            try
            {
                int choice = int.Parse(input);
                if (choice < 0)
                    choice = 0;
                if (choice >= _dataSelector.DataSets.Count)
                    choice = _dataSelector.DataSets.Count-1;
                    
                _dataSelector.SelectedDataSet = _dataSelector.DataSets.ElementAt(choice);
                _dataStructureSelector.ResetDataCurrentDataStructure();
                //application.SelectedPartialSumDataStructure.Initialize(initializationData.Data);
                //application.SelectOverviewMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error, wrong input format");
            }
        }

        public void WriteOptions()
        {
            Console.WriteLine("Initialization Data Selection Menu");
            Console.WriteLine($"Current selected dataset: {_dataSelector.SelectedDataSet}");
            Console.WriteLine("Select a choice by typing corresponding number or type back to get to main menu");
            Console.WriteLine();

            int i = 0;
            foreach(var initializationData in _dataSelector.DataSets){
                Console.WriteLine($"{i++}: {initializationData}");
            }
            
        }
    }
}
