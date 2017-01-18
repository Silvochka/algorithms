using System;
using Algorithms.DataStructures.Graph;
using NUnit.Framework;

namespace AlgorithmsTests.DataStructures.Graph
{
    class GraphTests
    {
        [Test]
        public void TestGraphAreConnected()
        {
            var graph = new Graph<int>();
            var node1 = graph.AddNode(1);
            var node2 = graph.AddNode(2);
            var node3 = graph.AddNode(3);
            var node4 = graph.AddNode(4);

            graph.AddEdge(node1, node2);
            graph.AddEdge(node2, node3);

            Assert.IsTrue(graph.AreConnected(node1, node3), "nodes are connected via node2");
            Assert.IsFalse(graph.AreConnected(node1, node4), "nodes are not connected");

            var node5 = new GraphNode<int>(5);
            Assert.IsFalse(graph.AreConnected(node1, node5), "nodes are not connected");

            graph.AddEdge(node1, node1);
            Assert.IsFalse(graph.AddEdge(node1, node5), "cannot add edge between nodes not from graph");
            Assert.IsFalse(graph.RemoveEdge(node1, node5), "cannot remove edge between nodes not from graph");
            Assert.IsTrue(graph.AreConnected(node1, node3), "nodes are connected via node2");
        }

        [Test]
        public void TestLexicographicOrder()
        {
            var graph = new Graph<int>();
            var node1 = graph.AddNode(1);
            var node2 = graph.AddNode(2);

            graph.AddEdge(node1, node2);
            Assert.Throws<InvalidOperationException>(() => graph.GetLexicographicOrder(), "graph with dual dependencies hasn't lexicographic order");

            graph.RemoveEdge(node1, node2);
            var node3 = graph.AddNode(3);
            var node4 = graph.AddNode(4);

            graph.AddEdge(node1, node2, true);
            graph.AddEdge(node1, node3, true);
            graph.AddEdge(node1, node4, true);
            graph.AddEdge(node4, node2, true);

            var node5 = new GraphNode<int>(5);
            Assert.IsFalse(graph.RemoveNode(node5), "cannot remove node if graph hasn't this node");
            node5 = graph.AddNode(5);
            graph.AddEdge(node5, node1);
            graph.RemoveNode(node5);

            var order = graph.GetLexicographicOrder();
            Assert.AreEqual(4, order.Count, "order should has same count as nodes count");
            Assert.AreEqual(1, order[0].Content, "order should has same count as nodes count");
            Assert.AreEqual(3, order[1].Content, "order should has same count as nodes count");
            Assert.AreEqual(4, order[2].Content, "order should has same count as nodes count");
            Assert.AreEqual(2, order[3].Content, "order should has same count as nodes count");
        }
    }
}
