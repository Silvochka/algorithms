using System.Collections;
using System.Collections.Generic;
using Algorithms.Helpers;

namespace Algorithms.DataStructures.HashTable
{
    /// <summary>
    /// Implementation of hash tabl with doule hashing
    /// </summary>
    public class DoubleHashTable : IEnumerable<int>, IHashTable
    {
        private int HashPrime { get; set; }
        private int Size { get; set; }
        private int Count { get; set; }
        private HashTableItem<int>[] Storage { get; set; }

        public DoubleHashTable()
            : this(10)
        {
        }

        public DoubleHashTable(int size)
        {
            this.Size = PrimeList.GetNextPrime(size);
            this.HashPrime = PrimeList.GetNextPrime(this.Size);
            this.Storage = new HashTableItem<int>[this.Size];
            this.Count = 0;
        }

        public bool Add(int value)
        {
            if (this.Count >= this.Size)
            {
                this.Rebuild();
            }

            var baseIndex = this.GetHash(value);
            var index = baseIndex;
            var step = 0;
            while (this.Storage[index] != null &&
                (!this.Storage[index].IsDeleted || !this.Storage[index].IsEmpty))
            {
                index = this.GetNextProbingIndex(baseIndex, step, value);
                if (step < this.Size)
                {
                    step++;
                }
                else
                {
                    return false;
                }
            }

            if (this.Storage[index] == null)
            {
                this.Storage[index] = new HashTableItem<int>();
            }

            this.Storage[index].Content = value;
            this.Storage[index].IsDeleted = false;
            this.Storage[index].IsEmpty = false;
            this.Count++;
            return true;
        }

        public bool Contains(int value)
        {
            var baseIndex = this.GetHash(value);
            var index = baseIndex;
            var step = 0;
            while (true)
            {
                if (this.Storage[index] == null
                    || this.Storage[index].IsDeleted == true
                    || this.Storage[index].IsEmpty == true)
                {
                    return false;
                }

                if (this.Storage[index].Content == value)
                {
                    return true;
                }

                if (step < this.Size)
                {
                    step++;
                }
                else
                {
                    return false;
                }

                index = this.GetNextProbingIndex(baseIndex, step, value);
            }
        }

        public bool Remove(int value)
        {
            var baseIndex = this.GetHash(value);
            var index = baseIndex;
            var step = 0;
            while (true)
            {
                if (this.Storage[index] == null
                    || this.Storage[index].IsEmpty == true)
                {
                    return false;
                }

                if (this.Storage[index].Content == value)
                {
                    this.Storage[index].IsDeleted = true;
                    this.Storage[index].IsEmpty = true;
                    this.Count--;
                    return true;
                }

                if (step < this.Size)
                {
                    step++;
                }
                else
                {
                    return false;
                }

                index = this.GetNextProbingIndex(baseIndex, step, value);
            }
        }

        public void Clear()
        {
            foreach (var item in this.Storage)
            {
                if (item != null)
                {
                    item.IsEmpty = true;
                    item.IsDeleted = false;
                }
            }
        }

        private void Rebuild()
        {
            this.Size = PrimeList.GetNextPrime(this.Size);
            this.HashPrime = PrimeList.GetNextPrime(this.Size);
            var newStorageItems = new List<int>();
            foreach (var item in this)
            {
                newStorageItems.Add(item);
            }

            this.Count = 0;
            this.Storage = new HashTableItem<int>[this.Size];
            foreach (var item in newStorageItems)
            {
                this.Add(item);
            }
        }

        private int GetHash(int value)
        {
            return value % this.Size;
        }

        private int GetNextProbingIndex(int index, int step, int value)
        {
            var hash = this.HashPrime - value % this.HashPrime;
            return (index + step * hash) % this.Size;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in this.Storage)
            {
                if (item != null && !item.IsDeleted && !item.IsEmpty)
                {
                    yield return item.Content;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
