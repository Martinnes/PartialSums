using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialSums
{
    class DataSelector
    {
        public InitializationData SelectedDataSet { get; set; }
        public readonly ICollection<InitializationData> DataSets = new List<InitializationData>()
        {
            new InitializationData("Simple Data", new int[] { 3, 2, -1, 6, 5, 4, -3, 3, 7, 2, 3 }),
            new InitializationData("Even Simpler Data", new int[] { 3, 2 })
        };

        public DataSelector()
        {
            SelectedDataSet = DataSets.First();
        }
    }
}
