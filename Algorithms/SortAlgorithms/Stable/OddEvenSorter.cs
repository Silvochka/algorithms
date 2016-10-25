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
    /// Could be run in parallel processors easily
    /// Stable
    /// </remarks>
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class OddEvenSorter<T> : ISorter<T> where T : IComparable
    {
        public void sort(T[] array)
        {
            var sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < array.Length - 1; i += 2)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        SortHelper.swap(array, i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < array.Length - 1; i += 2)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        SortHelper.swap(array, i, i + 1);
                        sorted = false;
                    }
                }
            }
        }
    }
}
