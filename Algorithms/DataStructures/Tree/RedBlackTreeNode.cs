using System;

namespace Algorithms.DataStructures.Tree
{
    public enum NodeColor
    {
        Red,
        Black
    }

    /// <summary>
    /// Red black tree node.
    /// Contains left node which content less than this.Content
    /// Contains right node which content >= this.Content
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public class RedBlackTreeNode<T> : BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public RedBlackTreeNode(T content, NodeColor color)
            : base(content)
        {
            this.Color = color;
        }

        public NodeColor Color { get; set; }

        public bool IsRed
        {
            get { return this.Color == NodeColor.Red; }
        }

        public bool IsBlack
        {
            get { return this.Color == NodeColor.Black; }
        }

        public int BlackHeight
        {
            get
            {
                var thisNodeBlackAdditionalHeight = this.IsBlack ? 1 : 0;
                if (this.IsTerminate)
                {
                    return 1 + thisNodeBlackAdditionalHeight;
                }

                if (this.HasLeft)
                {
                    return (this.Left as RedBlackTreeNode<T>).BlackHeight + thisNodeBlackAdditionalHeight;
                }
                else
                {
                    return (this.Right as RedBlackTreeNode<T>).BlackHeight + thisNodeBlackAdditionalHeight;
                }
            }
        }

        public override bool HasLeft
        {
            get
            {
                return this.Left is RedBlackTreeNode<T>;
            }
        }

        public override bool HasRight
        {
            get
            {
                return this.Right is RedBlackTreeNode<T>;
            }
        }

        public override bool HasParent
        {
            get
            {
                return this.Parent is RedBlackTreeNode<T>;
            }
        }
    }
}
