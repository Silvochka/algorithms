using System;
using Algorithms.SortAlgorithms;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 4, 5, 1, 2, 3, 7, 6 };
            ISorter sorter = new MergeSorter();
            var count = sorter.sort(input);

            Console.WriteLine(count);
            foreach (var i in input)
            {
                Console.Write(i + " ");
            }

            Console.Read();
        }
    }
}
