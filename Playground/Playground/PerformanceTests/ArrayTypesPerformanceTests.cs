using Playground.Performance;

namespace Playground.PerformanceTests
{
    class ArrayTypesPerformanceTests
    {
        static int _iterations = 100000000;
        static int _arraySize1 = 10000;
        static int _arraySize2 = 10000;

        public static void Test()
        {
            int[][] jaggedArray;
            int[,] twoDimensionalArray;
            var mid1 = _arraySize1 / 2;
            var mid2 = _arraySize2 / 2;

            using (new PerformanceLogger("Create jagged array"))
            {
                jaggedArray = new int[_arraySize1][];
                for (int i = 0; i < _arraySize1; i++)
                {
                    var array = new int[_arraySize2];
                    for (int j = 0; j < _arraySize2; j++)
                    {
                        array[j] = j;
                    }
                    jaggedArray[i] = array;
                }
            }

            using (new PerformanceLogger("Create multi-dimensional array"))
            {
                twoDimensionalArray = new int[_arraySize1, _arraySize2];
                for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                    {
                        twoDimensionalArray[i, j] = j;
                    }
                }
            }

            using (new PerformanceLogger("Access jagged array"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = jaggedArray[mid1][mid2];
                }
            }

            using (new PerformanceLogger("Access multi-dimensional array"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = twoDimensionalArray[mid1, mid2];
                }
            }
        }
    }
}
