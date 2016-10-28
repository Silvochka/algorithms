using System;

namespace Algorithms.DataStructures.LinkedList
{
    /// <summary>
    /// Singly linked list node
    /// </summary>
    /// <typeparam name="T">Type of element</typeparam>
    public class SinglyLinkedListNode<T> : IComparable<SinglyLinkedListNode<T>>
        where T : IComparable<T>
    {
        public T Content { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode()
        {
            this.Content = default(T);
            this.Next = null;
        }

        public SinglyLinkedListNode(T content)
        {
            this.Content = content;
            this.Next = null;
        }

        public int CompareTo(SinglyLinkedListNode<T> other)
        {
            if (other == null)
            {
                return -1;
            }

            return this.Content.CompareTo(other.Content);
        }
    }
}
