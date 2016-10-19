using System.Linq;
using Algorithms.SortAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTestss.SortAlgorithms
{
    class SorterTestsHelper
    {
        public ISorter Sorter
        {
            get;
            set;
        }

        public void TestSortedSequence()
        {
            var input = Enumerable.Range(1, 50).ToArray();
            var expected = Enumerable.Range(1, 50).ToArray();
            this.TestSorter(input, expected, this.Sorter);
        }

        public void TestReverseSortedSequence()
        {
            var input = Enumerable.Range(-3, 25).Reverse().ToArray();
            var expected = Enumerable.Range(-3, 25).ToArray();
            this.TestSorter(input, expected, this.Sorter);
        }

        public void TestRandomSequence()
        {
            var input = new int[] { 4, 1, 2, 3, 5 };
            var expected = Enumerable.Range(1, 5).ToArray();
            this.TestSorter(input, expected, this.Sorter);
        }

        private void TestSorter(int[] input, int[] expectedOutput, ISorter sorterAlgorithm)
        {
            Assert.IsNotNull(input, "input is invalid");
            Assert.IsNotNull(expectedOutput, "expectedOutput is invalid");
            Assert.IsNotNull(sorterAlgorithm, "sorterAlgorithm is invalid");

            int[] originalInput = new int[input.Length];
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
