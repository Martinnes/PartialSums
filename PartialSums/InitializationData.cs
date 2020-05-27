using System;
using System.Collections.Generic;
using System.Text;

namespace PartialSums
{
    class InitializationData
    {
        private readonly string _name;
        public IList<int> Data { get; }
        public InitializationData(String name, IList<int> data)
        {
            _name = name;
            Data = data;
        }

        public override string ToString() => $"{_name} (size:{Data.Count})";
    }
}
