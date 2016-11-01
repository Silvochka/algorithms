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
    /// <remarks>Tree doesn't support not-unique keys</remarks>
    public class BinarySearchTree<T> : ITree<T, BinarySearchTreeNode<T>> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
        {
        }

        /// <summary>
        /// Inserts conent in the tree with respecting order
        /// </summary>
        /// <param name="content">Content to insert</param>
        /// <returns>True if content was inserted</returns>
        public bool Insert(T content)
        {
            if (this.Root == null)
            {
                this.Root = new BinarySearchTreeNode<T>(content);
                return true;
            }

            if (this.FindIn(this.Root, content) != null)
            {
                return false;
            }

            this.InsertTo(this.Root, content);
            return true;
        }

        /// <summary>
        /// Determines whether tree has this content
        /// </summary>
        /// <param name="content">Content to search</param>
        /// <returns>Node with this content</returns>
        public BinarySearchTreeNode<T> Find(T content)
        {
            if (this.Root == null)
            {
                return null;
            }

            return this.FindIn(this.Root, content);
        }

        /// <summary>
        /// Removes content from tree with respecting order
        /// </summary>
        /// <param name="content">Content to remove</param>
        /// <returns>Does element was successfully removed</returns>
        public bool Remove(T content)
        {
            if (this.Root == null)
            {
                return false;
            }

            return this.RemoveIn(this.Root, content);
        }

        /// <summary>
        /// Traverse the tree
        /// </summary>
        /// <param name="direction">Traverse direction</param>
        /// <param name="action">Which action should be acted on node</param>
        /// <param name="iterativeImplementation">Should use iterative implementation or recursive</param>
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

        /// <summary>
        /// Determines whether tree respects order
        /// </summary>
        /// <returns>True if tree respects order</returns>
        public bool Verify()
        {
            if (this.Root == null)
            {
                return true;
            }

            return this.VerifyIn(this.Root);
        }

        /// <summary>
        /// Get min value
        /// </summary>
        /// <returns>Min value of the tree</returns>
        public T GetMin()
        {
            if (this.Root == null)
            {
                return default(T);
            }

            var currentNode = this.Root;
            while (currentNode.HasLeft)
            {
                currentNode = currentNode.Left;
            }

            return currentNode.Content;
        }

        /// <summary>
        /// Get max value
        /// </summary>
        /// <returns>Max value of the tree</returns>
        public T GetMax()
        {
            if (this.Root == null)
            {
                return default(T);
            }

            var currentNode = this.Root;
            while (currentNode.HasRight)
            {
                currentNode = currentNode.Right;
            }

            return currentNode.Content;
        }

        /// <summary>
        /// Get predecessor of specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Predecessor of the key</returns>
        public T GetPredecessor(T key)
        {
            if (this.Root == null)
            {
                return default(T);
            }

            var currentNode = this.Find(key);
            if (currentNode == null)
            {
                return default(T);
            }

            if (currentNode.HasLeft)                // if has left node - all less nodes are in left
            {
                currentNode = currentNode.Left;
                while (currentNode.HasRight)        // and we nee to find max in left subtree
                {
                    currentNode = currentNode.Right;
                }

                return currentNode.Content;
            }

            // if node hasn't left subtree then go to the right while we can and then get its parent

            var parent = currentNode.Parent;
            while (parent != null && currentNode == parent.Left)
            {
                currentNode = parent;
                parent = currentNode.Parent;
            }

            return parent != null
                ? parent.Content
                : default(T);
        }

        /// <summary>
        /// Get Successor of specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Successor of the key</returns>
        public T GetSuccessor(T key)
        {
            if (this.Root == null)
            {
                return default(T);
            }

            var currentNode = this.Find(key);
            if (currentNode == null)
            {
                return default(T);
            }

            if (currentNode.HasRight)                // if has right node - all greater nodes are in right
            {
                currentNode = currentNode.Right;
                while (currentNode.HasLeft)          // and we nee to find min in right subtree
                {
                    currentNode = currentNode.Left;
                }

                return currentNode.Content;
            }

            // if node hasn't right subtree then go to the left while we can and then get its parent

            var parent = currentNode.Parent;
            while (parent != null && currentNode == parent.Right)
            {
                currentNode = parent;
                parent = currentNode.Parent;
            }

            return parent != null
                ? parent.Content
                : default(T);
        }

        /// <summary>
        /// Get k-th element in order
        /// </summary>
        /// <param name="index">Index of required element, based 0</param>
        /// <returns>K-th element in order</returns>
        public T GetKElementInOrder(int index)
        {
            if (this.Root == null || index < 0)
            {
                return default(T);
            }

            return this.GetKElementInOrderIn(this.Root, index);
        }

        /// <summary>
        /// Splitting current tree on 2 trees: values less than key and values >= key.
        /// </summary>
        /// <remarks>Current tree will also will be changes and will contains values >= key</remarks>
        /// <param name="key">Key to split</param>
        /// <returns>New tree where vaues less than key. If current tree hasn't key then tree would not be splitted</returns>
        public BinarySearchTree<T> SplitByKey(T key)
        {
            var splitter = this.Find(key);
            if (splitter == null)
            {
                return null;
            }

            var lessValues = splitter.Left;
            var greaterValues = splitter.Right;

            while (splitter.Parent != null)
            {
                if (splitter.IsLeftChild) // left child - so splitter and all its children less than splitter.Parent.Content
                {
                    splitter = splitter.Parent;         // now splitter - its parent
                    splitter.Left = greaterValues;      // move greater values of splitter to the parent.Left

                    if (greaterValues != null)
                    {
                        greaterValues.Parent = splitter;
                    }

                    greaterValues = splitter;           // greater values - its parent (because splitter is left child)
                }
                else                   // right child - so splitter and all its children greater than splitter.Parent.Content
                {
                    splitter = splitter.Parent;         // now splitter - its parent
                    splitter.Right = lessValues;        // move less values to the parent.Right because they are still greater
                    if (lessValues != null)
                    {
                        lessValues.Parent = splitter;
                    }

                    lessValues = splitter;
                }
            }

            // insert key if its required
            if (greaterValues != null)
            {
                greaterValues.Parent = null;
            }

            this.Root = greaterValues;
            this.Insert(key);

            var treeWithLessValues = new BinarySearchTree<T>();
            treeWithLessValues.Root = lessValues;
            if (lessValues != null)
            {
                lessValues.Parent = null;
            }

            return treeWithLessValues;   
        }

        ITree<T, BinarySearchTreeNode<T>> ITree<T, BinarySearchTreeNode<T>>.SplitByKey(T key)
        {
            return this.SplitByKey(key);
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

        private BinarySearchTreeNode<T> FindIn(BinarySearchTreeNode<T> node, T content)
        {
            if (node.Content.CompareTo(content) == 0)
            {
                return node;
            }

            if (node.Content.CompareTo(content) > 0)
            {
                return node.HasLeft 
                    ? this.FindIn(node.Left, content)
                    : null;
            }
            else
            {
                return node.HasRight
                    ? this.FindIn(node.Right, content)
                    : null;
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

        private bool VerifyIn(BinarySearchTreeNode<T> node)
        {
            if (node.HasLeft
                && (node.CompareTo(node.Left) <= 0
                    || !this.VerifyIn(node.Left)))
            {
                return false;
            }

            if (node.HasRight
                && (node.CompareTo(node.Right) > 0
                    || !this.VerifyIn(node.Right)))
            {
                return false;
            }

            return true;
        }

        private T GetKElementInOrderIn(BinarySearchTreeNode<T> node, int index)
        {
            if (node == null)
            {
                return default(T);
            }

            var elementsCountInLeft = this.GetCount(node.Left);
            if (elementsCountInLeft == index)
            {
                return node.Content;
            }

            if (elementsCountInLeft > index)
            {
                return this.GetKElementInOrderIn(node.Left, index);
            }

            // if on the left less than required - search in right
            // new index = indes - left - current node
            return this.GetKElementInOrderIn(node.Right, index - elementsCountInLeft - 1);
        }

        private int GetCount(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
        }
    }
}
