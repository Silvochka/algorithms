namespace Algorithms.DataStructures.LinkedList
{
    public class LinkedListNode<T>
    {
        public T Content { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode() { }

        public LinkedListNode(T value) : this()
        {
            this.Content = value;
        }
    }
}
