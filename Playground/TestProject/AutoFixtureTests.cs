using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using Playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class AutoFixtureTests
    {
        [Test]
        public void MakeObject()
        {
            var fixture = new Fixture();
            
            var testModel = fixture.Build<TestModel>()
                .With(p => p.Dict1, new Dictionary<int, double[]> { { 1, new double[] { 1.0, 2.0 } } })
                .OmitAutoProperties()
                .Create();

            testModel.Dict1.Should().NotBeNull();
            testModel.Dict2.Should().BeNull();
        }

        [Test]
        public void MakeDictionaryFromCustomListUsingFromSeed()
        {
            var fixture = new Fixture();

            var keys = new List<EnumStruct>
            {
                new EnumStruct(Enum1.A, Enum2.A, Enum3.A, Enum4.A),
                new EnumStruct(Enum1.A, Enum2.A, Enum3.B, Enum4.B),
                new EnumStruct(Enum1.B, Enum2.B, Enum3.B, Enum4.B)
            };
            
            var testModel = fixture.Build<TestModel>()
                .FromSeed((tm) => new TestModel { DictWithStructKey = keys.ToDictionary(k => k, v => new double[] { 1.0, 2.0 }) })
                .OmitAutoProperties()
                .Create();

            var actualKeys = testModel.DictWithStructKey.Select(d => d.Key).ToList();

            actualKeys.Should().BeEquivalentTo(keys);
        }

        [Test]
        public void MakeDictionaryFromCustomListUsingDo()
        {
            var keys = new List<EnumStruct>
            {
                new EnumStruct(Enum1.A, Enum2.A, Enum3.A, Enum4.A),
                new EnumStruct(Enum1.A, Enum2.A, Enum3.B, Enum4.B),
                new EnumStruct(Enum1.B, Enum2.B, Enum3.B, Enum4.B)
            };

            var fixture2 = new Fixture().Build<TestModel>()
                .OmitAutoProperties();

            var testModel2 = fixture2.Do(x => x.DictWithStructKey = keys.ToDictionary(k => k, v => new double[] { 1.0, 2.0 }))
                .Create();

            var actualKeys2 = testModel2.DictWithStructKey.Select(d => d.Key).ToList();

            actualKeys2.Should().BeEquivalentTo(keys);
        }

        [Test]
        public void MakeMultipleDictionariesFromCustomListUsingDo()
        {
            var keys = new List<EnumStruct>
            {
                new EnumStruct(Enum1.A, Enum2.A, Enum3.A, Enum4.A),
                new EnumStruct(Enum1.A, Enum2.A, Enum3.B, Enum4.B),
                new EnumStruct(Enum1.B, Enum2.B, Enum3.B, Enum4.B)
            };

            var fixture2 = new Fixture().Build<TestModel>()
                .OmitAutoProperties();

            var testModel2 = fixture2
                .Do(x => x.DictWithStructKey = keys.ToDictionary(k => k, v => new double[] { 1.0, 2.0 }))
                .Do(x => x.DictWithStructKey2 = keys.ToDictionary(k => k, v => new double[] { 1.0, 2.0 }))
                .Create();

            var actualKeys = testModel2.DictWithStructKey.Select(d => d.Key).ToList();
            var actualKeys2 = testModel2.DictWithStructKey2.Select(d => d.Key).ToList();

            actualKeys.Should().BeEquivalentTo(keys);
            actualKeys2.Should().BeEquivalentTo(keys);
        }
    }
}
