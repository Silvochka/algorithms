using Algorithms.SortAlgorithms;

namespace AlgorithmsTests.SortAlgorithms
{
    interface ISorterTester<T>
    {
        void TestSortedSequence(ISorter<T> sorter);
        void TestReverseSortedSequence(ISorter<T> sorter);
        void TestRandomSequence(ISorter<T> sorter);
    }
}
