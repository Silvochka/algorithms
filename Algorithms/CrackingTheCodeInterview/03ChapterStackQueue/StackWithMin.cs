using System.Collections.Generic;

namespace Algorithms.Interview.Chapter3
{
    public class StackWithMin : Stack<int>
    {
        private Stack<int> stackOfMins;

        public StackWithMin() : base()
        {
            this.stackOfMins = new Stack<int>();
        }

        public int Min
        {
            get
            {
                return this.stackOfMins.Count == 0
                ? int.MaxValue
                : stackOfMins.Peek();
            }
        }

        public new void Push(int value)
        {
            if (value <= this.Min)
            {
                this.stackOfMins.Push(value);
            }

            base.Push(value);
        }

        public new int Pop()
        {
            var value = base.Pop();
            if (value == this.Min)
            {
                this.stackOfMins.Pop();
            }

            return value;
        }
    }
}
