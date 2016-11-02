using System.Collections.Generic;

namespace Algorithms.DataStructures.HashTable
{
    /// <summary>
    /// Average: O(1)
    /// Worst:   O(n)
    /// </summary>
    public interface IHashTable : IEnumerable<int>
    {
        bool Add(int value);

        bool Contains(int value);

        bool Remove(int value);

        void Clear();
    }
}
