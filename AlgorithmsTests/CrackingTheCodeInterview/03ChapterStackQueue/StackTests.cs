using System;
using System.Collections.Generic;
using Algorithms.Interview.Chapter3;
using NUnit.Framework;

namespace AlgorithmsTests.Interview.Chapter3
{
    class StackTests
    {
        [Test]
        public void TestStackWithMin()
        {
            var stack = new StackWithMin();

            stack.Push(1);
            Assert.AreEqual(1, stack.Min, "stack has correct min value after pushing");

            stack.Push(2);
            Assert.AreEqual(1, stack.Min, "stack has correct min value after pushing");

            stack.Push(0);
            Assert.AreEqual(0, stack.Min, "stack has correct min value after pushing");

            stack.Pop();
            Assert.AreEqual(1, stack.Min, "stack has correct min value after popping");
        }

        [Test]
        public void TestStackSet()
        {
            var stackSet = new StackSet<int>(2);

            stackSet.Push(1);
            stackSet.Push(2);
            stackSet.Push(3);
            stackSet.Push(4);
            Assert.AreEqual(4, stackSet.Pop(), "stack set  has correct top value");

            stackSet.Push(4);
            stackSet.Push(5);
            Assert.AreEqual(2, stackSet.PopAt(0), "stack set  has correct top value in first stack");
            Assert.AreEqual(1, stackSet.PopAt(0), "stack set  has correct top value in first stack");
            Assert.AreEqual(5, stackSet.PopAt(1), "stack set  has correct top value in first stack");

            Assert.Throws<OverflowException>(() => stackSet.PopAt(2), "stack set has only 2 stacks");
        }

        [Test]
        public void TestStackSorting()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack = stack.Sort();
            Assert.AreEqual(1, stack.Pop(), "test stack sorting");
            Assert.AreEqual(2, stack.Pop(), "test stack sorting");
            Assert.AreEqual(3, stack.Pop(), "test stack sorting");

            stack.Push(2);
            stack.Push(1);
            stack.Push(3);
            stack = stack.Sort();

            Assert.AreEqual(1, stack.Pop(), "test stack sorting");
            Assert.AreEqual(2, stack.Pop(), "test stack sorting");
            Assert.AreEqual(3, stack.Pop(), "test stack sorting");

            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            stack = stack.Sort();

            Assert.AreEqual(1, stack.Pop(), "test stack sorting");
            Assert.AreEqual(2, stack.Pop(), "test stack sorting");
            Assert.AreEqual(3, stack.Pop(), "test stack sorting");
        }
    }
}
