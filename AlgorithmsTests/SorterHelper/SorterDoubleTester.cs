using System.Linq;
using Algorithms.SortAlgorithms;

namespace AlgorithmsTests.SortAlgorithms
{
    class SorterDoubleTester: ISorterTester<double>
    {
        private const int testLength = 50;
        public void TestSortedSequence(ISorter<double> sorter)
        {
            var baseSequense = Enumerable
                .Range(1, testLength)
                .Select(x => x + 0.5);
            var input = baseSequense.ToArray();
            var expected = baseSequense.ToArray();
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }

        public void TestReverseSortedSequence(ISorter<double> sorter)
        {
            var input = Enumerable
                .Range(-3, testLength)
                .Select(x => x + 0.5)
                .Reverse()
                .ToArray();

            var expected = Enumerable
                .Range(-3, testLength)
                .Select(x => x + 0.5)
                .ToArray();
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }

        public void TestRandomSequence(ISorter<double> sorter)
        {
            var input = new double[] { 4.5, 1.5, 2.5, 3.5, 5.5 };
            var expected = Enumerable
                .Range(1, 5)
                .Select(x => x + 0.5)
                .ToArray();
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }
    }
}
