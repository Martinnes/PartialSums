using PartialSums.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PartialSums
{
    class PartialSumApplication
    {
        private readonly DataStructureSelector _dataStructureSelector = new DataStructureSelector();
        private readonly DataSelector _dataSelector = new DataSelector();
        private readonly MenuSelector _menuSelector;


        public PartialSumApplication()
        {
            _menuSelector = new MenuSelector(_dataStructureSelector, _dataSelector);
        }

        public void WriteOptions()
        {
            _menuSelector.WriteOptions();
        }

        public bool HandleChoice(String userInput)
        {
            return _menuSelector.HandleChoice(userInput);
        }
    }
}
