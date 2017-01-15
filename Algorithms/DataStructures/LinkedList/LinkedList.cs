namespace Algorithms.DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> Head { internal set; get; }

        public LinkedList()
        {
        }

        public bool IsEmpty
        {
            get
            {
                return this.Head == null;
            }
        }

        public int Length
        {
            get
            {
                var current = this.Head;
                var length = 0;
                while (current != null)
                {
                    length++;
                    current = current.Next;
                }

                return length;
            }
        }

        public LinkedList(T[] values) : this()
        {
            if (values == null || values.Length == 0)
            {
                return;
            }

            this.Head = new LinkedListNode<T>(values[0]);
            var current = this.Head;
            for (var i = 1; i < values.Length; i++)
            {
                var nextNode = new LinkedListNode<T>(values[i]);
                current.Next = nextNode;
                current = nextNode;
            }
        }

        public void AddToBegin(T value)
        {
            if (this.IsEmpty)
            {
                this.Head = new LinkedListNode<T>(value);
                return;
            }

            var newNode = new LinkedListNode<T>(value);
            newNode.Next = this.Head;
            this.Head = newNode;
        }

        public void AddToEnd(T value)
        {
            if (this.IsEmpty)
            {
                this.Head = new LinkedListNode<T>(value);
                return;
            }

            var tail = this.Head;
            while(tail.Next != null)
            {
                tail = tail.Next;
            }

            tail.Next = new LinkedListNode<T>(value);
        }

        public bool IsSameListAs(LinkedList<T> other)
        {
            if (other == null)
            {
                return false;
            }

            var thisCurrent = this.Head;
            var anotherCurrent = other.Head;

            if (!this.IsEmpty && other.IsEmpty
                || this.IsEmpty && !other.IsEmpty)
            {
                return false;
            }

            while (thisCurrent != null && anotherCurrent != null)
            {
                if (!thisCurrent.Content.Equals(anotherCurrent.Content))
                {
                    return false;
                }

                thisCurrent = thisCurrent.Next;
                anotherCurrent = anotherCurrent.Next;
            }

            return thisCurrent == null && anotherCurrent == null;
        }
    }
}
