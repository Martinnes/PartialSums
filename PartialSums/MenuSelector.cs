using PartialSums.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    class MenuSelector
    {
        private readonly OverviewMenu _overviewMenu;
        private readonly DataMenu _dataMenu;
        private readonly DataStructureMenu _dataStructureMenu;
        private readonly ManualCommandsMenu _manualCommandsMenu;
        private IMenu _currentMenu;
        
        public MenuSelector(DataStructureSelector dataStructureSelector, DataSelector dataSelector)
        {
            _manualCommandsMenu = new ManualCommandsMenu(dataStructureSelector, dataSelector);
            _dataStructureMenu = new DataStructureMenu(dataStructureSelector);
            _dataMenu = new DataMenu(dataSelector, dataStructureSelector);
            _overviewMenu = new OverviewMenu(this, dataStructureSelector, dataSelector);
            _currentMenu = _overviewMenu;
        }

        public void GoToOverviewMenu()
        {
            _currentMenu = _overviewMenu;
        }

        public void GoToDataMenu()
        {
            _currentMenu = _dataMenu;
        }

        public void GoToDataStructureMenu()
        {
            _currentMenu = _dataStructureMenu;
        }

        public void GoToManualCommandsMenu()
        {
            _currentMenu = _manualCommandsMenu;
        }

        public void WriteOptions()
        {
            _currentMenu.WriteOptions();
        }

        public bool HandleChoice(String userInput)
        {
            if (userInput == "exit")
                return false;

            if (userInput == "back")
                GoToOverviewMenu();
            else
                _currentMenu.HandleChoice(userInput);
            return true;
        }
    }
}
