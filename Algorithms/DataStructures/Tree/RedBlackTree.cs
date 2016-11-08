using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Self-balansing binary search tree.
    /// Root is always black
    /// All leaves (NIL) are black
    /// Both children of red node are black
    /// Every path from a given node to any of its descendant NIL nodes contains the same number of black nodes.
    /// 
    /// It leads to the critical property:
    /// The path from the root to the farthest leaf is no more than twice as long as 
    /// the path form the root to the nearest leaf.
    /// Result of that - rought height-balanced. 
    /// It leads that worst case of Inserting/Searching/Removing to be more efficient unlike <see cref="BinarySearchTree{T}"/>
    /// 
    /// Definitions:
    /// Black depth of node = number of black nodes from the root to a node
    /// Black height of RB tree = uniform number of black nodes in all paths from root to leaves
    /// Add:      O(log n)
    /// Search:   O(log n)
    /// Remove:   O(log n)
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    /// <remarks>
    /// Is height-balanced, not weight-balanced.
    /// So sibling nodes can have hugely differing numbers of descendants
    /// </remarks>
    public class RedBlackTree<T> : BinarySearchTree<T, RedBlackTree<T>> where T : IComparable<T>
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
                this.Root = new RedBlackTreeNode<T>(content, NodeColor.Black);
                return true;
            }

            if (this.FindIn(this.Root, content) != null)
            {
                return false;
            }

            var insertedNode = new RedBlackTreeNode<T>(content, NodeColor.Red);
            base.InsertNodeTo(this.Root, insertedNode);
            this.UpdateColorOnInsert(insertedNode);

            return true;
        }

        public override void MergeWith(RedBlackTree<T> treeToMerge)
        {
            throw new NotSupportedException("Merge RB trees currently doesn't supported");
        }

        public override RedBlackTree<T> SplitByKey(T key)
        {
            throw new NotSupportedException("Splitting RB trees currently doesn't supported");
        }

        /// <summary>
        /// Manual rotation doesn't allowed in RB tree
        /// </summary>
        public override void RotateLeft()
        {
            throw new NotSupportedException("Manual rotating RB trees currently doesn't supported");
        }

        /// <summary>
        /// Manual rotation doesn't allowed in RB tree
        /// </summary>
        public override void RotateRight()
        {
            throw new NotSupportedException("Manual rotating RB trees currently doesn't supported");
        }

        /// <summary>
        /// Verifying RB tree node
        /// </summary>
        /// <param name="node">Tree node</param>
        /// <returns>True if RB tree node is valid</returns>
        protected override bool VerifyIn(BinarySearchTreeNode<T> node)
        {
            var redBlackNode = node as RedBlackTreeNode<T>;
            var left = node.Left as RedBlackTreeNode<T>;
            var right = node.Right as RedBlackTreeNode<T>;
            var root = this.Root as RedBlackTreeNode<T>;

            var isColorMatching = redBlackNode.IsRed
                ? ((!node.HasLeft || left.IsBlack) && (!node.HasRight || right.IsBlack))
                : true;

            return root.IsBlack
                && isColorMatching
                && (left?.BlackHeight ?? 1) == (right?.BlackHeight ?? 1)
                && base.VerifyIn(node);
        }

        protected override void Remove(BinarySearchTreeNode<T> node)
        {
            if (node.HasRight && node.HasLeft)
            {
                var leftHeight = node.Left?.Height ?? 0;
                var rightHeight = node.Right?.Height ?? 0;
                var nodeToReplace = leftHeight > rightHeight
                    ? this.GetPredecessor(node.Content)
                    : this.GetSuccessor(node.Content);

                node.Content = nodeToReplace.Content;
                node = nodeToReplace;
            }

            // has 1 or 0 child
            var redBlackNode = node as RedBlackTreeNode<T>;

            // if red and has no more than 1 child - it hasn't child
            if (redBlackNode.IsRed)
            {
                this.RemoveLeaf(node);
                return;
            }

            // node is black
            var child = (node.HasLeft
                ? node.Left
                : node.Right) as RedBlackTreeNode<T>;

            // if black node has only 1 red child - copy content and remove child
            // (red child cannot contain any nodes)
            if (child != null && child.IsRed)
            {
                node.Content = child.Content;
                this.RemoveLeaf(child);
                return;
            }

            // node is black and no childs (black node cannot has just 1 black child)
            this.UpdateColorOnRemove(redBlackNode);
            this.RemoveLeaf(node);
        }

        private void UpdateColorOnInsert(RedBlackTreeNode<T> node)
        {
            if (node == this.Root)
            {
                node.Color = NodeColor.Black;
                return;
            }

            node.Color = NodeColor.Red;

            var parent = node.Parent as RedBlackTreeNode<T>;
            // if parent is black then nothing to do - all properties are still valid
            if (parent.IsBlack)
            {
                return;
            }

            // else we have parent as red so node has grandparent and uncle (uncle can be NIL)
            var uncle = node.Uncle as RedBlackTreeNode<T>;
            var grandParent = node.Grandparent as RedBlackTreeNode<T>;
            if (uncle != null && uncle.IsRed)
            {
                // if parent and uncle boths reds then recoloring them to black
                // and recoloring grandparent to red
                parent.Color = NodeColor.Black;
                uncle.Color = NodeColor.Black;
                this.UpdateColorOnInsert(grandParent);
            }
            else
            {
                // parent is red and uncle is black (real or NIL)
                // rotating of node "between" parent and uncle in ordering
                if (node.IsRightChild && node.Parent.IsLeftChild)
                {
                    parent = this.RotateLeft(node.Parent) as RedBlackTreeNode<T>;
                    node = parent.Left as RedBlackTreeNode<T>;
                }
                else if (node.IsLeftChild && node.Parent.IsRightChild)
                {
                    parent = this.RotateRight(node.Parent) as RedBlackTreeNode<T>;
                    node = parent.Right as RedBlackTreeNode<T>;
                }

                // parent is red and uncle is black (real or NIL) and node is greater or lesser boths
                // then rotating tree in the grandparent
                grandParent.Color = NodeColor.Red;
                parent.Color = NodeColor.Black;
                if (node.IsLeftChild && node.Parent.IsLeftChild)
                {
                    this.RotateRight(node.Grandparent);
                }
                else
                {
                    this.RotateLeft(node.Grandparent);
                }
            }
        }

        private void UpdateColorOnRemove(RedBlackTreeNode<T> node)
        {
            if (!node.HasParent)
            {
                return;
            }

            // node is black
            var parent = node.Parent as RedBlackTreeNode<T>;
            var sibling = node.Sibling as RedBlackTreeNode<T>;

            if (sibling != null && sibling.IsRed)
            {
                sibling.Color = NodeColor.Black;
                parent.Color = NodeColor.Red;

                if (sibling.IsRightChild)
                {
                    this.RotateLeft(parent);
                    sibling = parent.Right as RedBlackTreeNode<T>;
                }
                else
                {
                    this.RotateRight(parent);
                    sibling = parent.Left as RedBlackTreeNode<T>;
                }
            }

            // if node, parent and sibling is black and terminate - recolor sibling to red and update color of parent
            if (parent.IsBlack && sibling.IsBlack && sibling.IsTerminate)
            {
                sibling.Color = NodeColor.Red;
                UpdateColorOnRemove(parent);
                return;
            }

            // if parent is red, sibling is black nd terminate - just recolor and that's all
            if (parent.IsRed && sibling.IsBlack && sibling.IsTerminate)
            {
                parent.Color = NodeColor.Black;
                sibling.Color = NodeColor.Red;
                return;
            }

            var leftChildOfSibling = sibling.Left as RedBlackTreeNode<T>;
            var rightChildOfSibling = sibling.Right as RedBlackTreeNode<T>;
            // cases when sibling has one red child "between"
            if (sibling.IsBlack)
            {
                if (node.IsLeftChild
                    && rightChildOfSibling == null
                    && leftChildOfSibling != null
                    && leftChildOfSibling.IsRed)
                {
                    sibling.Color = NodeColor.Red;
                    leftChildOfSibling.Color = NodeColor.Black;
                    this.RotateRight(sibling);
                    sibling = sibling.Parent as RedBlackTreeNode<T>;
                }

                if (node.IsRightChild
                    && leftChildOfSibling == null
                    && rightChildOfSibling != null
                    && rightChildOfSibling.IsRed)
                {
                    sibling.Color = NodeColor.Red;
                    rightChildOfSibling.Color = NodeColor.Black;
                    this.RotateLeft(sibling);
                    sibling = sibling.Parent as RedBlackTreeNode<T>;
                }
            }

            rightChildOfSibling = sibling.Right as RedBlackTreeNode<T>;
            leftChildOfSibling = sibling.Left as RedBlackTreeNode<T>;
            if (node.IsLeftChild
                && sibling.IsBlack
                && rightChildOfSibling != null
                && rightChildOfSibling.IsRed)
            {
                sibling.Color = parent.Color;
                parent.Color = NodeColor.Black;
                rightChildOfSibling.Color = NodeColor.Black;
                this.RotateLeft(parent);
            } else if (node.IsRightChild
                && sibling.IsBlack
                && leftChildOfSibling != null
                && leftChildOfSibling.IsRed)
            {
                sibling.Color = parent.Color;
                parent.Color = NodeColor.Black;
                leftChildOfSibling.Color = NodeColor.Black;
                this.RotateRight(parent);
            }
        }
    }
}
