using Playground.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.PerformanceTests
{
    class ArraySortPerformanceTests
    {
        static int _iterations = 10000000;

        public static void Test()
        {
            var unsortedArray = new int[] { 0, 3, 4, 1, 2, -1, -3, -4, 0, -2 };

            using (new PerformanceLogger("Use custom sort"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var tempArray = new int[unsortedArray.Length];
                    unsortedArray.CopyTo(tempArray, 0);
                    
                    Sort(tempArray, true);
                }
            }

            using (new PerformanceLogger("Use Array.Sort"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var tempArray = new int[unsortedArray.Length];
                    unsortedArray.CopyTo(tempArray, 0);

                    Array.Sort(tempArray);
                }
            }
        }


        private static void Sort(int[] measure, bool ascending)
        {
            int n = measure.Length;
            for (int j = 1; j < n; j++)
            {
                int temp = measure[j];
                int i;
                for (i = j - 1; i >= 0; i--)
                {
                    if (ascending)
                    {
                        if (measure[i] <= temp)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (measure[i] >= temp)
                        {
                            break;
                        }
                    }
                    measure[i + 1] = measure[i];
                }
                measure[i + 1] = temp;
            }
        }
    }
}
