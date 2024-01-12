using Playground.Models;
using Playground.Performance;

namespace Playground.PerformanceTests
{
    class AccessArrayByIndexPerformanceTests
    {
        static int _iterations = 10000000;

        public static void Test()
        {
            var array = new InnerChildClass[_iterations];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new InnerChildClass
                {
                    NullableValue1 = i,
                    NullableValue2 = i + 1
                };
            }

            using (new PerformanceLogger("Access properties in array once"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue1 = array[i].NullableValue1;
                    var nullableValue2 = array[i].NullableValue2;
                }
            }

            using (new PerformanceLogger("Access properties in array multiple times"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var nullableValue11 = array[i].NullableValue1;
                    var nullableValue21 = array[i].NullableValue2;
                    var nullableValue12 = array[i].NullableValue1;
                    var nullableValue22 = array[i].NullableValue2;
                    var nullableValue13 = array[i].NullableValue1;
                    var nullableValue23 = array[i].NullableValue2;
                    var nullableValue14 = array[i].NullableValue1;
                    var nullableValue24 = array[i].NullableValue2;
                }
            }

            using (new PerformanceLogger("Add array to variable, access properties in variable once"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var innerChildClass = array[i];
                    var nullableValue1 = innerChildClass.NullableValue1;
                    var nullableValue2 = innerChildClass.NullableValue2;
                }
            }

            using (new PerformanceLogger("Add array to variable, access properties in variable multiple times"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var innerChildClass = array[i];
                    var nullableValue11 = innerChildClass.NullableValue1;
                    var nullableValue21 = innerChildClass.NullableValue2;
                    var nullableValue12 = innerChildClass.NullableValue1;
                    var nullableValue22 = innerChildClass.NullableValue2;
                    var nullableValue13 = innerChildClass.NullableValue1;
                    var nullableValue23 = innerChildClass.NullableValue2;
                    var nullableValue14 = innerChildClass.NullableValue1;
                    var nullableValue24 = innerChildClass.NullableValue2;
                }
            }
        }
    }
}
