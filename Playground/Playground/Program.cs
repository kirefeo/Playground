using Playground.PerformanceTests;
using System;

namespace Playground
{
    class Program
    {
        //TODO: sharplab.io voor interne werking van code


        static void Main(string[] args)
        {
            //ThrowIfNullPerformanceTests.Test();
            //InstantiateClassPerformanceTests.Test();
            //AccessArrayByIndexPerformanceTests.Test();
            //AccessArrayByLinqPerformanceTests.Test();
            //ArrayTypesPerformanceTests.Test();
            //GetComparableObjectFromListPerformanceTests.Test();
            //ArraySortPerformanceTests.Test();
            //RemoveDoublesFromArrayPerformanceTests.Test();
            StringConcatenationPerformanceTests.Test();
            //JaggedArrayAccessTests.Test();
            //VariableAccessTests.Test();
            //ListAnyCheckTests.Test();
            //DictionaryKeyAccessPerformanceTests.Test();
            //AddToEnumerablePerformanceTests.Test();
            //ForEachPerformanceTests.Test();

            Console.ReadKey();
        }
    }
}
