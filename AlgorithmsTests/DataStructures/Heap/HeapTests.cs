using NUnit.Framework;

namespace AlgorithmsTests.DataStructures.Heap
{
    public class HeapTests
    {
        [Test]
        public void TestMinHeap()
        {
            var minHeap = new Algorithms.DataStructures.Heap.Heap(true);
            Assert.AreEqual(0, minHeap.Count(), "Empty heap should contain 0 elements");
            Assert.AreEqual(0, minHeap.Peek(), "Empty heap should contain 0 at the top");
            Assert.AreEqual(0, minHeap.ExtractTop(), "Heap should contain 0 at the top");
            minHeap.Add(10);
            Assert.AreEqual(10, minHeap.Peek(), "Heap should contain 10 at the top");
            minHeap.Add(9);
            minHeap.Add(3);
            minHeap.Add(13);

            Assert.AreEqual(3, minHeap.Peek(), "Heap should contain 3 at the top");
            Assert.AreEqual(3, minHeap.ExtractTop(), "Heap should contain 3 at the top");
            Assert.AreEqual(9, minHeap.Peek(), "Heap should contain 9 at the top");
            Assert.IsTrue(minHeap.Validate(), "Heap should be valid");
        }

        [Test]
        public void TestMaxHeap()
        {
            var maxHeap = new Algorithms.DataStructures.Heap.Heap(false);
            Assert.AreEqual(0, maxHeap.Count(), "Empty heap should contain 0 elements");
            Assert.AreEqual(0, maxHeap.Peek(), "Empty heap should contain 0 at the top");
            Assert.IsTrue(maxHeap.Validate(), "Heap should be valid");
            maxHeap.Add(10);
            Assert.AreEqual(10, maxHeap.Peek(), "Heap should contain 10 at the top");
            maxHeap.Add(9);
            maxHeap.Add(3);
            maxHeap.Add(13);

            Assert.AreEqual(13, maxHeap.Peek(), "Heap should contain 13 at the top");
            Assert.AreEqual(13, maxHeap.ExtractTop(), "Heap should contain 13 at the top");
            Assert.AreEqual(10, maxHeap.Peek(), "Heap should contain 10 at the top");
            Assert.IsTrue(maxHeap.Validate(), "Heap should be valid");
        }
    }
}
