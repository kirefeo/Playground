using Playground.Models;
using Playground.Performance;
using System.Collections.Generic;
using System.Linq;

namespace Playground.PerformanceTests
{
    class GetComparableObjectFromListPerformanceTests
    {
        static int _iterations = 10000;

        public static void Test()
        {
            var identifiers = new Identifier[_iterations];
            for (int i = 0; i < identifiers.Length; i++)
            {
                identifiers[i] = new Identifier
                {
                    Code = $"Code{i}",
                    Name = $"Name{i}",
                    Number = i
                };
            }

            var comparableObjects = new ComparableClass[_iterations];
            for (int i = 0; i < comparableObjects.Length; i++)
            {
                comparableObjects[i] = new ComparableClass
                {
                    Code = $"Code{i}",
                    Name = $"Name{i}",
                    Number = i,
                    Value = i
                };
            }
            
            var objectsWithIdentifier = new ClassWithIdentifier[_iterations];
            for (int i = 0; i < objectsWithIdentifier.Length; i++)
            {
                objectsWithIdentifier[i] = new ClassWithIdentifier
                {
                    Value = i,
                    Identifier = identifiers[i]
                };
            }
            var index = _iterations / 2;
            var identifier = identifiers[index];
            var identifierNumber = identifier.Number;



            using (new PerformanceLogger("Array - Get ClassWithIdentifier value by identifier single"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = objectsWithIdentifier.Where(o => o.Identifier == identifier).Select(o => o.Value).Single();
                }
            }

            using (new PerformanceLogger("Array - Get ClassWithIdentifier value by identifier first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = objectsWithIdentifier.Where(o => o.Identifier == identifier).Select(o => o.Value).First();
                }
            }

            using (new PerformanceLogger("Array - Get ClassWithIdentifier by identifier first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var comparableObject = objectsWithIdentifier.Where(o => o.Identifier == identifier).First();
                }
            }

            using (new PerformanceLogger("Array - Get ClassWithIdentifier with value from variable by identifier first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var comparableObject = objectsWithIdentifier.Where(o => o.Identifier == identifier).First();
                    var value = comparableObject.Value;
                }
            }

            using (new PerformanceLogger("HashSet - Get ClassWithIdentifier value by identifier single"))
            {
                var comparableHashSet = new HashSet<ClassWithIdentifier>(objectsWithIdentifier);

                for (int i = 0; i < _iterations; i++)
                {
                    var value = comparableHashSet.Where(o => o.Identifier == identifier).Select(o => o.Value).First();
                }
            }

            using (new PerformanceLogger("HashSet - Get ClassWithIdentifier value by identifier first"))
            {
                var comparableHashSet = new HashSet<ClassWithIdentifier>(objectsWithIdentifier);

                for (int i = 0; i < _iterations; i++)
                {
                    var value = comparableHashSet.Where(o => o.Identifier == identifier).Select(o => o.Value).First();
                }
            }

            using (new PerformanceLogger("Array - Get ComparableObject by identifier first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var comparableObject = objectsWithIdentifier.Where(o => o.Identifier == identifier).First();
                }
            }

            using (new PerformanceLogger("Array - Get ComparableObject with value from variable by identifier first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var comparableObject = objectsWithIdentifier.Where(o => o.Identifier == identifier).First();
                    var value = comparableObject.Value;
                }
            }
            
            using (new PerformanceLogger("Array - Get identifier first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = identifiers.Where(o => o == identifier).First();
                }
            }

            using (new PerformanceLogger("HashSet - Get identifier first"))
            {
                var identifierHashSet = new HashSet<Identifier>(identifiers);

                for (int i = 0; i < _iterations; i++)
                {
                    var value = identifierHashSet.Where(o => o == identifier).First();
                }
            }

            using (new PerformanceLogger("Array - Get identifier by number first"))
            {
                for (int i = 0; i < _iterations; i++)
                {
                    var value = identifiers.Where(o => o.Number == identifierNumber).First();
                }
            }

            using (new PerformanceLogger("HashSet - Get identifier by number first"))
            {
                var identifierHashSet = new HashSet<Identifier>(identifiers);

                for (int i = 0; i < _iterations; i++)
                {
                    var value = identifierHashSet.Where(o => o.Number == identifierNumber).First();
                }
            }
        }
    }
}
