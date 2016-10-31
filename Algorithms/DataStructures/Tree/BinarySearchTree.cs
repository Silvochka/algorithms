using System;
using System.Collections.Generic;

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

        public void Traverse(TraverseDirection direction, Action<T> action, bool iterativeImplementation = false)
        {
            if (this.Root == null)
            {
                return;
            }

            if (direction == TraverseDirection.Breadth)
            {
                this.BreadthTraverse(action);
                return;
            }

            if (!iterativeImplementation)
            {
                this.TraverseIn(this.Root, direction, action);
            }
            else
            {
                switch (direction)
                {
                    case TraverseDirection.Infix:
                        this.InfixTraverse(action);
                        break;

                    case TraverseDirection.Prefix:
                        this.PrefixTraverse(action);
                        break;

                    case TraverseDirection.Postfix:
                        this.PostfixTraverse(action);
                        break;
                }
            }
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
                    else if (node.IsRightChild)
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

        private void TraverseIn(BinarySearchTreeNode<T> node, TraverseDirection direction, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            switch (direction)
            {
                // elements in order: left, node, right
                case TraverseDirection.Infix:
                    this.TraverseIn(node.Left, direction, action);
                    action(node.Content);
                    this.TraverseIn(node.Right, direction, action);
                    break;

                // elements like in tree: node, left, right
                case TraverseDirection.Prefix:
                    action(node.Content);
                    this.TraverseIn(node.Left, direction, action);
                    this.TraverseIn(node.Right, direction, action);
                    break;

                // elements 
                case TraverseDirection.Postfix:
                    this.TraverseIn(node.Left, direction, action);
                    this.TraverseIn(node.Right, direction, action);
                    action(node.Content);
                    break;

            }
        }

        private void InfixTraverse(Action<T> action)
        {
            var stack = new Stack<BinarySearchTreeNode<T>>();
            var currentNode = this.Root;
            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();
                    action(currentNode.Content);
                    currentNode = currentNode.Right;
                }
            }
        }

        private void PrefixTraverse(Action<T> action)
        {
            var stack = new Stack<BinarySearchTreeNode<T>>();
            stack.Push(this.Root);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                action(currentNode.Content);

                if (currentNode.HasRight)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.HasLeft)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }

        private void PostfixTraverse(Action<T> action)
        {
            var stack = new Stack<BinarySearchTreeNode<T>>();
            BinarySearchTreeNode<T> lastVisited = null;
            var currentNode = this.Root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    var peekNode = stack.Peek();

                    // if right node exists and traversing from left child - then move right
                    if (peekNode.HasRight && lastVisited != peekNode.Right)
                    {
                        currentNode = peekNode.Right;
                    }
                    else
                    {
                        action(peekNode.Content);
                        lastVisited = stack.Pop();
                    }
                }
            }
        }

        private void BreadthTraverse(Action<T> action)
        {
            var queue = new Queue<BinarySearchTreeNode<T>>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                action(currentNode.Content);

                if (currentNode.HasLeft)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.HasRight)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }
    }
}
