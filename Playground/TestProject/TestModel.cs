using Playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class TestModel
    {
        public Dictionary<int, double[]> Dict1 { get; set; }
        public Dictionary<int, double[]> Dict2 { get; set; }

        public Dictionary<EnumStruct, double[]> DictWithStructKey { get; set; }
        public Dictionary<EnumStruct, double[]> DictWithStructKey2 { get; set; }
    }
}
