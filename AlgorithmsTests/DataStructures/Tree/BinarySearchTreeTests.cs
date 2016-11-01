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
            Assert.IsTrue(tree.Verify(), "BST after inserting values should be verified successfully");

            Assert.IsFalse(tree.Insert(4), "BST shouldn't insert duplicated content");
        }

        [Test]
        public void BinarySearchTreeFindTest()
        {
            var tree = new BinarySearchTree<int>();
            Assert.IsNull(tree.Find(20));

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);

            Assert.IsNotNull(tree.Find(5), "BST should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(5).Content == 5, "BST should be able to find inserted element 5");
            Assert.IsNotNull(tree.Find(3), "BST should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(3).Content == 3, "BST should be able to find inserted element 3");
            Assert.IsNotNull(tree.Find(2), "BST should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(2).Content == 2, "BST should be able to find inserted element 2");
            Assert.IsNull(tree.Find(20), "BST should not be able to find not-inserted element 20");
            Assert.IsNull(tree.Find(17), "BST should not be able to find not-inserted element 17");
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
            Assert.IsTrue(tree.Verify(), "BST after removing value should be verified successfully");

            tree.Insert(1);
            Assert.IsTrue(tree.Remove(2), "BST should be able to remove inserted element 2 with 1 child");
            Assert.IsTrue(tree.Root.Left.Left.Content == 1, "BST: delelted element should has child's content");
            Assert.IsNotNull(tree.Root.Left.Left.Parent, "BST: parent of replaced element should be correct");
            Assert.IsTrue(tree.Root.Left.Left.Parent.Content == 3, "BST: parent of replaced element should be correct");
            Assert.IsTrue(tree.Root.Left.Left.Left == null, "BST: left child of replaced element shoud not be exists");
            Assert.IsTrue(tree.Verify(), "BST after removing value should be verified successfully");

            tree.Insert(8);
            Assert.IsTrue(tree.Remove(5), "BST should be able to remove inserted element 5 with 2 child and Right.Left not exists");
            Assert.IsTrue(tree.Root.Content == 7, "BST: after deletion root should be == 7");
            Assert.IsTrue(tree.Root.Right.Content == 8, "BST: after deletion root.Right should be == 8");
            Assert.IsTrue(tree.Root.Right.Parent.Content == 7, "BST: after deletion reference to parent should be updated");
            Assert.IsTrue(tree.Verify(), "BST after removing value should be verified successfully");

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
            Assert.IsTrue(tree.Verify(), "BST after removing value should be verified successfully");
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

        [Test]
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

        [Test]
        public void BinarySearchTreeGetMinTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            Assert.IsTrue(tree.GetMin() == 1, "BST: Min value should be calculated correctly");
        }

        [Test]
        public void BinarySearchTreeGetMaxTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            Assert.IsTrue(tree.GetMax() == 15, "BST: Min value should be calculated correctly");
        }
        
        [Test]
        public void BinarySearchTreeSplittingTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);
            tree.Insert(6);
            tree.Insert(19);
            tree.Insert(27);
            tree.Insert(40);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(16);
            tree.Insert(23);
            tree.Insert(37);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(9);

            var lessValuesTree = tree.SplitByKey(26);
            Assert.IsNull(lessValuesTree, "BST: split by not-existed value should return null");

            lessValuesTree = tree.SplitByKey(19);
            Assert.IsNotNull(lessValuesTree, "BST: split by existed value should return not null tree");

            Assert.IsTrue(tree.Verify(), "BST after splitting values should be verified successfully");
            Assert.IsTrue(lessValuesTree.Verify(), "BST less values after splitting values should be verified successfully");

            Assert.AreEqual(19, tree.GetMin(), "BST after splitting values should has min = 19");
            Assert.IsTrue(lessValuesTree.GetMax() < 19, "BST after splitting less values should has max < 19");

            var lessLessValuesTree = lessValuesTree.SplitByKey(10);
            Assert.IsNotNull(lessLessValuesTree, "BST: split by existed value should return not null tree");

            Assert.IsTrue(lessValuesTree.Verify(), "BST after splitting values should be verified successfully");
            Assert.IsTrue(lessLessValuesTree.Verify(), "BST less values after splitting values should be verified successfully");

            Assert.AreEqual(10, lessValuesTree.GetMin(), "BST after splitting values should has min = 10");
            Assert.IsTrue(lessLessValuesTree.GetMax() < 10, "BST after splitting less values should has max < 10");

            var minValue = tree.GetMin();
            var lessGreaterValuesTree = tree.SplitByKey(minValue);
            Assert.IsNotNull(lessGreaterValuesTree, "BST: split by minimum value should return not null tree");

            Assert.IsTrue(tree.Verify(), "BST after splitting values should be verified successfully");
            Assert.IsTrue(lessGreaterValuesTree.Verify(), "BST greater values after splitting values should be verified successfully");

            Assert.IsNull(lessGreaterValuesTree.Root, "BST after splitting on min value tree with less values should be empty");
            Assert.AreEqual(minValue, tree.GetMin(), "BST after splitting less values should has min = 19");

            var maxValue = tree.GetMax();
            var lessMaxValuesTree = tree.SplitByKey(maxValue);
            Assert.IsNotNull(lessMaxValuesTree, "BST: split by maximum value should return not null tree");

            Assert.IsTrue(tree.Verify(), "BST after splitting values should be verified successfully");
            Assert.IsTrue(lessMaxValuesTree.Verify(), "BST greater values after splitting values should be verified successfully");

            Assert.AreEqual(40, lessMaxValuesTree.GetMax(), "BST after splitting on max value tree with less values should be empty");
            Assert.AreEqual(maxValue, tree.GetMin(), "BST after splitting greater values should has min = 19");
            Assert.AreEqual(maxValue, tree.GetMax(), "BST after splitting greater values should has max = 19");
        }
    }
}
