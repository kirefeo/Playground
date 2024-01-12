//using System;
//using System.Collections.Generic;
//using FizzWare.NBuilder;
//using FluentAssertions;
//using FluentAssertions.Execution;
//using NUnit.Framework;
//using Playground.Models;
//using Playground.Performance;

//namespace TestProject
//{
//    public class ComparisonPerformanceTests
//    {
//        private IList<ComparableClass> _listA;
//        private IList<ComparableClass> _listB;
//        private IList<ComparableClass> _listDifferentSize;

//        [SetUp]
//        public void Initialize()
//        {
//            _listA = Builder<ComparableClass>.CreateListOfSize(10000).Build();
//            _listB = _listA;
//        }

//        [Test]
//        public void TestFluentAssertionsEquivalentTo()
//        {
//            using (new PerformanceLogger("FluentAssertions - equivalent to"))
//            {
//                _listA.Should().BeEquivalentTo(_listB);
//            }

//            using (new PerformanceLogger("FluentAssertions - equivalent to, strict ordering"))
//            {
//                _listA.Should().BeEquivalentTo(_listB, options => options.WithStrictOrdering());
//            }

//            using (new PerformanceLogger("FluentAssertions - should be"))
//            {
//                for (int i = 0; i < _listA.Count; i++)
//                {
//                    _listA[i].Should().Be(_listB[i]);
//                }
//            }

//            using (new PerformanceLogger("FluentAssertions - should be with assertionscope"))
//            {
//                using (new AssertionScope())
//                {
//                    for (int i = 0; i < _listA.Count; i++)
//                    {
//                        _listA[i].Should().Be(_listB[i]);
//                    }
//                }
//            }

//            using (new PerformanceLogger("NUnit - Assert.Equals"))
//            {
//                for (int i = 0; i < _listA.Count; i++)
//                {
//                    Assert.AreEqual(_listA[i], _listB[i]);
//                }
//            }

//            using (new PerformanceLogger("MSTest - Assert.Equals"))
//            {
//                for (int i = 0; i < _listA.Count; i++)
//                {
//                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(_listA[i], _listB[i]);
//                }
//            }
//        }
//    }
//}
