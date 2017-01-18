using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Self-balansing binary search tree.
    /// The heights of the 2 child subtrees of any node differ by at most one.
    /// If at any time they differ by more than 1 - rebalancing is done to restore this property. 
    /// Add:      O(log n)
    /// Search:   O(log n)
    /// Remove:   O(log n)
    /// 
    /// BalanceFactor has values in {-1, 0, 1} for each node in the tree
    /// If node has BF = -1 then it called "left-heavy"
    /// If node has BF =  1 then it called "right-heavy"
    /// If node has BF =  0 then it called "balanced"
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    /// <remarks>
    /// For lookup-intensive applications, faster than <see cref="RedBlackTree{T}"/>
    /// because they are more stricly balanced.
    /// Both are height-balanced, not weight-balanced.
    /// So sibling nodes can have hugely differing numbers of descendants
    /// </remarks>
    public class AVLTree<T> : BinarySearchTree<T, AVLTree<T>> where T : IComparable<T>
    {
        /// <summary>
        /// Insert content with balancing
        /// </summary>
        /// <param name="content">Content to insert</param>
        /// <returns>Does element was added</returns>
        public override bool Insert(T content)
        {
            if (this.Root == null)
            {
                this.Root = new AVLTreeNode<T>(content);
                return true;
            }

            if (this.FindIn(this.Root, content) != null)
            {
                return false;
            }

            var insertedNode = new AVLTreeNode<T>(content);
            base.InsertNodeTo(this.Root, insertedNode);
            this.RebalanceIn(insertedNode);
            return true;
        }

        public override void MergeWith(AVLTree<T> treeToMerge)
        {
            throw new NotSupportedException("Merge AVL trees currently doesn't supported");
        }

        public override AVLTree<T> SplitByKey(T key)
        {
            throw new NotSupportedException("Splitting AVL trees currently doesn't supported");
        }

        /// <summary>
        /// Manual rotation doesn't allowed in AVL tree
        /// </summary>
        public override void RotateLeft()
        {
            throw new NotSupportedException("Manual rotating AVL trees currently doesn't supported");
        }

        /// <summary>
        /// Manual rotation doesn't allowed in AVL tree
        /// </summary>
        public override void RotateRight()
        {
            throw new NotSupportedException("Manual rotating AVL trees currently doesn't supported");
        }

        /// <summary>
        /// Verifying AVL tree node
        /// </summary>
        /// <param name="node">Tree node</param>
        /// <param name="min">Tree min node</param>
        /// <param name="max">Tree max node</param>
        /// <returns>True if AVL tree node is valid</returns>
        protected override bool VerifyIn(BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> min = null, BinarySearchTreeNode<T> max = null)
        {
            var avlNode = node as AVLTreeNode<T>;

            return avlNode.CalculatedHeight == avlNode.Height
                && Math.Abs(avlNode.BalanceFactor) < 2
                && base.VerifyIn(node, min, max);
        }

        protected override void Remove(BinarySearchTreeNode<T> node)
        {
            if (node.IsTerminate)
            {
                var parentNode = node.Parent as AVLTreeNode<T>;
                this.RemoveLeaf(node);
                this.RebalanceIn(parentNode as AVLTreeNode<T>);
            }
            else
            {
                var leftHeight = node.Left?.Height ?? 0;
                var rightHeight = node.Right?.Height ?? 0;
                var nodeToReplace = leftHeight > rightHeight
                    ? this.GetPredecessor(node.Content)
                    : this.GetSuccessor(node.Content);

                node.Content = nodeToReplace.Content;
                this.Remove(nodeToReplace);
            }
        }

        /// <summary>
        /// Rebalancing tree
        /// </summary>
        /// <param name="node">Node to start rebalance</param>
        private void RebalanceIn(AVLTreeNode<T> node)
        {
            var currentNode = node;
            while (currentNode != null)
            {
                this.UpdateHeight(currentNode);

                var leftChild = currentNode.Left as AVLTreeNode<T>;
                var rightChild = currentNode.Right as AVLTreeNode<T>;

                if (currentNode.BalanceFactor == 2)
                {
                    if (rightChild.BalanceFactor < 0)
                    {
                        currentNode.Right.Height--;
                        currentNode.Right = this.RotateRight(currentNode.Right);
                        currentNode.Right.Height++;
                    }

                    currentNode.Height -= 2;
                    this.RotateLeft(currentNode);
                }

                if (currentNode.BalanceFactor == -2)
                {
                    if (leftChild.BalanceFactor > 0)
                    {
                        currentNode.Left.Height--;
                        currentNode.Left = this.RotateLeft(currentNode.Left);
                        currentNode.Left.Height++;
                    }

                    currentNode.Height -= 2;
                    this.RotateRight(currentNode);
                }

                currentNode = currentNode.Parent as AVLTreeNode<T>;
            }
        }

        private void UpdateHeight(AVLTreeNode<T> node)
        {
            if (node.IsTerminate)
            {
                node.Height = 0;
                return;
            }

            var leftChild = node.Left as AVLTreeNode<T>;
            var rightChild = node.Right as AVLTreeNode<T>;

            node.Height = 1 + Math.Max(
                leftChild?.Height ?? 0,
                rightChild?.Height ?? 0);
        }
    }
}
