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

        [Test]
        public void TestSumReversed()
        {
            LinkedList<int> list = null;
            Assert.DoesNotThrow(() => list.SumReversed(null), "empty list doesn't sum something");

            list = new LinkedList<int>();
            list.AddToBegin(5);
            Assert.IsTrue(list.SumReversed(null).IsSameListAs(list), "check that sum with empty return same list");
            list = new LinkedList<int>(new int[] { 3, 0, 1 });
            LinkedList<int> list2 = new LinkedList<int>(new int[] { 0, 1 });
            Assert.IsTrue(list.SumReversed(list2).IsSameListAs(new LinkedList<int>(new int[] { 3, 1, 1 })), "check that sum works correct with different length");

            LinkedList<int> list3 = new LinkedList<int>(new int[] { 0, 0, 9 });
            Assert.IsTrue(list.SumReversed(list3).IsSameListAs(new LinkedList<int>(new int[] { 3, 0, 0, 1 })), "check that sum works correct with different length");
        }

        [Test]
        public void TestSum()
        {
            LinkedList<int> list = null;
            Assert.DoesNotThrow(() => list.Sum(null), "empty list doesn't sum something");

            list = new LinkedList<int>();
            list.AddToBegin(5);
            Assert.IsTrue(list.Sum(null).IsSameListAs(list), "check that sum with empty return same list");
            list = new LinkedList<int>(new int[] { 1, 0, 5 });
            LinkedList<int> list2 = new LinkedList<int>(new int[] { 1, 5 });
            Assert.IsTrue(list.Sum(list2).IsSameListAs(new LinkedList<int>(new int[] { 1, 2, 0 })), "check that sum works correct with different length");

            LinkedList<int> list3 = new LinkedList<int>(new int[] { 9, 1, 0 });
            Assert.IsTrue(list.Sum(list3).IsSameListAs(new LinkedList<int>(new int[] { 1, 0, 1, 5 })), "check that sum works correct with different length");

            LinkedList<int> list4 = new LinkedList<int>(new int[] { 1, 9, 1, 0 });
            Assert.IsTrue(list.Sum(list4).IsSameListAs(new LinkedList<int>(new int[] { 2, 0, 1, 5 })), "check that sum works correct with different length");
        }

        [Test]
        public void TestIsPalindrome()
        {
            LinkedList<int> list = null;
            Assert.DoesNotThrow(() => list.IsPalindrome(), "empty list is not palindrome");

            list = new LinkedList<int>(new int[] { 1 });
            Assert.IsTrue(list.IsPalindrome(), "list of 1 element is always palindrome");

            list = new LinkedList<int>(new int[] { 1, 2 });
            Assert.IsFalse(list.IsPalindrome(), "list of 2 different elements is not palindrome");

            list = new LinkedList<int>(new int[] { 1, 2, 1 });
            Assert.IsTrue(list.IsPalindrome(), "check that list of 3 elements is palindrome");

            list = new LinkedList<int>(new int[] { 1, 2, 2, 1 });
            Assert.IsTrue(list.IsPalindrome(), "check that list of 4 elements is palindrome");
        }

        [Test]
        public void TestIntersection()
        {
            LinkedList<int> list = null;
            Assert.IsNull(list.GetIntersection(null), "empty lists han't intersection");

            list = new LinkedList<int>(new int[] { 1, 2 });
            var list2 = new LinkedList<int>(new int[] { 1, 2 });

            Assert.IsNull(list.GetIntersection(list2), "different lists hasn't intersection");

            list2 = new LinkedList<int>();
            list2.AddToBegin(5);
            list2.Head.Next = list.Head.Next;

            Assert.IsNotNull(list.GetIntersection(list2), "test on intersection with same length");
            Assert.AreEqual(2, list.GetIntersection(list2).Content, "test on intersection with same length");

            list2.AddToBegin(1);
            Assert.IsNotNull(list.GetIntersection(list2), "test on intersection with different length");
            Assert.AreEqual(2, list.GetIntersection(list2).Content, "test on intersection with different length");
        }

        [Test]
        public void TestLoopStart()
        {
            LinkedList<int> list = null;
            Assert.IsNull(list.GetStartOfLoop(), "empty lists hasn't loop");

            list = new LinkedList<int>(new int[] { 1, 2 });

            Assert.IsNull(list.GetStartOfLoop(), "simple list hasn't loop");
            list.AddToEnd(3);
            list.Head.Next.Next.Next = list.Head.Next;

            Assert.IsNotNull(list.GetStartOfLoop(), "loop list has loop");
            Assert.AreEqual(2, list.GetStartOfLoop().Content, "loop list has loop");
        }
    }
}
