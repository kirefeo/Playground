using Playground.Models;
using Playground.Performance;

namespace Playground.PerformanceTests
{
    class InstantiateClassPerformanceTests
    {
        static int _iterations = 100000000;

        public static void Test()
        {
            var testObject = new ParentClass
            {
                ChildClass = new ChildClass
                {
                    InnerChildClass = new InnerChildClass
                    {
                        NotNullableValue = 1,
                    }
                }
            };

            using (new PerformanceLogger("Class already initialized"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    testObject.ChildClass.InnerChildClass.NotNullableValue = i;
                }
            }

            using (new PerformanceLogger("Initialize class"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var innerChildClass = new InnerChildClass
                    {
                        NotNullableValue = i
                    };
                }
            }

            using (new PerformanceLogger("Initialize class - 2 layers"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var childClass = new ChildClass
                    {
                        InnerChildClass = new InnerChildClass
                        {
                            NotNullableValue = i
                        }
                    };
                }
            }

            using (new PerformanceLogger("Initialize class - 3 layers"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var parentClass = new ParentClass
                    {
                        ChildClass = new ChildClass
                        {
                            InnerChildClass = new InnerChildClass
                            {
                                NotNullableValue = i
                            }
                        }
                    };
                }
            }
        }
    }
}
