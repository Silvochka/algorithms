using System;
using Algorithms.DataStructures.Tree;

namespace Algorithms.Interview.Chapter4
{
    public static class TreeExtensions
    {
        /// <summary>
        /// Created balanced binary search tree from sorted array
        /// </summary>
        /// <param name="values">Sorted values</param>
        public static BinarySearchTree<T> CreateBalancedBinarySearchTreeFromSortedArray<T>(T[] values)
            where T:IComparable<T>
        {
            var tree = new BinarySearchTree<T>();
            tree.Root = CreateBST(values, 0, values.Length - 1);

            return tree;
        }

        private static BinarySearchTreeNode<T> CreateBST<T>(T[] values, int start, int end)
            where T:IComparable<T>
        {
            if (end < start)
            {
                return null;
            }

            int middle = (int)Math.Ceiling((start + end) / 2.0);
            var node = new BinarySearchTreeNode<T>(values[middle]);

            node.Left = CreateBST(values, start, middle - 1);
            node.Right = CreateBST(values, middle + 1, end);

            return node;
        }
    }
}
