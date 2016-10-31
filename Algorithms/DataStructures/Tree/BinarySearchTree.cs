using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Binary search tree
    /// Add:      O(log n)      up to    O(n)  
    /// Search:   O(log n)      up to    O(n)
    /// Remove:   O(log n)      up to    O(n)  
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class BinarySearchTree<T> : ITree<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
        {
        }

        public void Insert(T content)
        {
            if (this.Root == null)
            {
                this.Root = new BinarySearchTreeNode<T>(content);
                return;
            }

            this.InsertTo(this.Root, content);
        }

        public bool Find(T content)
        {
            if (this.Root == null)
            {
                return false;
            }

            return this.FindIn(this.Root, content);
        }

        public bool Remove(T content)
        {
            if (this.Root == null)
            {
                return false;
            }

            return this.RemoveIn(this.Root, content);
        }

        private void InsertTo(BinarySearchTreeNode<T> node, T content)
        {
            if (node.Content.CompareTo(content) > 0)
            {
                if (node.HasLeft)
                {
                    this.InsertTo(node.Left, content);
                    return;
                }
                else
                {
                    node.Left = new BinarySearchTreeNode<T>(content);
                    node.Left.Parent = node;
                }
            }
            else
            {
                if (node.HasRight)
                {
                    this.InsertTo(node.Right, content);
                    return;
                }
                else
                {
                    node.Right = new BinarySearchTreeNode<T>(content);
                    node.Right.Parent = node;
                }
            }
        }

        private bool FindIn(BinarySearchTreeNode<T> node, T content)
        {
            if (node.Content.CompareTo(content) == 0)
            {
                return true;
            }

            if (node.Content.CompareTo(content) > 0)
            {
                return node.HasLeft && this.FindIn(node.Left, content);
            }
            else
            {
                return node.HasRight && this.FindIn(node.Right, content);
            }
        }

        private bool RemoveIn(BinarySearchTreeNode<T> node, T content)
        {
            if (node.Content.CompareTo(content) == 0)
            {
                // if node hasn't children then just remove this node
                if (!node.HasLeft && !node.HasRight)
                {
                    if (node.IsLeftChild)
                    {
                        node.Parent.Left = null;
                    }
                    else if(node.IsRightChild)
                    {
                        node.Parent.Right = null;
                    }

                    node.Parent = null;
                    return true;
                }

                // if node has only 1 child then replace node by child
                if (node.HasLeft ^ node.HasRight)
                {
                    if (node.HasLeft)
                    {
                        node.Content = node.Left.Content;
                        node.Left.Parent = null;
                        node.Left = null;
                    }
                    else if (node.HasRight)
                    {
                        node.Content = node.Right.Content;
                        node.Right.Parent = null;
                        node.Right = null;
                    }

                    return true;
                }

                // if node has both childs and right child hasn't left subtree
                if (!node.Right.HasLeft)
                {
                    node.Content = node.Right.Content;
                    node.Right = node.Right.Right;
                    node.Right.Parent = node;
                }
                else // node has both childs and right child has both childs
                {
                    var mostLeft = node.Right.Left;
                    while (mostLeft.HasLeft)
                    {
                        mostLeft = mostLeft.Left;
                    }

                    node.Content = mostLeft.Content;
                    this.RemoveIn(mostLeft, mostLeft.Content);
                }

                return true;
            }

            if (node.Content.CompareTo(content) > 0)
            {
                return node.HasLeft && this.RemoveIn(node.Left, content);
            }
            else
            {
                return node.HasRight && this.RemoveIn(node.Right, content);
            }
        }
    }
}
