using Algorithms.DataStructures.LinkedList;
using Algorithms.Interview.Chapter2;
using NUnit.Framework;

namespace AlgorithmsTests.Interview.Chapter2
{
    class LinkedListTests
    {
        [Test]
        public static void TestRemoveDuplicates()
        {
            LinkedList<int> list = null;
            Assert.DoesNotThrow(() => list.RemoveDuplicates(), "empty list hasn't duplicates");
            list = new LinkedList<int>();
            list.RemoveDuplicates();
            Assert.IsNull(list.Head, "empty list hasn't duplicates");

            list = new LinkedList<int>(new int[] { });
            list.RemoveDuplicates();
            Assert.IsNull(list.Head, "empty list hasn't duplicates");

            list = new LinkedList<int>(new int[] { 5, 5, 5, 5, 6, 6 });
            list.RemoveDuplicates();

            Assert.IsTrue(list.IsSameListAs(new LinkedList<int>(new int[] { 5, 6 })), "check that dulicated are removed");

            list = new LinkedList<int>();
            list.AddToBegin(10);
            list.RemoveDuplicates();
            Assert.IsTrue(list.IsSameListAs(new LinkedList<int>(new int[] { 10 })), "check that if no duplicates - then list is the same");
        }

        [Test]
        public void TestGetKFromEnd()
        {
            LinkedList<int> list = null;
            Assert.DoesNotThrow(() => list.GetKFromEnd(1), "empty list hasn't duplicates");
            list = new LinkedList<int>(new int[] { 5, 4, 3, 2, 1, 0 });
            Assert.AreEqual(5, list.GetKFromEnd(5).Content, "check getting first element");
            Assert.AreEqual(3, list.GetKFromEnd(3).Content, "check getting middle element");
            Assert.AreEqual(0, list.GetKFromEnd(0).Content, "check getting last element");
            Assert.IsNull(list.GetKFromEnd(6), "check when k > lengt");
        }

        [Test]
        public void TestRemoveFromMiddle()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.DoesNotThrow(() => list.Head.RemoveFromMiddle(), "cannot return first element");
            list = new LinkedList<int>(new int[] { 0, 1, 2 });

            Assert.DoesNotThrow(() => list.Head.Next.RemoveFromMiddle(), "cannot return first element");
            Assert.IsTrue(list.IsSameListAs(new LinkedList<int>(new int[] { 0, 2 })), "check that middle element has been removed");
        }

        [Test]
        public void TestSortAround()
        {
            LinkedList<int> list = null;
            Assert.DoesNotThrow(() => list.SortAround(1), "empty list doesn't run sorting");

            list = new LinkedList<int>();
            Assert.DoesNotThrow(() => list.SortAround(0), "if list is empty then no sort executed");

            list = new LinkedList<int>(new int[] { 2, 5, 3, 5, 0, 1, 2 });
            list.SortAround(5);
            Assert.IsTrue(list.IsSameListAs(new LinkedList<int>(new int[] { 2, 3, 0, 1, 2, 5, 5 })), "check that sort around works as expected");
            list.SortAround(10);
            Assert.IsTrue(list.IsSameListAs(new LinkedList<int>(new int[] { 2, 3, 0, 1, 2, 5, 5 })), "check that sort around by not-existed element works as expected");
            list.AddToBegin(-1);
            list.SortAround(-5);
            Assert.IsTrue(list.IsSameListAs(new LinkedList<int>(new int[] { -1, 2, 3, 0, 1, 2, 5, 5 })), "check that sort around by first element works as expected");
            Assert.IsFalse(list.IsSameListAs(new LinkedList<int>(new int[] { })), "check that sort around by first element works as expected");
            Assert.IsFalse(list.IsSameListAs(new LinkedList<int>(new int[] { -1, 1 })), "check that sort around by first element works as expected");
            Assert.IsFalse(list.IsSameListAs(null), "check that sort around by first element works as expected");
        }
    }
}
