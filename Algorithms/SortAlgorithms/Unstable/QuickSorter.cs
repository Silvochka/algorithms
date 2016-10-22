using System;
using Algorithms.Helpers;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Speed based on selected pivot
    /// Best:               O(n log(n))
    /// Average:            O(n log(n))
    /// Worst:              O(n^2)
    /// Additional memory:  O(n log(n))
    /// </summary>
    /// <remarks>
    /// + In 3-way Best could be O(n)
    /// + Fatest in practice
    /// + Could be simple parallelized
    /// + Works with linked lists
    /// - Recursive
    /// - Fast degradation in "bad" inputes
    /// - Not stable
    /// </remarks>
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class QuickSorter<T> : ISorter<T> where T : IComparable
    {
        private int count = 0;
        public int sort(T[] array)
        {
            this.count = 0;
            this.quickSort(array, 0, array.Length - 1);
            return this.count;
        }

        private void quickSort(T[] array, int begin, int end)
        {
            if (begin >= end)
            {
                return;
            }

            int pivotIndex = this.partition(array, begin, end);

            this.quickSort(array, begin, pivotIndex - 1);
            this.quickSort(array, pivotIndex + 1, end);
        }

        private int partition(T[] array, int begin, int end)
        {
            T pivot = array[end];
            int i = begin;                          // index to insert values

            for (int j = begin; j < end; j++)
            {
                if (array[j].CompareTo(pivot) <= 0)              // if element less tham pivot - move to i-place
                {
                    SortHelper.swap(array, i, j);
                    i++;
                    this.count++;
                }
            }

            SortHelper.swap(array, i, end);         // place pivot to middle between 'less' and 'greater'
            this.count++;

            return i;
        }
    }
}
