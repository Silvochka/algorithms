using System;
using System.Collections.Generic;

namespace Algorithms.Interview.Chapter2
{
    public static class LinkedListExtension
    {
        /// <summary>
        /// Remove duplicates from list
        /// </summary>
        /// <typeparam name="T">Type of list's content</typeparam>
        /// <param name="list">Linked list</param>
        public static void RemoveDuplicates<T>(this DataStructures.LinkedList.LinkedList<T> list)
        {
            if (list == null || list.IsEmpty)
            {
                return;
            }

            var valuesHash = new HashSet<T>();
            var previous = list.Head;
            var currentListItem = list.Head;

            while (currentListItem != null)
            {
                if (valuesHash.Contains(currentListItem.Content))
                {
                    previous.Next = currentListItem.Next;
                    currentListItem = currentListItem.Next;
                }
                else
                {
                    valuesHash.Add(currentListItem.Content);
                    previous = currentListItem;
                    currentListItem = currentListItem.Next;
                }
            }
        }

        /// <summary>
        /// Get k-th element from end of linked list (based 0)
        /// </summary>
        /// <typeparam name="T">Type of list's content</typeparam>
        /// <param name="list">Linked list</param>
        /// <returns>K-th element from end or null if length of list is less</returns>
        public static DataStructures.LinkedList.LinkedListNode<T> GetKFromEnd<T>(this DataStructures.LinkedList.LinkedList<T> list, int k)
        {
            if (list == null || list.IsEmpty)
            {
                return null;
            }

            var secondRunner = list.Head;
            var currentPosition = 0;
            while (secondRunner != null && secondRunner.Next != null && currentPosition < k)
            {
                secondRunner = secondRunner.Next;
                currentPosition++;
            }

            if (currentPosition < k)
            {
                return null;
            }

            var firstRunner = list.Head;
            while (secondRunner.Next != null)
            {
                secondRunner = secondRunner.Next;
                firstRunner = firstRunner.Next;
            }

            return firstRunner;
        }

        /// <summary>
        /// Removed given element from list
        /// </summary>
        /// <typeparam name="T">Type of list's content</typeparam>
        /// <param name="node">Linked list node</param>
        public static void RemoveFromMiddle<T>(this DataStructures.LinkedList.LinkedListNode<T> node)
        {
            if (node == null || node.Next == null)
            {
                return;
            }

            node.Content = node.Next.Content;
            node.Next = node.Next.Next;
        }

        /// <summary>
        /// Sort linked list: all items less X should in left part, and greater or equals - in right part
        /// </summary>
        /// <typeparam name="T">Type of list's content</typeparam>
        /// <param name="list">Linked list</param>
        /// <param name="content">Content to be X</param>
        public static void SortAround<T>(this DataStructures.LinkedList.LinkedList<T> list, T content) where T : IComparable<T>
        {
            if (list == null || list.IsEmpty)
            {
                return;
            }

            DataStructures.LinkedList.LinkedListNode<T> listBeforeHead = null;
            DataStructures.LinkedList.LinkedListNode<T> listAfterHead = null;
            DataStructures.LinkedList.LinkedListNode<T> currentBefore = null;
            DataStructures.LinkedList.LinkedListNode<T> currentAfter = null;

            var current = list.Head;

            while (current != null)
            {
                if (content.CompareTo(current.Content) > 0)
                {
                    if (listBeforeHead == null)
                    {
                        listBeforeHead = currentBefore = current;
                    }
                    else
                    {
                        currentBefore.Next = current;
                        currentBefore = current;
                    }
                }
                else
                {
                    if (listAfterHead == null)
                    {
                        listAfterHead = currentAfter = current;
                    }
                    else
                    {
                        currentAfter.Next = current;
                        currentAfter = current;
                    }
                }

                current = current.Next;
            }

            if (listBeforeHead != null)
            {
                list.Head = listBeforeHead;
                currentBefore.Next = listAfterHead;
            }
            else if (listAfterHead != null)
            {
                list.Head = listAfterHead;

            }

            if (currentAfter != null)
            {
                currentAfter.Next = null;
            }
        }
    }
}
