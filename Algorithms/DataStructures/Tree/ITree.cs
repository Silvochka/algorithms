using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Tree - abstract data type that simulates a hierarchical tree structure with a root value
    /// and subtrees of children  with a parent node, represented as a set of linked nodes.
    /// 
    /// Can be defined recursively as a collection of the nodes (starting as a root node) 
    /// where each node is a data structure consisting of a value together with a list of references to the nodes ("children")
    /// with the constraint that no reference is duplicated and none points to the root.
    /// 
    /// Altenativaly: connected grapth without cylcles, edges are not oriented and without weight.
    /// 
    /// Restrictions:
    /// 1. Root node cannot reference to itself - root couldn't has a parent
    /// 2. No Cycles - node can have only 1 parent
    /// 3. Connected parts - only 1 root.
    /// 
    /// Definitions:
    /// Root - top node of a tree
    /// Child - A node directly connected to another when moving away from the root
    /// Parent - converse notation of the Child
    /// Siblings - group of nodes with the same parent
    /// Descendant - node reachable by repeated proceeding from parent to child
    /// Ascendant - node reachable by repeated proceeding from child to parent
    /// Leaf (external node) - node without children
    /// Branch (internal node) - node with at least one child
    /// Edge - connection between nodes
    /// Path - sequence of nodes and edges connecting node with descendant
    /// Height of node = number of edges on the longest path between node and a leaf
    /// Height of tree = height of its root node
    /// Forest - set of n >= 0 disjoing trees
    /// 
    /// Definitions for balancing:
    /// Balance Factor of node = Height(node.Right) - Height(node.Left)
    /// </summary>
    /// <remarks>
    /// Common usage:
    /// Representing hierarchical data
    /// Storing data in a way that makes it efficiently searchable
    /// Representing sorted lists of data
    /// As a workflow for compositing digital images for visual effects
    /// Routing algorithms
    /// </remarks>
    public interface ITree<T, NodeType, TreeType> where T : IComparable<T>
                                        where NodeType : ITreeNode<T, NodeType>
                                        where TreeType : ITree<T, NodeType, TreeType>
    {
        NodeType Root { get; set; }

        bool Insert(T content);
        NodeType Find(T content);
        bool Remove(T content);
        void Traverse(TraverseDirection direction, Action<T> action, bool iterativeImplementation = false);
        bool Verify();
        T GetMin();
        T GetMax();
        NodeType GetPredecessor(T key);
        NodeType GetSuccessor(T key);
        T GetKElementInOrder(int index);
        TreeType SplitByKey(T key);
        void MergeWith(TreeType treeToMerge);
        void RotateLeft();
        void RotateRight();
        NodeType GetCommonRoot(T nodeContent1, T nodeContent2);
        int DistanceBetween(T nodeContent1, T nodeContent2);
    }

    public enum TraverseDirection
    {
        // Depth first:
        Infix,
        Prefix,
        Postfix,
        // Breadth first:
        Breadth
    }
}
