using Algorithms.Helpers;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Best:               O(n^2)
    /// Average:            O(n^2)
    /// Worst:              O(n^2)
    /// Additional memory:  1 
    /// </summary>
    /// <remarks>
    /// Find min
    /// Place in begin
    /// Begin ++
    /// </remarks>
    public class SelectionSorter : ISorter
    {
        public int sort(int[] array)
        {
            var count = 0;
            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < array.Length; j++)      // find minimal value
                {
                    count++;
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                SortHelper.swap(array, i, min);                 // insert in the beginning
            }

            return count;
        }
    }
}
