using System.Linq;
using Algorithms.SortAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests.SortAlgorithms
{
    class SorterTestsHelper
    {
        public static void TestSorter<T>(T[] input, T[] expectedOutput, ISorter<T> sorterAlgorithm)
        {
            Assert.IsNotNull(input, "input is invalid");
            Assert.IsNotNull(expectedOutput, "expectedOutput is invalid");
            Assert.IsNotNull(sorterAlgorithm, "sorterAlgorithm is invalid");

            T[] originalInput = new T[input.Length];
            input.CopyTo(originalInput, 0);
            sorterAlgorithm.sort(input);

            CollectionAssert.AreEqual(
                input,
                expectedOutput,
                string.Format("Sorter [{0}] can't sort next sequence: [{1}]. Actual result: [{2}]",
                    sorterAlgorithm.GetType().Name,
                    originalInput.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y),
                    input.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y)));
        }
    }
}
