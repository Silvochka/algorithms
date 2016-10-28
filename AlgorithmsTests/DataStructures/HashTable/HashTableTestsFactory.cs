using System;
using System.Linq;
using Algorithms.DataStructures.HashTable;
using NUnit.Framework;

namespace AlgorithmsTests.SortAlgorithms.DataStructures.LinkedList
{
    [TestFixture]
    public class HashTableTestsFactory
    {
        Type[] hashTableTypes;
        public HashTableTestsFactory()
        {
            Type sorterType = typeof(IHashTable);

            this.hashTableTypes = AppDomain
               .CurrentDomain
               .GetAssemblies()
               .SelectMany(assembly => assembly.GetTypes())
               .Where(type => sorterType.IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
               .ToArray();
        }

        [Test]
        public void HashTableCreationTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType) as IHashTable;

                Assert.IsNotNull(hashTable);
            }
        }

        [Test]
        public void HashTableAddingTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType) as IHashTable;
                hashTable.Add(5);

                Assert.IsTrue(hashTable.Contains(5));
            }
        }

        [Test]
        public void HashTableClearTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType) as IHashTable;
                hashTable.Add(5);
                hashTable.Clear();

                Assert.IsTrue(hashTable.Count() == 0);
            }
        }

        [Test]
        public void HashTableRemovingTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType) as IHashTable;
                hashTable.Add(5);
                hashTable.Add(15);
                hashTable.Add(14);
                Assert.IsTrue(hashTable.Remove(15));
                Assert.IsTrue(hashTable.Contains(5));
                Assert.IsFalse(hashTable.Contains(15));
            }
        }

        [Test]
        public void HashTableRebuildTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType, 2) as IHashTable;
                hashTable.Add(5);
                hashTable.Add(15);
                hashTable.Add(14);
                hashTable.Add(17);
                Assert.IsTrue(hashTable.Contains(15));
                Assert.IsTrue(hashTable.Contains(5));
                Assert.IsTrue(hashTable.Contains(14));
            }
        }

        [Test]
        public void HashTableEnumeratorTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType, 2) as IHashTable;

                var items = new int[] { 5, 15, 14 };
                foreach (var item in items)
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
}
