using Algorithms.Helpers;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Best:               O(n)
    /// Average:            O(n^2)
    /// Worst:              O(n^2)
    /// Additional memory:  1 
    /// </summary>
    /// <remarks>
    /// Stable
    /// </remarks>
    class BubbleSorter : ISorter
    {
        public int sort(int[] array)
        {
            var count = 0;
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i; j < array.Length - 1; j++)
                {
                    count++;
                    if (array[i] > array[j + 1])
                    {
                        SortHelper.swap(array, i, j + 1);
                    }
                }
            }

            return count;
        }
    }
}
