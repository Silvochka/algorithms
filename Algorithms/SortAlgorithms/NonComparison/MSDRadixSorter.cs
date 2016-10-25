using System.Collections.Generic;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// MSD - most significant digit
    /// Best:               O(wn)
    /// Average:            O(wn)
    /// Worst:              O(wn)
    /// Additional memory:  w + n
    /// where w - word size
    /// </summary>
    /// <remarks>
    /// Applicable for string: b, ba, c, d, e, f, g, h, i, j
    /// - Recursive
    /// - If w is small and alphabet is big - many space is wasting
    /// </remarks>
    public class MSDRadixSorter : ISorter<string>
    {
        public void sort(string[] array)
        {
            this.internalSort(array, 0);
        }

        private void internalSort(string[] array, int charPosition)
        {
            if (array.Length <= 1)
            {
                return;
            }

            List<string>[] buckets = new List<string>[128];
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<string>();
            }

            foreach (string value in array)
            {
                int bucketNumber = value.Length > charPosition
                    ? value[charPosition]
                    : 0;

                buckets[bucketNumber].Add(value);
            }

            charPosition++;
            int position = 0;
            foreach (var bucket in buckets)
            {
                if (bucket.Count > 0)
                {
                    var sortedBucket = bucket.ToArray();
                    this.internalSort(sortedBucket, charPosition);

                    foreach (var item in sortedBucket)
                    {
                        array[position] = item;
                        position++;
                    }
                }
            }
        }
    }
}
