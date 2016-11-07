using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// AVL tree node.
    /// Contains left node which content less than this.Content
    /// Contains right node which content >= this.Content
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public class AVLTreeNode<T> : BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public AVLTreeNode(T content)
            : base(content)
        {
        }

        public int BalanceFactor
        {
            get { return ((this.Right as AVLTreeNode<T>)?.Height ?? -1) - ((this.Left as AVLTreeNode<T>)?.Height ?? -1); }
        }

        private int height = 0;
        public override int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public override bool HasLeft
        {
            get
            {
                return this.Left is AVLTreeNode<T>;
            }
        }

        public override bool HasRight
        {
            get
            {
                return this.Right is AVLTreeNode<T>;
            }
        }

        internal int CalculatedHeight
        {
            get { return base.Height; }
        }
    }
}
