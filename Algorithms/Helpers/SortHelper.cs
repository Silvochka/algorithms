namespace Algorithms.Helpers
{
    static class SortHelper
    {
        public static void swap(int[] array, int i, int j)
        {
            array[i] += array[j];
            array[j] = array[i] - array[j];
            array[i] = array[i] - array[j];
        }
    }
}
