using Algorithms.Helpers;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Searching first place with incorrect pair and swapping them
    /// Best:               O(n)
    /// Average:            O(n^2)
    /// Worst:              O(n^2)
    /// Additional memory:  1 
    /// </summary>
    /// <remarks>
    /// Similar like <see cref="InsertionSorter"/> but before insertion swap series occurs, instead of shifts
    /// Can works with similar speed as <see cref="InsertionSorter"/>
    /// j-optimization allows to jump to the latest compare place
    /// </remarks>
    class GnomeSorter : ISorter
    {
        public int sort(int[] array)
        {
            var count = 0;
            var i = 1;
            var j = 2;

            while (i < array.Length)
            {
                if (array[i-1] < array[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    SortHelper.swap(array, i - 1, i);
                    count++;
                    i--;

                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }

            return count;
        }
    }
}
