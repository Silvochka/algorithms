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
    public class BinarySearchTree<T> : BinarySearchTree<T, BinarySearchTree<T>> where T : IComparable<T>
    {
    }

    public class BinarySearchTree<T, TreeType> : ITree<T, BinarySearchTreeNode<T>, TreeType>
        where T : IComparable<T>
        where TreeType : BinarySearchTree<T, TreeType>
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
        public virtual bool Insert(T content)
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

            this.InsertNodeTo(this.Root, new BinarySearchTreeNode<T>(content));
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

            if (this.Root.Content.CompareTo(content) == 0 && this.Root.IsTerminate)
            {
                this.Root = null;
                return true;
            }

            var nodeToRemove = this.Find(content);
            if (nodeToRemove == null)
            {
                return false;
            }

            this.Remove(nodeToRemove);
            return true;
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

            return this.VerifyIn(this.Root, null, null);
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
        public BinarySearchTreeNode<T> GetPredecessor(T key)
        {
            if (this.Root == null)
            {
                return null;
            }

            var currentNode = this.Find(key);
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.HasLeft)                // if has left node - all less nodes are in left
            {
                currentNode = currentNode.Left;
                while (currentNode.HasRight)        // and we nee to find max in left subtree
                {
                    currentNode = currentNode.Right;
                }

                return currentNode;
            }

            // if node hasn't left subtree then go up while we are on the left side and take latest parent
            var parent = currentNode.Parent;
            while (parent != null && currentNode == parent.Left)
            {
                currentNode = parent;
                parent = currentNode.Parent;
            }

            return parent ?? null;
        }

        /// <summary>
        /// Get Successor of specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Successor of the key</returns>
        public BinarySearchTreeNode<T> GetSuccessor(T key)
        {
            if (this.Root == null)
            {
                return null;
            }

            var currentNode = this.Find(key);
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.HasRight)                // if has right node - all greater nodes are in right
            {
                currentNode = currentNode.Right;
                while (currentNode.HasLeft)          // and we nee to find min in right subtree
                {
                    currentNode = currentNode.Left;
                }

                return currentNode;
            }

            // if node hasn't right subtree then go up while we are on the right side and take latest parent
            var parent = currentNode.Parent;
            while (parent != null && currentNode == parent.Right)
            {
                currentNode = parent;
                parent = currentNode.Parent;
            }

            return parent ?? null;
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
        public virtual TreeType SplitByKey(T key)
        {
            var splitter = this.Find(key);
            if (splitter == null)
            {
                return null;
            }

            var lessValues = splitter.Left;
            var greaterValues = splitter.Right;

            while (splitter.HasParent)
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

            return treeWithLessValues as TreeType;
        }

        /// <summary>
        /// Merge 2 trees. Tree to merge should contains all values greater than current value 
        /// </summary>
        /// <param name="treeToMerge"></param>
        public virtual void MergeWith(TreeType treeToMerge)
        {
            if (treeToMerge == null || treeToMerge.Root == null)
            {
                return;
            }

            if (this.Root == null)
            {
                this.Root = treeToMerge.Root;
            }

            // if tree to merge has values more than current tree - not merge
            if (this.GetMax().CompareTo(treeToMerge.GetMin()) >= 0)
            {
                return;
            }

            this.Root = this.Merge(this.Root, treeToMerge.Root);
        }

        /// <summary>
        /// Rotates tree to the left relatively the root
        /// </summary>
        public virtual void RotateLeft()
        {
            this.RotateLeft(this.Root);
        }

        /// <summary>
        /// Rotates tree to the right relatively the root
        /// </summary>
        public virtual void RotateRight()
        {
            this.RotateRight(this.Root);
        }

        /// <summary>
        /// Get common root of given nodes' content
        /// </summary>
        /// <param name="node1">First node content</param>
        /// <param name="node2">Second node content</param>
        /// <returns>Common root node</returns>
        public BinarySearchTreeNode<T> GetCommonRoot(T nodeContent1, T nodeContent2)
        {
            var node1 = this.Find(nodeContent1);
            var node2 = this.Find(nodeContent2);

            if (node1 == node2)
            {
                return node1;
            }

            if (node1 == null || node2 == null)
            {
                return null;
            }

            var firstNodeParents = new List<BinarySearchTreeNode<T>>();
            firstNodeParents.Add(node1);
            var currentNode = node1;
            while (currentNode.HasParent)
            {
                firstNodeParents.Add(currentNode.Parent);
                currentNode = currentNode.Parent;
            }

            while (true)
            {
                if (firstNodeParents.Contains(node2))
                {
                    return node2;
                }

                node2 = node2.Parent;
            }
        }

        /// <summary>
        /// Calculated distance between nodes
        /// </summary>
        /// <param name="nodeContent1">Node 1 content</param>
        /// <param name="nodeContent2">Node 2 content</param>
        /// <returns>
        /// 0 if nodes are same
        /// -1 if some of content is not presented in this tree
        /// >0 if distance exists
        /// </returns>
        public int DistanceBetween(T nodeContent1, T nodeContent2)
        {
            var node1 = this.Find(nodeContent1);
            var node2 = this.Find(nodeContent2);

            if (node1 == null || node2 == null)
            {
                return -1;
            }

            if (node1 == node2)
            {
                return 0;
            }

            // common root for nodes from the same tree always exists: at least tree.Root
            var commonRoot = this.GetCommonRoot(nodeContent1, nodeContent2);
            return this.GetDistanceFromRoot(commonRoot, node1)
                 + this.GetDistanceFromRoot(commonRoot, node2);
        }

        protected void InsertNodeTo(BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> nodeToInsert)
        {
            if (node.CompareTo(nodeToInsert) > 0)
            {
                if (node.HasLeft)
                {
                    this.InsertNodeTo(node.Left, nodeToInsert);
                    return;
                }
                else
                {
                    node.Left = nodeToInsert;
                    node.Left.Parent = node;
                    return;
                }
            }
            else
            {
                if (node.HasRight)
                {
                    this.InsertNodeTo(node.Right, nodeToInsert);
                    return;
                }
                else
                {
                    node.Right = nodeToInsert;
                    node.Right.Parent = node;
                    return;
                }
            }
        }

        protected BinarySearchTreeNode<T> FindIn(BinarySearchTreeNode<T> node, T content)
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

        protected BinarySearchTreeNode<T> RotateLeft(BinarySearchTreeNode<T> node)
        {
            if (node == null || !node.HasRight)
            {
                return node;
            }

            var centerElements = node.Right.Left;

            var newPivot = node.Right;

            // move center elements to the old pivot -> right
            node.Right = centerElements;
            if (centerElements != null)
            {
                centerElements.Parent = node;
            }

            var oldPivot = node;

            // move pivot
            newPivot.Parent = node.Parent;
            newPivot.Left = oldPivot;
            if (node.IsLeftChild)
            {
                newPivot.Parent.Left = newPivot;
            }

            if (node.IsRightChild)
            {
                newPivot.Parent.Right = newPivot;
            }

            oldPivot.Parent = newPivot;

            if (node == this.Root)
            {
                this.Root = newPivot;
            }

            return newPivot;
        }

        protected BinarySearchTreeNode<T> RotateRight(BinarySearchTreeNode<T> node)
        {
            if (node == null || !node.HasLeft)
            {
                return node;
            }

            var centerElements = node.Left.Right;

            var newPivot = node.Left;

            // move center elements to the old pivot -> left
            node.Left = centerElements;
            if (centerElements != null)
            {
                centerElements.Parent = node;
            }

            var oldPivot = node;

            // move pivot
            newPivot.Parent = node.Parent;
            newPivot.Right = oldPivot;
            if (node.IsLeftChild)
            {
                newPivot.Parent.Left = newPivot;
            }

            if (node.IsRightChild)
            {
                newPivot.Parent.Right = newPivot;
            }

            oldPivot.Parent = newPivot;

            if (node == this.Root)
            {
                this.Root = newPivot;
            }

            return newPivot;
        }

        protected virtual void Remove(BinarySearchTreeNode<T> node)
        {
            // if node hasn't children then just remove this node
            if (node.IsTerminate)
            {
                this.RemoveLeaf(node);
                return;
            }

            // if node has only 1 child then replace node by child
            if (node.HasLeft ^ node.HasRight)
            {
                if (node.HasLeft)
                {
                    if (node.IsLeftChild)
                    {
                        node.Parent.Left = node.Left;
                    }
                    else
                    {
                        node.Parent.Right = node.Left;
                    }

                    node.Left.Parent = node.Parent;
                }
                else if (node.HasRight)
                {
                    if (node.IsLeftChild)
                    {
                        node.Parent.Left = node.Right;
                    }
                    else
                    {
                        node.Parent.Right = node.Right;
                    }

                    node.Right.Parent = node.Parent;
                }

                return;
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
                this.Remove(mostLeft);
            }
        }

        protected virtual bool VerifyIn(BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> min = null, BinarySearchTreeNode<T> max = null)
        {
            if ((min != null && node.CompareTo(min) <= 0) || (max != null && node.CompareTo(max) > 0))
            {
                return false;
            }

            return (!node.HasLeft || this.VerifyIn(node.Left, min, node)) && 
                (!node.HasRight || this.VerifyIn(node.Right, node, max));
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

        private T GetKElementInOrderIn(BinarySearchTreeNode<T> node, int index)
        {
            if (node == null)
            {
                return default(T);
            }

            var elementsCountInLeft = node.Left?.Count ?? 0;
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

        private BinarySearchTreeNode<T> Merge(BinarySearchTreeNode<T> t1, BinarySearchTreeNode<T> t2)
        {
            if (t1 == null)
            {
                return t2;
            }

            if (t2 == null)
            {
                return t1;
            }

            if (t1.Height > t2.Height)
            {
                // height of t1 is greater so let t1.Root will be main root
                var mergedTreeRoot = this.Merge(t1.Right, t2);
                t1.Right = mergedTreeRoot;
                mergedTreeRoot.Parent = t1;
                return t1;
            }
            else
            {
                // height of t2 is greater or equals so let t2.Root will be main root
                var mergedTreeRoot = this.Merge(t1, t2.Left);
                t2.Left = mergedTreeRoot;
                mergedTreeRoot.Parent = t2;
                return t2;
            }
        }

        private int GetDistanceFromRoot(BinarySearchTreeNode<T> rootNode, BinarySearchTreeNode<T> node)
        {
            if (node == rootNode)
            {
                return 0;
            }

            if (rootNode.CompareTo(node) > 0)  // go to the left
            {
                return 1 + this.GetDistanceFromRoot(rootNode.Left, node);
            }
            else
            {
                return 1 + this.GetDistanceFromRoot(rootNode.Right, node);
            }
        }

        protected void RemoveLeaf(BinarySearchTreeNode<T> node)
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
        }
    }
}
