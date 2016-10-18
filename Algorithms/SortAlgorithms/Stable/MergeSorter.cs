namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// "Divide and conquer"
    /// Best:               O(n log(n))
    /// Average:            O(n log(n))
    /// Worst:              O(n log(n))
    /// Additional memory:  n
    /// </summary>
    /// <remarks>
    /// + Works on strucctures with sequential access
    /// + Hasn't "bad" inputs
    /// + Stable
    /// - Best = Worst
    /// - Require O(n) additional memoty
    /// </remarks>
    class MergeSorter : ISorter
    {
        private int count = 0;
        public int sort(int[] array)
        {
            this.count = 0;
            this.mergeSort(array, 0, array.Length - 1);
            return this.count;
        }

        private void mergeSort(int[] array, int begin, int end)
        {
            if (begin >= end)
            {
                return;
            }

            int middle = (begin + end) / 2;

            this.mergeSort(array, begin, middle);
            this.mergeSort(array, middle + 1, end);

            this.merge(array, begin, end, middle);
        }

        private void merge(int[] array, int begin, int end, int middle)
        {
            var result = new int[array.Length];
            var left = begin;
            var right = middle + 1;
            var length = end - begin + 1;

            for (var i = begin; i <= end; i++)
            {
                if (left <= middle && right <= end)      //if we have both arrays
                {
                    if (array[left] < array[right])
                    {
                        this.count++;
                        result[i] = array[left];         // add minimal value
                        left++;
                    }
                    else
                    {
                        this.count++;
                        result[i] = array[right];
                        right++;
                    }
                }
                else if (left <= middle)                 // we have only left array
                {
                    result[i] = array[left];
                    left++;
                }
                else                                     // we have only right array
                {
                    result[i] = array[right];
                    right++;
                }
            }

            for (var i = 0; i < length; i++)
            {
                array[end] = result[end];
                end--;
            }
        }
    }
}
