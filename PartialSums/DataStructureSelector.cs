using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialSums
{
    public class DataStructureSelector
    {
        public readonly ICollection<IIntegerPartialSumDataStructure> PartialSumDataStructures = new List<IIntegerPartialSumDataStructure> {
            new IntegerFenwickSum(),
            new IntegerPlainArray()
        };

        public IIntegerPartialSumDataStructure SelectedPartialSumDataStructure { get; set; }

        public void ResetDataCurrentDataStructure()
        {
            SelectedPartialSumDataStructure.ResetData();
        }

        public void InitializeCurrentDataStructureRandomly(int size, Random r)
        {
            SelectedPartialSumDataStructure.InitializeRandomly(size, r);
        }

        public DataStructureSelector()
        {
            SelectedPartialSumDataStructure = PartialSumDataStructures.First();
        }
    }
}
