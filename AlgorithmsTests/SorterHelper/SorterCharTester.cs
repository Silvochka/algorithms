using Algorithms.SortAlgorithms;

namespace AlgorithmsTests.SortAlgorithms
{
    class SorterCharTester: ISorterTester<char>
    {
        public void TestSortedSequence(ISorter<char> sorter)
        {
            var input = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var expected = new char[] { 'a', 'b', 'c', 'd', 'e' };
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }

        public void TestReverseSortedSequence(ISorter<char> sorter)
        {
            var input = new char[] { 'e', 'd', 'c', 'b', 'a' };
            var expected = new char[] { 'a', 'b', 'c', 'd', 'e' };
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }

        public void TestRandomSequence(ISorter<char> sorter)
        {
            var input = new char[] { 'b', 'd', 'c', 'e', 'a' };
            var expected = new char[] { 'a', 'b', 'c', 'd', 'e' };
            SorterTestsHelper.TestSorter(input, expected, sorter);
        }
    }
}
