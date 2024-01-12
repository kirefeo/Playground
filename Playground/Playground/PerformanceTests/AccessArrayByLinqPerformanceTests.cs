using Playground.Models;
using Playground.Performance;
using System.Linq;

namespace Playground.PerformanceTests
{
    class AccessArrayByLinqPerformanceTests
    {
        static int _iterations = 10000;

        public static void Test()
        {
            var array = new InnerChildClass[_iterations];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new InnerChildClass
                {
                    NullableValue1 = i,
                };
            }

            using (new PerformanceLogger("Access properties in array by index"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array[i].NullableValue1;
                }
            }

            using (new PerformanceLogger("Access properties in array - Where().First()"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array.Where(a => a.NullableValue1 == i).First();
                }
            }

            using (new PerformanceLogger("Access properties in array - First(filter)"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array.First(a => a.NullableValue1 == i);
                }
            }

            using (new PerformanceLogger("Access properties in array - Where().FirstOrDefault()"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array.Where(a => a.NullableValue1 == i).FirstOrDefault();
                }
            }

            using (new PerformanceLogger("Access properties in array - Where().FirstOrDefault() > returns default"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var filter = _iterations + 100;
                    var nullableValue1 = array.Where(a => a.NullableValue1 == filter).FirstOrDefault();
                }
            }

            using (new PerformanceLogger("Access properties in array - Where().Single()"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array.Where(a => a.NullableValue1 == i).Single();
                }
            }

            using (new PerformanceLogger("Access properties in array - Where().SingleOrDefault()"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array.Where(a => a.NullableValue1 == i).SingleOrDefault();
                }
            }

            using (new PerformanceLogger("Access properties in array - Where().SingleOrDefault() > returns default"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var filter = _iterations + 100;
                    var nullableValue1 = array.Where(a => a.NullableValue1 == filter).SingleOrDefault();
                }
            }
        }
    }
}
