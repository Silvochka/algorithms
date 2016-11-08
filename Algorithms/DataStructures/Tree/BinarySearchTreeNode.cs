using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Binary search tree node.
    /// Contains left node which content less than this.Content
    /// Contains right node which content >= this.Content
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public class BinarySearchTreeNode<T> : ITreeNode<T, BinarySearchTreeNode<T>> where T : IComparable<T>
    {
        public T Content { get; set; }
        public BinarySearchTreeNode<T> Parent { get; set; }
        public BinarySearchTreeNode<T> Left { get; set; }
        public BinarySearchTreeNode<T> Right { get; set; }

        public BinarySearchTreeNode(T content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Has left child
        /// </summary>
        public virtual bool HasLeft
        {
            get { return this.Left != null; }
        }

        /// <summary>
        /// Has right child
        /// </summary>
        public virtual bool HasRight
        {
            get { return this.Right != null; }
        }

        /// <summary>
        /// Is this node - left child of its parent
        /// </summary>
        public bool IsLeftChild
        {
            get { return this.Parent != null && this.Parent.Left == this; }
        }

        /// <summary>
        /// Is this node - right child of its parent
        /// </summary>
        public bool IsRightChild
        {
            get { return this.Parent != null && this.Parent.Right == this; }
        }

        /// <summary>
        /// Is this node terminate (leaf)
        /// </summary>
        public bool IsTerminate
        {
            get { return !this.HasRight && !this.HasLeft; }
        }

        /// <summary>
        /// Is this node has parent
        /// </summary>
        public virtual bool HasParent
        {
            get { return this.Parent != null; }
        }

        /// <summary>
        /// Count of node's subtree (+ current node)
        /// </summary>
        public int Count
        {
            get { return 1 + (this.Left?.Count ?? 0) + (this.Right?.Count ?? 0); }
        }

        /// <summary>
        /// Height of the node (0 for leaf)
        /// </summary>
        public virtual int Height
        {
            get { return this.GetHeight(this); }
            set { }
        }

        /// <summary>
        /// Degree of outgoing nodes
        /// </summary>
        public int Degree
        {
            get { return (this.HasLeft ? 1 : 0) + (this.HasRight ? 1 : 0); }
        }

        public int Depth
        {
            get
            {
                if (this.Parent == null)
                {
                    return 0;
                }

                return 1 + this.Parent.Depth;
            }
        }

        public int Level
        {
            get { return this.Depth + 1; }
        }

        public BinarySearchTreeNode<T> Sibling
        {
            get
            {
                return this.IsRightChild
                    ? this.Parent.Left
                    : this.Parent?.Right;
            }
        }

        public BinarySearchTreeNode<T> Uncle
        {
            get { return this.Parent?.Sibling; }
        }

        public BinarySearchTreeNode<T> Grandparent
        {
            get { return this.Parent?.Parent; }
        }

        private int GetHeight(BinarySearchTreeNode<T> node)
        {
            if (node.IsTerminate)
            {
                return 0;
            }

            var leftHeight = node.Left?.Height ?? 0;
            var rightHeight = node.Right?.Height ?? 0;

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int CompareTo(ITreeNode<T, BinarySearchTreeNode<T>> other)
        {
            return this.Content != null && other != null
                ? this.Content.CompareTo(other.Content)
                : -1;
        }
    }
}
