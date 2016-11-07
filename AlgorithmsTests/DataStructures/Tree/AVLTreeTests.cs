using System;
using System.Collections.Generic;
using Algorithms.DataStructures.Tree;
using NUnit.Framework;

namespace AlgorithmsTests.DataStructures.Tree
{
    public class AVLTreeTests
    {
        [Test]
        public void AVLInsertTest()
        {
            var tree = new AVLTree<int>();
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(1);
            Assert.IsFalse(tree.Insert(1), "AVL tree shouldn't be able to insert duplicated element");

            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after insertion");
            Assert.AreEqual(2, tree.Root.Content, "AVL tree should be rebalanced after insert and has root == 2");
        }

        [Test]
        public void AVLRebalanceTest()
        {
            var tree = new AVLTree<int>();
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(11);
            tree.Insert(12);

            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after insertion");
            Assert.AreEqual(6, tree.Root.Content, "AVL tree should be rebalanced after insert and has root == 2");

            tree.Insert(5);
            tree.Insert(4);
            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after insertion");

            tree.Insert(8);
            tree.Insert(7);
            tree.Insert(9);
            tree.Insert(10);
            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after insertion");

            tree.Insert(0);
            tree.Insert(-1);
            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after insertion");
        }

        [Test]
        public void AVLNotSupportedOperationTest()
        {
            var tree = new AVLTree<int>();
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(11);
            tree.Insert(12);

            Assert.Throws<NotSupportedException>(() => tree.RotateLeft(), "AVL tree doesn't allow rotating");
            Assert.Throws<NotSupportedException>(() => tree.RotateRight(), "AVL tree doesn't allow rotating");
            Assert.Throws<NotSupportedException>(() => tree.SplitByKey(0), "AVL tree doesn't allow splitting");
            Assert.Throws<NotSupportedException>(() => tree.MergeWith(new AVLTree<int>()), "AVL tree doesn't allow merging");
        }

        [Test]
        public void AVLRemoveTest()
        {
            var tree = new AVLTree<int>();
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(11);
            tree.Insert(12);

            Assert.IsTrue(tree.Remove(1), "AVL tree should be able to remove existed element");
            Assert.IsFalse(tree.Remove(-1), "AVL tree shouldn't be able to remove not-existed element");
            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after element removing");
            Assert.AreEqual(5, tree.Root.Count, "AVL tree should contain correct count of elements after removing");

            tree.Insert(1);
            tree.Insert(9);
            Assert.IsTrue(tree.Remove(11), "AVL tree should be able to remove existed element with childs");
            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after element removing");
            Assert.AreEqual(6, tree.Root.Count, "AVL tree should contain correct count of elements after removing");

            tree.Insert(15);
            tree.Insert(10);
            Assert.IsTrue(tree.Remove(12), "AVL tree should be able to remove existed element with childs");
            Assert.IsTrue(tree.Verify(), "AVL tree should be valid after element removing");
            Assert.AreEqual(7, tree.Root.Count, "AVL tree should contain correct count of elements after removing");
        }

        [Test]
        public void AVLFindTest()
        {
            var tree = new AVLTree<int>();
            Assert.IsNull(tree.Find(20));

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);

            Assert.IsNotNull(tree.Find(5), "AVL should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(5).Content == 5, "AVL should be able to find inserted element 5");
            Assert.IsNotNull(tree.Find(3), "AVL should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(3).Content == 3, "AVL should be able to find inserted element 3");
            Assert.IsNotNull(tree.Find(2), "AVL should be able to find inserted element 5");
            Assert.IsTrue(tree.Find(2).Content == 2, "AVL should be able to find inserted element 2");
            Assert.IsNull(tree.Find(20), "AVL should not be able to find not-inserted element 20");
            Assert.IsNull(tree.Find(17), "AVL should not be able to find not-inserted element 17");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AVLInfixTraverseTest(bool iterativeImplementation)
        {
            var tree = new AVLTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Infix, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Infix traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            tree.Traverse(TraverseDirection.Infix, (v) => traverseResult.Add(v), iterativeImplementation);
            var expectedResult = new int[7] { 1, 3, 4, 7, 8, 9, 15 };

            CollectionAssert.AreEqual(
                expectedResult,
                traverseResult,
                "Infix traverse should return correct reult with iterativeImplementation [{0}]",
                iterativeImplementation);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AVLPrefixTraverseTest(bool iterativeImplementation)
        {
            var tree = new AVLTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Prefix, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Prefix traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(3);
            tree.Insert(7);
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
        public void AVLPostfixTraverseTest(bool iterativeImplementation)
        {
            var tree = new AVLTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Postfix, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Postfix traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(3);
            tree.Insert(7);
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
        public void AVLBreadthTraverseTest(bool iterativeImplementation)
        {
            var tree = new AVLTree<int>();
            var traverseResult = new List<int>();
            tree.Traverse(TraverseDirection.Breadth, (v) => traverseResult.Add(v), iterativeImplementation);
            Assert.IsTrue(
                traverseResult.Count == 0,
                "Breadth traverse on empty tree should be empty with iterativeImplementation [{0}]",
                iterativeImplementation);

            tree.Insert(3);
            tree.Insert(7);
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
        public void AVLVerifyTest()
        {
            var tree = new AVLTree<int>();
            Assert.IsTrue(tree.Verify(), "Empty AVL should be verified successfully");

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            Assert.IsTrue(tree.Verify(), "Auto-generated AVL should be verified successfully");
            tree.Root.Content = 0;
            Assert.IsFalse(tree.Verify(), "Manually broken AVL should be verified not successfully");
            tree.Root.Height = 7;
            Assert.IsFalse(tree.Verify(), "Manually broken AVL should be verified not successfully");
        }

        [Test]
        public void AVLGetMinTest()
        {
            var tree = new AVLTree<int>();
            Assert.IsTrue(tree.GetMin() == default(int), "AVL: Min value should be calculated correctly on empty tree");

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            Assert.IsTrue(tree.GetMin() == 1, "AVL: Min value should be calculated correctly");
        }

        [Test]
        public void AVLGetMaxTest()
        {
            var tree = new AVLTree<int>();
            Assert.IsTrue(tree.GetMax() == default(int), "AVL: Max value should be calculated correctly on empty tree");

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(15);

            Assert.IsTrue(tree.GetMax() == 15, "AVL: Min value should be calculated correctly");
        }

        [Test]
        public void AVLPredecessorTest()
        {
            var tree = new AVLTree<int>();
            Assert.AreEqual(null, tree.GetPredecessor(0), "AVL: Predecessor on empty tree should return default");

            tree.Insert(64);
            tree.Insert(7);
            tree.Insert(93);
            tree.Insert(59);
            tree.Insert(73);
            tree.Insert(95);
            tree.Insert(70);

            Assert.AreEqual(null, tree.GetPredecessor(5), "AVL: Predecessor on not existed element should return default value");
            Assert.AreEqual(59, tree.GetPredecessor(64).Content, "AVL: Predecessor on root tree should return correct value");
            Assert.AreEqual(null, tree.GetPredecessor(7), "AVL: Predecessor on min value should return default");
            Assert.AreEqual(7, tree.GetPredecessor(59).Content, "AVL: Predecessor on value should return correct value");
            Assert.AreEqual(64, tree.GetPredecessor(70).Content, "AVL: Predecessor on value should return correct value");
            Assert.AreEqual(93, tree.GetPredecessor(95).Content, "AVL: Predecessor on max value should return correct value");
        }

        [Test]
        public void AVLSucecessorTest()
        {
            var tree = new AVLTree<int>();
            Assert.AreEqual(null, tree.GetSuccessor(0), "AVL: Succecessor on empty tree should return default");

            tree.Insert(64);
            tree.Insert(7);
            tree.Insert(93);
            tree.Insert(59);
            tree.Insert(73);
            tree.Insert(95);
            tree.Insert(70);

            Assert.AreEqual(null, tree.GetSuccessor(5), "AVL: Predecessor on not existed element should return default value");
            Assert.AreEqual(64, tree.GetSuccessor(59).Content, "AVL: Succecessor on tree should return correct value");
            Assert.AreEqual(null, tree.GetSuccessor(95), "AVL: Succecessor on max value should return default");
            Assert.AreEqual(59, tree.GetSuccessor(7).Content, "AVL: Succecessor on min value should return correct value");
            Assert.AreEqual(70, tree.GetSuccessor(64).Content, "AVL: Succecessor on root value should return correct value");
            Assert.AreEqual(95, tree.GetSuccessor(93).Content, "AVL: Succecessor on pre max value should return max value");
        }

        [Test]
        public void AVLGetKElementInOrderTest()
        {
            var tree = new AVLTree<int>();
            Assert.AreEqual(default(int), tree.GetKElementInOrder(5), "AVL: K-th element in order on empty tree should return default");

            tree.Insert(64);
            tree.Insert(7);
            tree.Insert(93);
            tree.Insert(59);
            tree.Insert(73);
            tree.Insert(95);
            tree.Insert(70);

            Assert.AreEqual(default(int), tree.GetKElementInOrder(-1), "AVL: -1 element should return default");
            Assert.AreEqual(7, tree.GetKElementInOrder(0), "AVL: 0-th element should return min value");
            Assert.AreEqual(59, tree.GetKElementInOrder(1), "AVL: 1-th element should return 1-th value");
            Assert.AreEqual(64, tree.GetKElementInOrder(2), "AVL: 2-th element should return root value");
            Assert.AreEqual(70, tree.GetKElementInOrder(3), "AVL: 3-th element should return 3-th value");
            Assert.AreEqual(73, tree.GetKElementInOrder(4), "AVL: 4-th element should return 4-th value");
            Assert.AreEqual(93, tree.GetKElementInOrder(5), "AVL: 5-th element should return 5-th value");
            Assert.AreEqual(95, tree.GetKElementInOrder(6), "AVL: 6-th element should return max value");
            Assert.AreEqual(default(int), tree.GetKElementInOrder(7), "AVL: 7-th element should return default");
        }

        [Test]
        public void AVLGetCommonRootTest()
        {
            var tree = new AVLTree<int>();
            tree.Insert(6);
            tree.Insert(10);
            tree.Insert(16);
            tree.Insert(3);
            tree.Insert(8);

            Assert.IsNull(tree.GetCommonRoot(1, 10), "Common root of not-existed values should be null");
            Assert.IsNull(tree.GetCommonRoot(1, 2), "Common root of not-existed values should be null");
            Assert.AreEqual(tree.Root, tree.GetCommonRoot(10, 10), "Common root of equal values should be same node");
            Assert.AreEqual(tree.Root, tree.GetCommonRoot(3, 16), "Common root should be found");
            Assert.AreEqual(tree.Root.Left, tree.GetCommonRoot(3, 8), "Common root should be found");
        }

        [Test]
        public void AVLGetDistanceBetweenTest()
        {
            var tree = new AVLTree<int>();
            tree.Insert(6);
            tree.Insert(10);
            tree.Insert(16);
            tree.Insert(3);
            tree.Insert(8);

            Assert.AreEqual(-1, tree.DistanceBetween(1, 10), "Distance between existed and not-existed values should be -1");
            Assert.AreEqual(-1, tree.DistanceBetween(1, 2), "Distance between not-existed values should be -1");
            Assert.AreEqual(0, tree.DistanceBetween(10, 10), "Distance between equal values should be 0");
            Assert.AreEqual(3, tree.DistanceBetween(3, 16), "Distance between should be calculated correctly");
            Assert.AreEqual(2, tree.DistanceBetween(3, 8), "Distance between should be calculated correctly");
        }
    }
}
