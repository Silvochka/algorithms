using System;

namespace Algorithms.DataStructures.HashTable
{
    internal class HashTableItem<T> where T:IComparable<T>
    {
        public T Content { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsDeleted { get; set; }
    }
}
