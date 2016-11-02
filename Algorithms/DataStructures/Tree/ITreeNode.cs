using System;

namespace Algorithms.DataStructures.Tree
{
    /// <summary>
    /// Tree node.
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public interface ITreeNode<T> : IComparable<ITreeNode<T>> where T : IComparable<T>
    {
        T Content { get; set; }
        BinarySearchTreeNode<T> Parent { get; set; }

        int Count { get; }
        int Height { get; }
        int Degree { get; }
        int Depth { get; }
        int Level { get; }
    }
}
