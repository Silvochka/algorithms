namespace Algorithms.Helpers
{
    static class SortHelper
    {
        public static void swap(int[] array, int i, int j)
        {
            if (i == j || i < 0 || j < 0 || i >= array.Length || j >= array.Length)
            {
                return;
            }

            array[i] += array[j];
            array[j] = array[i] - array[j];
            array[i] = array[i] - array[j];
        }
    }
}
