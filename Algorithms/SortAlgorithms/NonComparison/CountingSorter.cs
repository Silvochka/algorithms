namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Count how much items we have for each number
    /// Best:               n + k
    /// Average:            n + k
    /// Worst:              n + k
    /// Additional memory:  n + k
    /// where a[i] from 0 to k
    /// </summary>
    /// <remarks>
    /// Unstable
    /// </remarks>
    public class CountingSorter : ISorter<int>
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

            int position = 0;
            for (var i = 0; i < counter.Length; i++)                        // place items back to array
            {
                while (counter[i] > 0)
                {
                    array[position] = i + minValue;
                    position++;
                    counter[i]--;
                }
            }

            return count;
        }
    }
}
