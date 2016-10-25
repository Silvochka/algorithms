using System;
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
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class SelectionSorter<T> : ISorter<T> where T : IComparable
    {
        public void sort(T[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < array.Length; j++)      // find minimal value
                {
                    if (array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }

                SortHelper.swap(array, i, min);                 // insert in the beginning
            }
        }
    }
}
