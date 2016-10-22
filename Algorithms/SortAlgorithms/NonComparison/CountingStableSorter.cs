namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Count how much items we have for each number
    /// Best:               n + k
    /// Average:            n + k
    /// Worst:              n + k
    /// Additional memory:  n + k
    /// where 0 < a[i] < k
    /// </summary>
    /// <remarks>
    /// Stable
    /// </remarks>
    public class CountingStableSorter : ISorter<int>
    {
        public int sort(int[] array)
        {
            var count = 0;

            if (array.Length < 2)
            {
                return count;
            }

            var maxValue = array[0];
            var minValue = array[0];

            for (var i = 1; i < array.Length; i++)              // find min and max to understand how much array length
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            int[] counter = new int[maxValue - minValue + 1];
            for (var i = 0; i < counter.Length; i++)
            {
                counter[i] = 0;
            }

            for (var i = 0; i < array.Length; i++)                          // put items to the counter
            {
                counter[array[i] - minValue]++;
            }

            for (var i = 1; i < counter.Length; i++)
            {
                counter[i] += counter[i - 1];
            }

            var resultArray = new int[array.Length];
            for (var i = array.Length - 1; i >= 0; i--)                        // place items back to array
            {
                counter[array[i] - minValue]--;
                resultArray[counter[array[i] - minValue]] = array[i];
            }

            for (var i = 0; i < array.Length; i++)                          // put items to the counter
            {
                array[i] = resultArray[i];
            }

            return count;
        }
    }
}
