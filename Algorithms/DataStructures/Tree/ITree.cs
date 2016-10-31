namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Tree - abstract datat type that simulates a hierarchical tree structure with a root value
    /// and subtrees of children  with a parent node, represented as a set of linked nodes.
    /// 
    /// Can be defined recursively as a collection of the nodes (starting s a root node) 
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
    /// Ascending - node reachable by repeated proceeding from child to parent
    /// Leaf (external node) - node without children
    /// Branch (internal node) - node with at least one child
    /// Degree - number of subtrees of the node
    /// Edge - connection between nodes
    /// Path - sequence of nodes and edges connecting node with descendant
    /// Level = 1 + (number of connections between node and the root)
    /// Height of node = number of edges on the longest path between node and a leaf
    /// Height of tree = height of its root node
    /// Depth of node = number of edges from the root to the node
    /// Forest - set of n >= 0 disjoing trees
    /// </summary>
    public interface ITree<T>
    {
        void Insert(T content);
        bool Find(T content);
        bool Remove(T content);
    }
}
