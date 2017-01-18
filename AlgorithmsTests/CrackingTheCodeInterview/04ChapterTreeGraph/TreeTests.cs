using Algorithms.Interview.Chapter4;
using NUnit.Framework;

namespace AlgorithmsTests.Interview.Chapter4
{
    class TreeTests
    {
        [Test]
        public void TestGeneratingBSTFromSortedArray()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6 };

            var tree = TreeExtensions.CreateBalancedBinarySearchTreeFromSortedArray(array);
            Assert.AreEqual(4, tree.Root.Content, "root should be middle of array");
            Assert.AreEqual(2, tree.Root.Left.Content, "check correctness of created BST");
            Assert.AreEqual(6, tree.Root.Right.Content, "check correctness of created BST");

            Assert.AreEqual(1, tree.Root.Left.Left.Content, "check correctness of created BST");
            Assert.AreEqual(3, tree.Root.Left.Right.Content, "check correctness of created BST");

            Assert.AreEqual(5, tree.Root.Right.Left.Content, "check correctness of created BST");
            Assert.IsNull(tree.Root.Right.Right, "check correctness of created BST");
        }
    }
}
