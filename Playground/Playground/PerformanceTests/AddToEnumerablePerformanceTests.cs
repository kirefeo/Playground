using Playground.Performance;
using System.Collections.Generic;
using System.Linq;

namespace Playground.PerformanceTests
{
    class AddToEnumerablePerformanceTests
    {
        static int _iterations = 1000000;

        public static void Test()
        {
            var testArray = new int[_iterations];
            var testList = new List<int>();
            var testDictionary = new Dictionary<int, int>();

            using (new PerformanceLogger("Add value to array"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    testArray[i] = i;
                }
            }

            using (new PerformanceLogger("Add value to List"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    testList.Add(i);
                }
            }

            using (new PerformanceLogger("Add value to Dictionary"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    testDictionary[i] = i;
                }
            }

            using (new PerformanceLogger("Access value from array"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = testArray[i];
                }
            }

            using (new PerformanceLogger("Access value from List"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = testList[i];
                }
            }

            using (new PerformanceLogger("Access value from Dictionary"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = testDictionary[i];
                }
            }

        }
    }
}
