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
                Assert.IsTrue(hashTable.Add(5));

                Assert.IsTrue(hashTable.Contains(5),
                    "hash table [{0}] should contains added value",
                    hashTableType.Name);
            }
        }

        [Test]
        public void HashTableClearTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType) as IHashTable;
                Assert.IsTrue(hashTable.Add(5));
                hashTable.Clear();

                Assert.IsTrue(hashTable.Count() == 0,
                    "hash table [{0}] should contains 0 elements after clearing",
                    hashTableType.Name);
            }
        }

        [Test]
        public void HashTableRemovingTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType) as IHashTable;
                Assert.IsTrue(hashTable.Add(5));
                Assert.IsTrue(hashTable.Add(15));
                Assert.IsTrue(hashTable.Add(14));

                Assert.IsTrue(hashTable.Remove(15),
                    "hash table [{0}] should remove existed element",
                    hashTableType.Name);

                Assert.IsTrue(hashTable.Contains(5),
                    "hash table [{0}] should contains not removed element",
                    hashTableType.Name);

                Assert.IsFalse(hashTable.Contains(15),
                    "hash table [{0}] should not contains removed element",
                    hashTableType.Name);
            }
        }

        [Test]
        public void HashTableRebuildTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType, 2) as IHashTable;
                Assert.IsTrue(hashTable.Add(5));
                Assert.IsTrue(hashTable.Add(15));
                Assert.IsTrue(hashTable.Add(13));
                Assert.IsTrue(hashTable.Add(17));

                Assert.IsTrue(hashTable.Contains(15),
                    "hash table [{0}] should contains element 15 after rebuilding",
                    hashTableType.Name);

                Assert.IsTrue(hashTable.Contains(5),
                    "hash table [{0}] should contains element 5 after rebuilding",
                    hashTableType.Name);

                Assert.IsTrue(hashTable.Contains(13),
                    "hash table [{0}] should contains element 14 after rebuilding",
                    hashTableType.Name);
            }
        }

        [Test]
        public void HashTableEnumeratorTest()
        {
            foreach (Type hashTableType in this.hashTableTypes)
            {
                IHashTable hashTable = Activator.CreateInstance(hashTableType, 2) as IHashTable;

                var items = new int[] { 5, 15, 13 };
                foreach (var item in items)
                {
                    hashTable.Add(item);
                }

                hashTable.Add(31);
                hashTable.Remove(31);

                foreach (var item in hashTable)
                {
                    Assert.IsTrue(items.Contains(item),
                        "hash table [{0}] should contains element [{1}] in enumerator",
                        hashTableType.Name,
                        item);
                }
            }
        }

        [Test]
        public void QuadraticHashTableOverloadingAddingTest()
        {
            IHashTable hashTable = new QuadraticHashTable(2);
            Assert.IsTrue(hashTable.Add(3));
            Assert.IsTrue(hashTable.Add(3));
            Assert.IsFalse(hashTable.Add(3),
                "quadritic hash table should not be able to add element");

            Assert.IsTrue(hashTable.Count() == 2,
                "quadritic hash table count should be 2 after not-successfull adding");
        }

        [Test]
        public void QuadraticHashTableOverloadingContainsTest()
        {
            IHashTable hashTable = new QuadraticHashTable(2);
            Assert.IsTrue(hashTable.Add(3));
            Assert.IsTrue(hashTable.Add(3));
            Assert.IsFalse(hashTable.Add(6),
                "quadritic hash table should not be able to add element");

            Assert.IsFalse(hashTable.Contains(6),
                "quadritic hash table should not contains not added element");
        }

        [Test]
        public void QuadraticHashTableOverloadingRemoveTest()
        {
            IHashTable hashTable = new QuadraticHashTable(2);
            Assert.IsTrue(hashTable.Add(3));
            Assert.IsTrue(hashTable.Add(3));
            Assert.IsFalse(hashTable.Add(6),
                "quadritic hash table should not be able to add element");

            Assert.IsFalse(hashTable.Remove(6),
                "quadritic hash table should not be able to remove not-added element");

            Assert.IsTrue(hashTable.Remove(3),
                "quadritic hash table should be able to remove existed element");

            Assert.IsTrue(hashTable.Add(3),
                "quadritic hash table should be able to add element again");

            Assert.IsTrue(hashTable.Count() == 2,
                "quadritic hash table has 2 elements after testing");
        }
    }
}
