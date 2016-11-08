using System;
using Algorithms.DataStructures.Tree;
using NUnit.Framework;

namespace AlgorithmsTests.DataStructures.Tree
{
    public class RedBlackTreeTests
    {
        [Test]
        public void RedBlackTreeInsertTest()
        {
            var tree = new RedBlackTree<int>();
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(1);
            Assert.IsFalse(tree.Insert(1), "RB tree shouldn't be able to insert duplicated element");

            Assert.IsTrue(tree.Verify(), "RB tree should be valid after insertion");
            Assert.AreEqual(2, tree.Root.Content, "RB tree should be rebalanced after insert and has root == 2");
        }

        [Test]
        public void RedBlackTreeRebalanceTest()
        {
            var tree = new RedBlackTree<int>();
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(11);
            tree.Insert(15);

            Assert.IsTrue(tree.Verify(), "RB tree should be valid after insertion");
            Assert.AreEqual(2, tree.Root.Content, "RB tree should be rebalanced after insert and has root == 2");

            tree.Insert(5);
            tree.Insert(4);
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after insertion");

            tree.Insert(8);
            tree.Insert(7);
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after insertion");
            tree.Insert(9);
            tree.Insert(10);
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after insertion");

            tree.Insert(12);
            tree.Insert(13);
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after insertion");
        }

        [Test]
        public void RedBlackTreeNotSupportedOperationTest()
        {
            var tree = new RedBlackTree<int>();
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(11);
            tree.Insert(12);

            Assert.Throws<NotSupportedException>(() => tree.RotateLeft(), "RB tree doesn't allow rotating");
            Assert.Throws<NotSupportedException>(() => tree.RotateRight(), "RB tree doesn't allow rotating");
            Assert.Throws<NotSupportedException>(() => tree.SplitByKey(0), "RB tree doesn't allow splitting");
            Assert.Throws<NotSupportedException>(() => tree.MergeWith(new RedBlackTree<int>()), "RB tree doesn't allow merging");
        }

        [Test]
        public void RedBlackTreeRemoveTest()
        {
            var tree = new RedBlackTree<int>();
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            Assert.IsTrue(tree.Remove(3), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");

            tree.Insert(11);
            tree.Insert(100);

            Assert.IsFalse(tree.Remove(-1), "RB tree shouldn't be able to remove not-existed element");
            Assert.IsTrue(tree.Remove(1), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");
            Assert.AreEqual(4, tree.Root.Count, "RB tree should contain correct count of elements after removing");

            Assert.IsTrue(tree.Remove(2), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");

            tree.Insert(60);
            tree.Insert(30);
            tree.Insert(20);
            Assert.IsTrue(tree.Remove(6), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");
            Assert.AreEqual(5, tree.Root.Count, "RB tree should contain correct count of elements after removing");

            Assert.IsTrue(tree.Remove(60), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");

            tree.Insert(25);
            tree.Insert(28);
            Assert.IsTrue(tree.Remove(100), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");

            Assert.IsTrue(tree.Remove(25), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");

            Assert.IsTrue(tree.Remove(30), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");

            Assert.IsTrue(tree.Remove(11), "RB tree should be able to remove existed element");
            Assert.IsTrue(tree.Verify(), "RB tree should be valid after element removing");
        }
    }
}
