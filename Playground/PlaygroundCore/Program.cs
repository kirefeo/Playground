using PlaygroundCore.PerformanceTests;
using System;

namespace PlaygroundCore
{
    class Program
    {
        static void Main(string[] args)
        {
            StringConcatenationPerformanceTests.Test();

            Console.ReadKey();
        }
    }
}
