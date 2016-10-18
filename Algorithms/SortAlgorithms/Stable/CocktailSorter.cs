using Algorithms.Helpers;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Goes back and forth, checking onl part between last swaps
    /// Best:               O(n)
    /// Average:            O(n^2)
    /// Worst:              O(n^2)
    /// Additional memory:  1 
    /// </summary>
    /// <remarks>
    /// Could be better than <see cref="BubbleSorter"/>
    /// Stable
    /// </remarks>
    class CocktailSorter : ISorter
    {
        public int sort(int[] array)
        {
            var count = 0;
            var left = 0;
            var right = array.Length - 1;

            while (left <= right)
            {
                for (var i = left; i < right; i++)
                {
                    count++;
                    if (array[i] > array[i + 1])
                    {
                        SortHelper.swap(array, i, i + 1);
                    }

                }
                right--;

                for (var i = right; i > left; i--)
                {
                    count++;
                    if (array[i - 1] > array[i])
                    {
                        SortHelper.swap(array, i - 1, i);
                    }

                }
                left++;
            }

            return count;
        }
    }
}
