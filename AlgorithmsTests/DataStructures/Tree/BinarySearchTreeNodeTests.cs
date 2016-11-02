using Algorithms.DataStructures.Tree;
using NUnit.Framework;

namespace AlgorithmsTests.DataStructures.Tree
{
    public class BinarySearchTreeNodeTests
    {
        [Test]
        public void BinarySearchTreeNodeDegreeTest()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);

            Assert.AreEqual(2, tree.Root.Degree, "Root node should has 2 degree");
            Assert.AreEqual(0, tree.Root.Left.Degree, "Left node should has 0 degree");
        }

        [Test]
        public void BinarySearchTreeNodeDepthTest()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);

            Assert.AreEqual(0, tree.Root.Depth, "Root node should has 0 depth");
            Assert.AreEqual(1, tree.Root.Left.Depth, "Left node should has 1 depth");
        }

        [Test]
        public void BinarySearchTreeNodeLevelTest()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);

            Assert.AreEqual(1, tree.Root.Level, "Root node should has 1 level");
            Assert.AreEqual(2, tree.Root.Left.Level, "Left node should has 2 level");
        }
    }
}
