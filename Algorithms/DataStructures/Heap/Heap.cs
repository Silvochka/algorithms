using System.Collections.Generic;

namespace Algorithms.DataStructures.Heap
{
    public class Heap
    {
        List<int> heap;
        private bool isMinHeap;

        public Heap(bool minHeap)
        {
            this.heap = new List<int>();
            this.isMinHeap = minHeap;
        }

        public int Count()
        {
            return this.heap.Count;
        }

        public int Peek()
        {
            if (this.heap.Count == 0)
            {
                return 0;
            }

            return this.heap[0];
        }

        public void Add(int item)
        {
            this.heap.Add(item);
            this.Up(this.heap.Count - 1);
        }

        public int ExtractTop()
        {
            if (this.heap.Count == 0)
            {
                return 0;
            }

            var min = this.heap[0];
            this.Switch(0, this.heap.Count - 1);
            this.heap.RemoveAt(this.heap.Count - 1);
            this.Down(0);

            return min;
        }

        public bool Validate()
        {
            if (this.heap.Count == 0)
            {
                return true;
            }

            for (var i = 0; i < this.heap.Count; i++)
            {
                var child1Index = 2 * i + 1;
                var child2Index = 2 * i + 2;

                if (child1Index < this.heap.Count)
                {
                    if (this.isMinHeap && this.heap[i] > this.heap[child1Index]
                       || !this.isMinHeap && this.heap[i] < this.heap[child1Index])
                    {
                        return false;
                    }
                }

                if (child2Index < this.heap.Count)
                {
                    if (this.isMinHeap && this.heap[i] > this.heap[child2Index]
                       || !this.isMinHeap && this.heap[i] < this.heap[child2Index])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Up(int index)
        {
            if (index == 0 || index >= this.heap.Count)
            {
                return;
            }

            int parent = (index - 1) / 2;
            if (this.isMinHeap && this.heap[parent] > this.heap[index]
               || !this.isMinHeap && this.heap[parent] < this.heap[index])
            {
                this.Switch(index, parent);
                this.Up(parent);
            }
        }

        private void Down(int index)
        {
            if (2 * index + 1 >= this.heap.Count)
            {
                return;
            }

            var childIndex1 = 2 * index + 1;
            var childIndex2 = 2 * index + 2;
            var minIndex = index;

            if (childIndex1 < this.heap.Count &&
               (this.isMinHeap && this.heap[childIndex1] < this.heap[minIndex]
            || !this.isMinHeap && this.heap[childIndex1] > this.heap[minIndex]))
            {
                minIndex = childIndex1;
            }

            if (childIndex2 < this.heap.Count &&
               (this.isMinHeap && this.heap[childIndex2] < this.heap[minIndex]
            || !this.isMinHeap && this.heap[childIndex2] > this.heap[minIndex]))
            {
                minIndex = childIndex2;
            }

            if (minIndex != index)
            {
                this.Switch(index, minIndex);
                this.Down(minIndex);
            }
        }

        private void Switch(int index1, int index2)
        {
            if (index1 < 0 || index1 >= this.heap.Count
               || index2 < 0 || index2 >= this.heap.Count)
            {
                return;
            }

            var temp = this.heap[index1];
            this.heap[index1] = this.heap[index2];
            this.heap[index2] = temp;
        }
    }
}
