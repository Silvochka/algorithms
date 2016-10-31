using System.Collections.Generic;
using Algorithms.DataStructures.Tree;
using NUnit.Framework;

namespace AlgorithmsTests.SortAlgorithms.DataStructures.Tree
{
    public class BinarySearchTreeTests
    {
        [Test]
        public void BinarySearchTreeInsertTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);

            Assert.IsTrue(tree.Root.Content == 5, "BST should has root == 5");
            Assert.IsTrue(tree.Root.Left.Content == 3, "BST should has root.Left == 3");
            Assert.IsTrue(tree.Root.Right.Content == 7, "BST should has root.Right == 7");
            Assert.IsTrue(tree.Root.Left.Left.Content == 2, "BST should has root.Left.Left == 2");
            Assert.IsTrue(tree.Root.Left.Right.Content == 4, "BST should has root.Left.Right == 4");
            Assert.IsTrue(tree.Root.Left.Left.Left.Content == 1, "BST should has root.Left.Left.Left == 1");
        }

        [Test]
        public void BinarySearchTreeFindTest()
        {
            var tree = new BinarySearchTree<int>();
            Assert.IsFalse(tree.Find(20));

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);

            Assert.IsTrue(tree.Find(5), "BST should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(3), "BST should be able to find inserted element 3");
            Assert.IsTrue(tree.Find(2), "BST should be able to find inserted element 2");
            Assert.IsFalse(tree.Find(20), "BST should not be able to find not-inserted element 20");
            Assert.IsFalse(tree.Find(17), "BST should not be able to find not-inserted element 17");
        }

        [Test]
        public void BinarySearchTreeRemoveTest()
        {
            var tree = new BinarySearchTree<int>();
            Assert.IsFalse(tree.Remove(20), "BST should not be able to find element in empty tree");

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);

            Assert.IsFalse(tree.Remove(20), "BST should not be able to find not-inserted element 20");
            Assert.IsTrue(tree.Remove(1), "BST should be able to remove inserted element 1");
            Assert.IsTrue(tree.Root.Left.Left.Left == null, "BST: element without children should be deleted");

            tree.Insert(1);
            Assert.IsTrue(tree.Remove(2), "BST should be able to remove inserted element 2 with 1 child");
            Assert.IsTrue(tree.Root.Left.Left.Content == 1, "BST: delelted element should has child's content");
            Assert.IsNotNull(tree.Root.Left.Left.Parent, "BST: parent of replaced element should be correct");
            Assert.IsTrue(tree.Root.Left.Left.Parent.Content == 3, "BST: parent of replaced element should be correct");
            Assert.IsTrue(tree.Root.Left.Left.Left == null, "BST: left child of replaced element shoud not be exists");

            tree.Insert(8);
            Assert.IsTrue(tree.Remove(5), "BST should be able to remove inserted element 5 with 2 child and Right.Left not exists");
            Assert.IsTrue(tree.Root.Content == 7, "BST: after deletion root should be == 7");
            Assert.IsTrue(tree.Root.Right.Content == 8, "BST: after deletion root.Right should be == 8");
            Assert.IsTrue(tree.Root.Right.Parent.Content == 7, "BST: after deletion reference to parent should be updated");

            Assert.IsTrue(tree.Remove(8));
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(16);
            tree.Insert(12);
            tree.Insert(10);
            tree.Insert(11);

            Assert.IsTrue(tree.Remove(9), "BST should be able to remove inserted element 9 with 2 child and Right.Left exists");
            Assert.IsTrue(tree.Root.Right.Content == 10, "BST: removed element should be replaced");
            Assert.IsTrue(tree.Root.Right.Parent.Content == 7, "BST: removed element should be replaced");
            Assert.IsTrue(tree.Root.Right.Left.Content == 8, "BST: removed element should has same left as ex-removed");
            Assert.IsTrue(tree.Root.Right.Right.Left.Left.Content == 11, "BST: original element of replaced should be removed");
            Assert.IsNotNull(tree.Root.Right.Right.Left.Left.Parent, "BST: parent reference should be correct");
            Assert.IsTrue(tree.Root.Right.Right.Left.Left.Parent.Content == 12, "BST: parent reference should be correct");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BinarySearchTreeInfixTraverseTest(bool iterativeImplementation)
        {
            var tree = new BinarySearchTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Infix, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Infix traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            tree.Traverse(TraverseDirection.Infix, (v) => traverseResult.Add(v), iterativeImplementation);
            var expectedResult = new int[7] { 1, 3, 4, 7, 8, 9, 15};

            CollectionAssert.AreEqual(
                expectedResult, 
                traverseResult,
                "Infix traverse should return correct reult with iterativeImplementation [{0}]",
                iterativeImplementation);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BinarySearchTreePrefixTraverseTest(bool iterativeImplementation)
        {
            var tree = new BinarySearchTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Prefix, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Prefix traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            tree.Traverse(TraverseDirection.Prefix, (v) => traverseResult.Add(v), iterativeImplementation);
            var expectedResult = new int[7] { 7, 3, 1, 4, 9, 8, 15 };

            CollectionAssert.AreEqual(
                expectedResult,
                traverseResult, 
                "Prefix traverse should return correct reult with iterativeImplementation [{0}]",
                iterativeImplementation);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BinarySearchTreePostfixTraverseTest(bool iterativeImplementation)
        {
            var tree = new BinarySearchTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Postfix, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Postfix traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            tree.Traverse(TraverseDirection.Postfix, (v) => traverseResult.Add(v), iterativeImplementation);
            var expectedResult = new int[7] { 1, 4, 3, 8, 15, 9, 7 };

            CollectionAssert.AreEqual(
                expectedResult,
                traverseResult, 
                "Postfix traverse should return correct reult with iterativeImplementation [{0}]",
                iterativeImplementation);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BinarySearchTreeBreadthTraverseTest(bool iterativeImplementation)
        {
            var tree = new BinarySearchTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Breadth, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Breadth traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            tree.Traverse(TraverseDirection.Breadth, (v) => traverseResult.Add(v), iterativeImplementation);
            var expectedResult = new int[7] { 7, 3, 9, 1, 4, 8, 15 };

            CollectionAssert.AreEqual(
                expectedResult,
                traverseResult,
                "Breadth traverse should return correct reult with iterativeImplementation [{0}]",
                iterativeImplementation);
        }

        public void BinarySearchTreeVerifyTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            Assert.IsTrue(tree.Verify(), "Auto-generated BST should be verified successfully");
            tree.Root.Content = 0;
            Assert.IsFalse(tree.Verify(), "Manually broken BST should be verified not successfully");
        }
    }
}
