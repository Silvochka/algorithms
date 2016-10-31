using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Binary search tree node.
    /// Contains left node which content less than this.Content
    /// Contains right node which content >= this.Content
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public class BinarySearchTreeNode<T> : IComparable<BinarySearchTreeNode<T>> where T : IComparable<T>
    {
        public T Content { get; set; }
        public BinarySearchTreeNode<T> Parent { get; set; }
        public BinarySearchTreeNode<T> Left { get; set; }
        public BinarySearchTreeNode<T> Right { get; set; }

        public BinarySearchTreeNode(T content)
        {
            this.Content = content;
        }

        public bool HasLeft
        {
            get { return this.Left != null; }
        }

        public bool HasRight
        {
            get { return this.Right != null; }
        }

        public bool IsLeftChild
        {
            get { return this.Parent != null && this.Parent.Left == this; }
        }

        public bool IsRightChild
        {
            get { return this.Parent != null && this.Parent.Right == this; }
        }

        public int CompareTo(BinarySearchTreeNode<T> other)
        {
            return this.Content != null && other != null
                ? this.Content.CompareTo(other.Content)
                : -1;
        }
    }
}
