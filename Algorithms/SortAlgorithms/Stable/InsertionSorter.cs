using System;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Take next element and insert into sorted sequence
    /// Best:               O(n)
    /// Average:            O(n^2)
    /// Worst:              O(n^2)
    /// Additional memory:  1 
    /// </summary>
    /// <remarks>
    /// + Simple implementation
    /// + Efficient for quite small data sets
    /// + More efficient than <see cref="BubbleSorter"/> and <see cref="SelectionSorter"/>
    /// + Adaptive
    /// + Stable
    /// + Online
    /// </remarks>
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class InsertionSorter<T> : ISorter<T> where T : IComparable
    {
        public int sort(T[] array)
        {
            var count = 0;

            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i]; // key to be inserted into sorted sequence
                var j = i - 1;

                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    count++;
                    array[j + 1] = array[j]; // shift sorted sequence while key is smaller
                    j--;
                }

                array[j + 1] = key; // insrt key to the correct place
            }

            return count;
        }
    }
}
