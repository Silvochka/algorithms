using Algorithms.Interview.Chapter3;
using NUnit.Framework;

namespace AlgorithmsTests.Interview.Chapter3
{
    class QueueTests
    {
        [Test]
        public void TestQueueBasedOnStacks()
        {
            var queue = new QueueBasedOnStacks<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(1, queue.Dequeue(), "queue should dequeue correct element");
            Assert.AreEqual(2, queue.Dequeue(), "queue should dequeue correct element");
            Assert.AreEqual(3, queue.Dequeue(), "queue should dequeue correct element");

            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.AreEqual(1, queue.Dequeue(), "queue should dequeue correct element");

            queue.Enqueue(3);
            Assert.AreEqual(2, queue.Dequeue(), "queue should dequeue correct element");
            Assert.AreEqual(3, queue.Dequeue(), "queue should dequeue correct element");
        }
    }
}
