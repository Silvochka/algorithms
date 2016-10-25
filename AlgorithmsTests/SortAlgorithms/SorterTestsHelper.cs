using System.Linq;
using Algorithms.SortAlgorithms;
using NUnit.Framework;

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
                string.Format("Sorter [{0}] can't sort next sequence: [{1}]. Expected result: [{2}]. Actual result: [{3}]",
                    sorterAlgorithm.GetType().Name,
                    originalInput.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y),
                    expectedOutput.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y),
                    input.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y)));
        }

        public static void TestSorterOnEmptyData<T>(ISorter<T> sorterAlgorithm)
        {
            Assert.IsNotNull(sorterAlgorithm, "sorterAlgorithm is invalid");
            var input = new T[0];
            sorterAlgorithm.sort(input);
        }
    }
}
