using System.Linq;
using Algorithms.DataStructures.HashTable;
using NUnit.Framework;

namespace AlgorithmsTests.SortAlgorithms.DataStructures.LinkedList
{
    public class HashTableWithLinkedListTests
    {
        [Test]
        public void HashTableWithLinkedListCreationTest()
        {
            var hashTable = new HashTableWithLinkedList();

            Assert.IsNotNull(hashTable);
        }

        [Test]
        public void HashTableWithLinkedListAddingTest()
        {
            var hashTable = new HashTableWithLinkedList();
            hashTable.Add(5);

            Assert.IsTrue(hashTable.Contains(5));
        }

        [Test]
        public void HashTableWithLinkedListRemovingTest()
        {
            var hashTable = new HashTableWithLinkedList();
            hashTable.Add(5);
            hashTable.Add(15);
            hashTable.Add(14);
            Assert.IsTrue(hashTable.Remove(15));
            Assert.IsTrue(hashTable.Contains(5));
            Assert.IsFalse(hashTable.Contains(15));
        }

        [Test]
        public void HashTableWithLinkedListRebuildTest()
        {
            var hashTable = new HashTableWithLinkedList(2);
            hashTable.Add(5);
            hashTable.Add(15);
            hashTable.Add(14);
            Assert.IsTrue(hashTable.Contains(15));
            Assert.IsTrue(hashTable.Contains(5));
            Assert.IsTrue(hashTable.Contains(14));
        }

        [Test]
        public void HashTableWithLinkedListEnumeratorTest()
        {
            var hashTable = new HashTableWithLinkedList(2);

            var items = new int[] { 5, 15, 14 };
            foreach(var item in items)
            {
                hashTable.Add(item);
            }

            hashTable.Add(31);
            hashTable.Remove(31);

            foreach (var item in hashTable)
            {
                Assert.IsTrue(items.Contains(item));
            }
        }
    }
}
