namespace Algorithms.Helpers
{
    static class SortHelper
    {
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
