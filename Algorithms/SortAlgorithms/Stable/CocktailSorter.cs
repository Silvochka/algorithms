using System;
using Algorithms.Helpers;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Goes back and forth, checking only part between last swaps
    /// Best:               O(n)
    /// Average:            O(n^2)
    /// Worst:              O(n^2)
    /// Additional memory:  1 
    /// </summary>
    /// <remarks>
    /// Could be better than <see cref="BubbleSorter{T}"/>
    /// Stable
    /// </remarks>
    /// <typeparam name="T">Type of array's elements</typeparam>
    public class CocktailSorter<T> : ISorter<T> where T : IComparable
    {
        public void sort(T[] array)
        {
            var left = 0;
            var right = array.Length - 1;

            while (left <= right)
            {
                for (var i = left; i < right; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        SortHelper.swap(array, i, i + 1);
                    }

                }
                right--;

                for (var i = right; i > left; i--)
                {
                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        SortHelper.swap(array, i - 1, i);
                    }

                }
                left++;
            }
        }
    }
}
