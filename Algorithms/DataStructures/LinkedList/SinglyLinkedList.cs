using System;

namespace Algorithms.DataStructures.LinkedList
{
    /// <summary>
    /// Singly linked list
    /// </summary>
    /// <typeparam name="T">Type of item's contents</typeparam>
    public class SinglyLinkedList<T> where T : IComparable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }

        public SinglyLinkedList()
        {
            this.Head = null;
        }

        public SinglyLinkedList(T content)
        {
            this.Head = new SinglyLinkedListNode<T>(content);
        }
    }
}
