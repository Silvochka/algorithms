using System.Collections.Generic;

namespace Algorithms.DataStructures.Graph
{
    /// <summary>
    /// Graph node
    /// </summary>
    /// <typeparam name="T">Content type</typeparam>
    public class GraphNode<T>
    {
        public T Content { get; set; }
        public HashSet<GraphNode<T>> OutputNodes { get; }
        public HashSet<GraphNode<T>> InputNodes { get; }
        public bool Visited { get; set; }

        public GraphNode(T value)
        {
            this.Content = value;
            this.OutputNodes = new HashSet<GraphNode<T>>();
            this.InputNodes = new HashSet<GraphNode<T>>();
        }
    }
}
