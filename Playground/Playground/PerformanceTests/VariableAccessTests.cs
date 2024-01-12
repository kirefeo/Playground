using Playground.Models;
using Playground.Performance;

namespace Playground.PerformanceTests
{
    class VariableAccessTests
    {
        static int _iterations = 100000000;

        public static void Test()
        {
            var testObject = new ParentClass
            {
                ParentValue = 2,
                ChildClass = new ChildClass
                {
                    ChildValue = 3,
                    InnerChildClass = new InnerChildClass
                    {
                        NotNullableValue = 1,
                    }
                }
            };

            using (new PerformanceLogger("Access property in parent class"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = testObject.ParentValue;
                }
            }

            using (new PerformanceLogger("Access property in child class"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = testObject.ChildClass.ChildValue;
                }
            }

            using (new PerformanceLogger("Access property in inner child class"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = testObject.ChildClass.InnerChildClass.NotNullableValue;
                }
            }

            using (new PerformanceLogger("Access method argument"))
            {
                Iterate(testObject.ParentValue);
            }

            using (new PerformanceLogger("Access local variable"))
            {
                var localValue = testObject.ParentValue;
                for (int i = 0; i < _iterations; i++)
                {
                    var value = localValue;
                }
            }

            using (new PerformanceLogger("Access method argument via local variable"))
            {
                var localValue = testObject.ParentValue;
                Iterate(localValue);
            }
        }

        private static void Iterate(double argument)
        {
            for (int i = 0; i < _iterations; i++)
            {
                var value = argument;
            }
        }
    }
}
