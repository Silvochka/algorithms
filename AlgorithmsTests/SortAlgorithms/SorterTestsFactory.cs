using System;
using System.Linq;
using Algorithms.SortAlgorithms;
using NUnit.Framework;

namespace AlgorithmsTestss.SortAlgorithms
{
    [TestFixture]
    class SorterTestsFactory
    {
        Type[] sorterTypes;
        public SorterTestsFactory()
        {
            Type sorterType = typeof(ISorter);
            this.sorterTypes = AppDomain
               .CurrentDomain
               .GetAssemblies()
               .SelectMany(assembly => assembly.GetTypes())
               .Where(type => sorterType.IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface && !type.IsGenericTypeDefinition).ToArray();
        }

        [Test]
        public void TestAllSorters()
        {
            var sorterHelper = new SorterTestsHelper();
            foreach (Type sorterType in this.sorterTypes)
            {
                ISorter sorterImplementation = Activator.CreateInstance(sorterType) as ISorter;
                sorterHelper.Sorter = sorterImplementation;
                sorterHelper.TestSortedSequence();
                sorterHelper.TestReverseSortedSequence();
                sorterHelper.TestRandomSequence();
            }
        }
    }
}
