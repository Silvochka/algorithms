namespace Algorithms.Interview.Chapter1
{
    public static class Array
    {
        /// <summary>
        /// Rotating square array on 90 degrees clockwise
        /// </summary>
        /// <param name="array">Input array</param>
        public static void Rotate<T>(this T[,] array)
        {
            if (array == null || array.GetLength(0) != array.GetLength(1))
            {
                return;
            }

            // goes by layers
            for (var layer = 0; layer < array.GetLength(0) / 2; layer++)
            {
                var first = layer;
                var last = array.GetLength(0) - layer - 1;

                // goes by elements
                for (var j = first; j < last; j++)
                {
                    var offset = j - first;

                    // save top
                    var temp = array[layer, j];

                    // left to top
                    array[layer, j] = array[last - offset, layer];

                    // bottom to left
                    array[last - offset, layer] = array[last, last - offset];

                    // right to bottom 
                    array[last, last - offset] = array[j, last];

                    // top to right
                    array[j, last] = temp;
                }
            }
        }

        /// <summary>
        /// Set zero in columns and rows where array has at least 1 zero
        /// </summary>
        /// <param name="array">Input array</param>
        public static void Zerofy(this int[,] array)
        {
            if (array == null)
            {
                return;
            }

            bool[] zeroRows = new bool[array.GetLength(0)];
            bool[] zeroColumns = new bool[array.GetLength(1)];

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] == 0)
                    {
                        zeroRows[i] = true;
                        zeroColumns[j] = true;
                    }
                }
            }

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (zeroRows[i] || zeroColumns[j])
                    {
                        array[i, j] = 0;
                    }
                }
            }
        }
    }
}
