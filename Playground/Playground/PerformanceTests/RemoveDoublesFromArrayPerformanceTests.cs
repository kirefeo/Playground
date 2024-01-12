using Playground.Performance;
using System.Collections.Generic;
using System.Linq;

namespace Playground.PerformanceTests
{
    class RemoveDoublesFromArrayPerformanceTests
    {
        static int _iterations = 100000;

        public static void Test()
        {
            var unsortedArray = new int[] { 0, 3, 4, 4, 1, 2, -1, -3, -4, 0, -2, -1, };

            using (new PerformanceLogger("Use custom way"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var tempArray = new int[unsortedArray.Length];
                    tempArray[0] = unsortedArray[0];
                    int m = 1;
                    for (int j = 1; j < unsortedArray.Length; j++)
                    {
                        if (unsortedArray[j] > unsortedArray[j - 1])
                        {
                            tempArray[m] = unsortedArray[j];
                            m++;
                        }
                    }
                }
            }

            using (new PerformanceLogger("Use HashSet"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var tempArray = new HashSet<int>(unsortedArray).ToArray();
                }
            }

            using (new PerformanceLogger("Use Distinct"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var tempArray = unsortedArray.Distinct().ToArray();
                }
            }
        }
    }
}
