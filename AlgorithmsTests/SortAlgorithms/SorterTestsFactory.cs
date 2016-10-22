using System;
using System.Linq;
using Algorithms.SortAlgorithms;
using NUnit.Framework;

namespace AlgorithmsTests.SortAlgorithms
{
    [TestFixture]
    class SorterTestsFactory
    {
        Type[] sorterTypes;
        Type[] allTypes;
        public SorterTestsFactory()
        {
            Type sorterType = typeof(ISorter<>);
            Type sorterHelperType = typeof(ISorterTester<>);

            this.allTypes = AppDomain
               .CurrentDomain
               .GetAssemblies()
               .SelectMany(assembly => assembly.GetTypes())
               .Where(type => !type.IsAbstract && !type.IsInterface)
               .ToArray();
            this.sorterTypes = this.allTypes
               .Where(type => type.GetInterface("ISorter`1") != null)
               .ToArray();
        }

        [Test]
        public void TestAllIntegerSorters()
        {
            this.TestAllSorters<int>();
        }

        [Test]
        public void TestAllDoubleSorters()
        {
            this.TestAllSorters<double>();
        }

        [Test]
        public void TestAllStringSorters()
        {
            this.TestAllSorters<string>();
        }

        [Test]
        public void TestAllCharSorters()
        {
            this.TestAllSorters<char>();
        }

        public void TestAllSorters<T>()
        {
            Type sorterTesterType = typeof(ISorterTester<T>);
            var sorterTesterTypes = this.allTypes
               .Where(type => sorterTesterType.IsAssignableFrom(type) && !type.IsGenericTypeDefinition)
               .ToArray();

            Assert.IsTrue(sorterTesterTypes.Any(), "there is no sorter for this type of data");
            var sorterHelper = Activator.CreateInstance(sorterTesterTypes[0]) as ISorterTester<T>;

            foreach (Type sorterType in this.sorterTypes)
            {
                ISorter<T> sorterIntegerImplementation = null;

                if (sorterType.IsGenericTypeDefinition)
                {
                    Type[] typeArgs = { typeof(T) };
                    Type constructed = sorterType.MakeGenericType(typeArgs);
                    sorterIntegerImplementation = Activator.CreateInstance(constructed) as ISorter<T>;
                }
                else if (typeof(ISorter<T>).IsAssignableFrom(sorterType))
                {
                    sorterIntegerImplementation = Activator.CreateInstance(sorterType) as ISorter<T>;
                }

                if (sorterIntegerImplementation != null)
                {
                    sorterHelper.TestSortedSequence(sorterIntegerImplementation);
                    sorterHelper.TestReverseSortedSequence(sorterIntegerImplementation);
                    sorterHelper.TestRandomSequence(sorterIntegerImplementation);
                }
            }
        }
    }
}
