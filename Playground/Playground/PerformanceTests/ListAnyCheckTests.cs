using Playground.Performance;
using System.Collections.Generic;
using System.Linq;

namespace Playground.PerformanceTests
{
    class ListAnyCheckTests
    {
        static int _iterations = 1000000;

        public static void Test()
        {
            List<int> emptyList = new List<int>();
            var size = 100000;
            List<int> filledList = new List<int>(size);
            for (int i = 0; i < filledList.Count; i++)
            {
                filledList[i] = i;
            }
            IEnumerable<int> emptyEnum = emptyList.AsEnumerable();
            IEnumerable<int> filledEnum = filledList.AsEnumerable();


            using (new PerformanceLogger("Filled list .Any()"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (filledList.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled list !.Any()"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (!filledList.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty list .Any()"))
            {

                for (int i = 0; i < _iterations; i++)
                {
                    if (emptyList.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty list !.Any()"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (!emptyList.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled list .Count() > 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (filledList.Count > 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled list .Count() == 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (filledList.Count == 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty list .Count() > 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (emptyList.Count > 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty list .Count() == 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (emptyList.Count == 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled enumerable .Any()"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (filledEnum.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled enumerable !.Any()"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (!filledEnum.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty enumerable .Any()"))
            {

                for (int i = 0; i < _iterations; i++)
                {
                    if (emptyEnum.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty enumerable !.Any()"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (!emptyEnum.Any())
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled enumerable .Count() > 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (filledEnum.Count() > 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Filled enumerable .Count() == 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (filledEnum.Count() == 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty enumerable .Count() > 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (emptyEnum.Count() > 0)
                    {
                        // do nothing
                    }
                }
            }

            using (new PerformanceLogger("Empty enumerable .Count() == 0"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    if (emptyEnum.Count() == 0)
                    {
                        // do nothing
                    }
                }
            }

        }
    }
}
