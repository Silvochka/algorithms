using System;
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
    /// Similar like <see cref="InsertionSorter{T}"/> but before insertion swap series occurs, instead of shifts
    /// Can works with similar speed as <see cref="InsertionSorter{T}"/>
    /// j-optimization allows to jump to the latest compare place
    /// </remarks>
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class GnomeSorter<T> : ISorter<T> where T : IComparable
    {
        public void sort(T[] array)
        {
            var i = 1;
            var j = 2;

            while (i < array.Length)
            {
                if (array[i - 1].CompareTo(array[i]) < 0)
                {
                    i = j;
                    j++;
                }
                else
                {
                    SortHelper.swap(array, i - 1, i);
                    i--;

                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }
    }
}
