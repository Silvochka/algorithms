using System;
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
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class BubbleSorter<T> : ISorter<T> where T : IComparable
    {
        public int sort(T[] array)
        {
            var count = 0;
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i; j < array.Length - 1; j++)
                {
                    count++;
                    if (array[i].CompareTo(array[j + 1]) > 0)
                    {
                        SortHelper.swap(array, i, j + 1);
                    }
                }
            }

            return count;
        }
    }
}
