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

        public static void swap<T>(T[] array, int i, int j)
        {
            if (i == j || i < 0 || j < 0 || i >= array.Length || j >= array.Length)
            {
                return;
            }

            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
