using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Tree node.
    /// 
    /// Definitions:
    /// Height = number of edges on the longest path between node and a leaf
    /// Degree = number of subtrees of the node
    /// Depth = number of edges from the root to the node
    /// Level = 1 + (number of connections between node and the root) = 1 + Depth
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public interface ITreeNode<T, NodeType> : IComparable<ITreeNode<T, NodeType>>
        where T : IComparable<T>
        where NodeType : ITreeNode<T, NodeType>
    {
        T Content { get; set; }
        NodeType Parent { get; set; }

        bool HasParent { get; }
        bool IsTerminate { get; }
        int Count { get; }
        int Height { get; }
        int Degree { get; }
        int Depth { get; }
        int Level { get; }
    }
}
