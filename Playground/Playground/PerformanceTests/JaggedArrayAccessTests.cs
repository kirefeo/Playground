using Playground.Models;
using Playground.Performance;

namespace Playground.PerformanceTests
{
    class JaggedArrayAccessTests
    {
        static int _iterations = 10000;
        static int _arraySize1 = 10000;
        static int _arraySize2 = 10000;
        
        public static void Test()
        {
            var jaggedArray = new double[_iterations][];
            for (int i = 0; i < _iterations; i++)
            {
                var array = new double[_arraySize2];
                for (int j = 0; j < _arraySize2; j++)
                {
                    array[j] = j;
                }
                jaggedArray[i] = array;
            }

            var testObject = new InnerChildClass
            {
                JaggedArray = jaggedArray
            };
            
            using (new PerformanceLogger("Call Property"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    for (int j = 0; j < testObject.JaggedArray[i].Length; j++)
                    {
                        var newLength = testObject.JaggedArray[i].Length - 1;
                    }
                }
            }

            using (new PerformanceLogger("Use variable for length instead of property"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var length = testObject.JaggedArray[i].Length;
                    for (int j = 0; j < length; j++)
                    {
                        var newLength = testObject.JaggedArray[i].Length - 1;
                    }
                }
            }

            using (new PerformanceLogger("Use variable for array instead of property"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var array = testObject.JaggedArray[i];
                    for (int j = 0; j < array.Length; j++)
                    {
                        var newLength = array.Length - 1;
                    }
                }
            }

            using (new PerformanceLogger("Use variable for length for both loops instead of property"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var length = testObject.JaggedArray[i].Length;
                    for (int j = 0; j < length; j++)
                    {
                        var newLength = length - 1;
                    }
                }
            }
        }
    }
}
