using Playground.ExpressionTrees;
using Playground.Models;
using Playground.Performance;

namespace Playground
{
    class ThrowIfNullPerformanceTests
    {
        static int _iterations = 10000;

        public static void Test()
        {
            var testObject = new ParentClass
            {
                ChildClass = new ChildClass
                {
                    InnerChildClass = new InnerChildClass
                    {
                        NotNullableValue = 1,
                        NullableValue1 = 10,
                        NullableValue2 = null
                    }
                }
            };

            using (new PerformanceLogger("ThrowIfNullSimple"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    ValidationHelper.ThrowIfNullSimple(testObject.ChildClass.InnerChildClass.NullableValue1);
                }
            }

            using (new PerformanceLogger("ThrowIfNull"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    ValidationHelper.ThrowIfNull(() => testObject.ChildClass.InnerChildClass.NullableValue1);
                }
            }

            using (new PerformanceLogger("ThrowIfNullFast"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    ValidationHelper.ThrowIfNullFast(() => testObject.ChildClass.InnerChildClass.NullableValue1);
                }
            }

            using (new PerformanceLogger("ThrowIfNullDescriptive"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    ValidationHelper.ThrowIfNullDescriptive(() => testObject.ChildClass.InnerChildClass.NullableValue1);
                }
            }

            using (new PerformanceLogger("ThrowIfNullDeep"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    ValidationHelper.ThrowIfNullDeep(() => testObject.ChildClass.InnerChildClass.NullableValue1);
                }
            }
        }
    }
}
