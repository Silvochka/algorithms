using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.HashTable
{
    public class HashTableWithLinkedList: IEnumerable<int>
    {
        private int Size { get; set; }
        private int Count { get; set; }
        private LinkedList<int>[] Storage { get; set; }

        public HashTableWithLinkedList()
            : this(16)
        {
        }

        public HashTableWithLinkedList(int size)
        {
            this.Size = size;
            this.Storage = new LinkedList<int>[this.Size];
            this.Count = 0;
        }

        public void Add(int value)
        {
            if (this.Count >= this.Size)
            {
                this.Rebuild();
            }

            var index = this.GetHash(value);
            if (this.Storage[index] == null)
            {
                this.Storage[index] = new LinkedList<int>();
            }

            this.Storage[index].AddLast(value);
            this.Count++;
        }


        public bool Contains(int value)
        {
            var index = this.GetHash(value);
            if (this.Storage[index] == null)
            {
                return false;
            }

            return this.Storage[index].Contains(value);
        }

        public bool Remove(int value)
        {
            var index = this.GetHash(value);
            if (this.Storage[index] == null)
            {
                return false;
            }

            this.Count--;
            return this.Storage[index].Remove(value);
        }

        public void Clear()
        {
            foreach (var list in this.Storage)
            {
                if (list != null && list.Count > 0)
                {
                    list.Clear();
                }
            }
        }

        private void Rebuild()
        {
            this.Size = this.Size * 2;
            var newStorageItems = new List<int>();
            foreach(var item in this)
            {
                newStorageItems.Add(item);
            }

            this.Storage = new LinkedList<int>[this.Size];
            foreach (var item in newStorageItems)
            {
                this.Add(item);
            }
        }

        private int GetHash(int value)
        {
            return value % this.Size;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var list in this.Storage)
            {
                if (list != null)
                {
                   foreach(var item in list)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
