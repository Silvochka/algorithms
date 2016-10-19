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
    /// Could be run in parallel processors easily
    /// Stable
    /// </remarks>
    public class OddEvenSorter : ISorter
    {
        public int sort(int[] array)
        {
            var count = 0;
            var sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < array.Length - 1; i += 2)
                {
                    count++;
                    if (array[i] > array[i + 1])
                    {
                        SortHelper.swap(array, i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < array.Length - 1; i += 2)
                {
                    count++;
                    if (array[i] > array[i + 1])
                    {
                        SortHelper.swap(array, i, i + 1);
                        sorted = false;
                    }
                }
            }

            return count;
        }
    }
}
