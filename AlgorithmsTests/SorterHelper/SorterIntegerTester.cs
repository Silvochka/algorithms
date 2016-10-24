using System.Linq;
using Algorithms.SortAlgorithms;

namespace AlgorithmsTests.SortAlgorithms
{
    class SorterIntegerTester : ISorterTester<int>
    {
        private const int testLength = 50;
        public void TestSortedSequence(ISorter<int> sorter)
        {
            var baseSequense = Enumerable.Range(1, testLength);
            var input = baseSequense.ToArray();
            var expected = baseSequense.ToArray();
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }

        public void TestReverseSortedSequence(ISorter<int> sorter)
        {
            var input = Enumerable.Range(-3, testLength).Reverse().ToArray();
            var expected = Enumerable.Range(-3, testLength).ToArray();
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }

        public void TestRandomSequence(ISorter<int> sorter)
        {
            var input = new int[] { 45, 11, 299, 30, 51, 0 };
            var expected = new int[] { 0, 11, 30, 45, 51, 299 };
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }
    }
}
