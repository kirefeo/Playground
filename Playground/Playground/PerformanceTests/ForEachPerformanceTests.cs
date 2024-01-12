using Playground.Models;
using Playground.Performance;
using System.Collections.Generic;

namespace Playground.PerformanceTests
{
    class ForEachPerformanceTests
    {
        static int _iterations = 1000000;

        public static void Test()
        {
            var array = new InnerChildClass[_iterations];
            var iterationList = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new InnerChildClass
                {
                    NullableValue1 = i,
                };
                iterationList.Add(i);
            }

            using (new PerformanceLogger("Iterate over array with for-loop"))
            {
                var arrayLength = iterationList.Count;

                for (int i = 0; i < arrayLength; i++)
                {
                    DoStuff(array[i]);
                }
            }

            using (new PerformanceLogger("Iterate over array with foreach-loop"))
            {
                foreach (var i in iterationList)
                {
                    DoStuff(array[i]);
                }
            }

            using (new PerformanceLogger("Iterate over array with linq.ForEach()"))
            {

                iterationList.ForEach(i => DoStuff(array[i]));
            }
        }

        private static void DoStuff(InnerChildClass innerChildClass)
        {
            var value = innerChildClass.NullableValue1;
        }
    }
}
