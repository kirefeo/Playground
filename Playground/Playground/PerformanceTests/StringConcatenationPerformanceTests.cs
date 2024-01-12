using Playground.Performance;
using System.Text;

namespace Playground.PerformanceTests
{
    class StringConcatenationPerformanceTests
    {
        static int _iterations = 30000;

        public static void Test()
        {
            using (new PerformanceLogger("Using stringbuilder"))
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < _iterations; i++)
                {
                    sb.Append("Value 1");
                    sb.Append("Value 2");
                    sb.Append("Value 3");
                }

                string s = sb.ToString();
            }

            using (new PerformanceLogger("Using +"))
            {
                string s = string.Empty;

                for (int i = 0; i < _iterations; i++)
                {
                    s += "Value 1" + "Value 2" + "Value 3";
                }
            }

            using (new PerformanceLogger("Using +="))
            {
                string s = string.Empty;

                for (int i = 0; i < _iterations; i++)
                {
                    s += "Value 1";
                    s += "Value 2";
                    s += "Value 3";
                }
            }

            using (new PerformanceLogger("Using Concat()"))
            {
                string s = string.Empty;

                for (int i = 0; i < _iterations; i++)
                {
                    s += string.Concat("Value 1", "Value 2", "Value 3");
                }
            }

            using (new PerformanceLogger("Using Join()"))
            {
                string s = string.Empty;

                for (int i = 0; i < _iterations; i++)
                {
                    s += string.Join("", "Value 1", "Value 2", "Value 3");
                }
            }

            using (new PerformanceLogger("Using Format()"))
            {
                string s = string.Empty;

                var value1 = "Value 1";
                var value2 = "Value 2";
                var value3 = "Value 3";

                for (int i = 0; i < _iterations; i++)
                {
                    s += $"{value1}{value2}{value3}";
                }
            }
                        
            using (new PerformanceLogger("Using stringbuilder in loop"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Value 1");
                    sb.Append("Value 2");
                    sb.Append("Value 3");

                    var s = sb.ToString();
                }
            }

            using (new PerformanceLogger("Using + in loop"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var s = "Value 1" + "Value 2" + "Value 3";
                }
            }

            using (new PerformanceLogger("Using += in loop"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    string s = string.Empty;
                    s += "Value 1";
                    s += "Value 2";
                    s += "Value 3";
                }
            }

            using (new PerformanceLogger("Using Concat() in loop"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    string s = string.Concat("Value 1", "Value 2", "Value 3");
                }
            }

            using (new PerformanceLogger("Using Join() in loop"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    string s = string.Join("", "Value 1", "Value 2", "Value 3");
                }
            }

            using (new PerformanceLogger("Using Format() in loop"))
            {
                

                for (int i = 0; i < _iterations; i++)
                {
                    var value1 = "Value 1";
                    var value2 = "Value 2";
                    var value3 = "Value 3";
                    string s = $"{value1}{value2}{value3}";
                }
            }
        }
    }
}

