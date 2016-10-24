using System;
using System.Collections.Generic;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// LSD - least significant digit
    /// Best:               O(wn)
    /// Average:            O(wn)
    /// Worst:              O(wn)
    /// Additional memory:  w + n
    /// where w - word size
    /// </summary>
    /// <remarks>
    /// Applicable for numbers: 1, 2, 3, 10, 15
    /// Supports sorting negative numbers
    /// </remarks>
    public class LSDRadixSorter : ISorter<int>
    {
        public int sort(int[] array)
        {
            var count = 0;

            List<int> negativeNumbers = new List<int>();
            List<int> positiveNumbers = new List<int>();

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    positiveNumbers.Add(array[i]);
                }
                else
                {
                    negativeNumbers.Add(-array[i]);
                }
            }

            this.internalSort(positiveNumbers);
            this.internalSort(negativeNumbers);

            var position = 0;
            for (var i = negativeNumbers.Count - 1; i >= 0; i--)
            {
                array[position] = -negativeNumbers[i];
                position++;
            }

            for (var i = 0; i < positiveNumbers.Count; i++)
            {
                array[position] = positiveNumbers[i];
                position++;
            }

            return count;
        }

        private void internalSort(List<int> array)
        {
            bool isFinished = false;
            int digitPosition = 0;

            Queue<int>[] buckets = new Queue<int>[10];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new Queue<int>();
            }

            while (!isFinished)
            {
                isFinished = true;

                foreach (int value in array)
                {
                    int bucketNumber = (value / (int)Math.Pow(10, digitPosition)) % 10;
                    if (bucketNumber > 0)
                    {
                        isFinished = false;
                    }

                    buckets[bucketNumber].Enqueue(value);
                }

                int i = 0;
                foreach (var bucket in buckets)
                {
                    while (bucket.Count > 0)
                    {
                        array[i] = bucket.Dequeue();
                        i++;
                    }
                }

                digitPosition++;
            }
        }
    }
}
