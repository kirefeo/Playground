using Playground.Models;
using Playground.Performance;
using System;
using System.Collections.Generic;

namespace Playground.PerformanceTests
{
    class DictionaryKeyAccessPerformanceTests
    {
        static int _iterations = 1000000;

        public static void Test()
        {
            var tupleDictionary = GetTupleDictionary();
            var structDictionary = GetStructDictionary();

            using (new PerformanceLogger("Access value with tuple key"))
            {
                var tupleKey = Tuple.Create(Enum1.A, Enum2.B, Enum3.A, Enum4.A);

                for (int i = 0; i < _iterations; i++)
                {
                    var value = tupleDictionary[tupleKey];
                }
            }

            using (new PerformanceLogger("Access value with struct key"))
            {
                var structKey = new EnumStruct(Enum1.A, Enum2.B, Enum3.A, Enum4.A);
                for (int i = 0; i < _iterations; i++)
                {
                    var value = structDictionary[structKey];
                }
            }
        }

        private static Dictionary<Tuple<Enum1, Enum2, Enum3, Enum4>, double> GetTupleDictionary()
        {
            return new Dictionary<Tuple<Enum1, Enum2, Enum3, Enum4>, double>
            {
                { Tuple.Create(Enum1.A, Enum2.A, Enum3.A, Enum4.A), 1.0 },
                { Tuple.Create(Enum1.B, Enum2.B, Enum3.B, Enum4.B), 2.0 },
                { Tuple.Create(Enum1.B, Enum2.A, Enum3.A, Enum4.A), 3.0 },
                { Tuple.Create(Enum1.B, Enum2.B, Enum3.A, Enum4.A), 4.0 },
                { Tuple.Create(Enum1.B, Enum2.B, Enum3.B, Enum4.A), 5.0 },
                { Tuple.Create(Enum1.A, Enum2.B, Enum3.A, Enum4.A), 6.0 },
                { Tuple.Create(Enum1.A, Enum2.B, Enum3.B, Enum4.A), 7.0 },
                { Tuple.Create(Enum1.A, Enum2.B, Enum3.B, Enum4.B), 8.0 },
                { Tuple.Create(Enum1.A, Enum2.A, Enum3.B, Enum4.A), 9.0 },
                { Tuple.Create(Enum1.A, Enum2.A, Enum3.B, Enum4.B), 10.0 },
                { Tuple.Create(Enum1.A, Enum2.A, Enum3.A, Enum4.B), 11.0 },
            };
        }

        private static Dictionary<EnumStruct, double> GetStructDictionary()
        {
            return new Dictionary<EnumStruct, double>
            {
                { new EnumStruct(Enum1.A, Enum2.A, Enum3.A, Enum4.A), 1.0 },
                { new EnumStruct(Enum1.B, Enum2.B, Enum3.B, Enum4.B), 2.0 },
                { new EnumStruct(Enum1.B, Enum2.A, Enum3.A, Enum4.A), 3.0 },
                { new EnumStruct(Enum1.B, Enum2.B, Enum3.A, Enum4.A), 4.0 },
                { new EnumStruct(Enum1.B, Enum2.B, Enum3.B, Enum4.A), 5.0 },
                { new EnumStruct(Enum1.A, Enum2.B, Enum3.A, Enum4.A), 6.0 },
                { new EnumStruct(Enum1.A, Enum2.B, Enum3.B, Enum4.A), 7.0 },
                { new EnumStruct(Enum1.A, Enum2.B, Enum3.B, Enum4.B), 8.0 },
                { new EnumStruct(Enum1.A, Enum2.A, Enum3.B, Enum4.A), 9.0 },
                { new EnumStruct(Enum1.A, Enum2.A, Enum3.B, Enum4.B), 10.0 },
                { new EnumStruct(Enum1.A, Enum2.A, Enum3.A, Enum4.B), 11.0 },
            };
        }
    }
}
