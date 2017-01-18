using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructures.Graph
{
    /// <summary>
    /// Graph, could be oriented or not
    /// </summary>
    /// <typeparam name="T">Content type</typeparam>
    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes { get; }

        public Graph()
        {
            this.Nodes = new List<GraphNode<T>>();
        }

        public bool IsEmpty
        {
            get
            {
                return this.Nodes.Count == 0;
            }
        }

        public GraphNode<T> AddNode(T value)
        {
            var newNode = new GraphNode<T>(value);
            this.Nodes.Add(newNode);
            return newNode;
        }

        public bool AddEdge(GraphNode<T> node1, GraphNode<T> node2, bool directed = false)
        {
            if (!this.Nodes.Contains(node1) || !this.Nodes.Contains(node2))
            {
                return false;
            }

            this.AddToCollection(node1.OutputNodes, node2);
            this.AddToCollection(node2.InputNodes, node1);

            if (!directed)
            {
                this.AddToCollection(node2.OutputNodes, node1);
                this.AddToCollection(node1.InputNodes, node2);
            }

            return true;
        }

        public bool RemoveEdge(GraphNode<T> node1, GraphNode<T> node2, bool directed = false)
        {
            if (!this.Nodes.Contains(node1) || !this.Nodes.Contains(node2))
            {
                return false;
            }

            this.RemoveFromCollection(node1.OutputNodes, node2);
            this.RemoveFromCollection(node2.InputNodes, node1);

            if (!directed)
            {
                this.RemoveFromCollection(node2.OutputNodes, node1);
                this.RemoveFromCollection(node1.InputNodes, node2);
            }

            return true;
        }

        public bool RemoveNode(GraphNode<T> node)
        {
            if (!this.Nodes.Contains(node))
            {
                return false;
            }

            foreach (var edge in node.InputNodes)
            {
                this.RemoveFromCollection(edge.OutputNodes, node);
            }

            foreach (var edge in node.OutputNodes)
            {
                this.RemoveFromCollection(edge.InputNodes, node);
            }

            this.Nodes.Remove(node);
            return true;
        }

        public void ResetVisited()
        {
            foreach (var node in this.Nodes)
            {
                node.Visited = false;
            }
        }

        public bool AreConnected(GraphNode<T> node1, GraphNode<T> node2)
        {
            if (!this.Nodes.Contains(node1) || !this.Nodes.Contains(node2))
            {
                return false;
            }

            this.ResetVisited();

            var nodesToVisit = new Queue<GraphNode<T>>();
            nodesToVisit.Enqueue(node1);

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit.Dequeue();
                if (currentNode.Visited)
                {
                    continue;
                }

                currentNode.Visited = true;
                if (currentNode.OutputNodes.Contains(node2))
                {
                    return true;
                }

                foreach (var node in currentNode.OutputNodes)
                {
                    nodesToVisit.Enqueue(node);
                }
            }

            return false;
        }

        public List<GraphNode<T>> GetLexicographicOrder()
        {
            var result = new List<GraphNode<T>>();

            while (!this.IsEmpty)
            {
                var freeNodes = this.GetNodesWithoutInput();

                if (freeNodes.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                result.AddRange(freeNodes);

                foreach (var node in freeNodes)
                {
                    this.RemoveNode(node);
                }
            }

            return result;
        }

        private List<GraphNode<T>> GetNodesWithoutInput()
        {
            return this.Nodes.Where(x => x.InputNodes.Count() == 0).ToList();
        }

        private void AddToCollection(HashSet<GraphNode<T>> nodes, GraphNode<T> node)
        {
            if (!nodes.Contains(node))
            {
                nodes.Add(node);
            }
        }

        private void RemoveFromCollection(HashSet<GraphNode<T>> nodes, GraphNode<T> node)
        {
            if (nodes.Contains(node))
            {
                nodes.Remove(node);
            }
        }
    }
}
