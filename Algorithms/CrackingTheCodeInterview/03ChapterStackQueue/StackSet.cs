using System;
using System.Collections.Generic;

namespace Algorithms.Interview.Chapter3
{
    /// <summary>
    /// Implementation of stack set
    /// </summary>
    /// <typeparam name="T">Content type</typeparam>
    public class StackSet<T>
    {
        private List<Stack<T>> stackSet;
        private int maxStackCapacity;

        public StackSet(int maxStackCapacity)
        {
            this.maxStackCapacity = maxStackCapacity;
            this.stackSet = new List<Stack<T>>();

            this.stackSet.Add(new Stack<T>());
        }

        public void Push(T value)
        {
            var currentStack = this.GetCurrentStack();
            if (currentStack.Count >= this.maxStackCapacity)
            {
                var newStack = new Stack<T>();
                newStack.Push(value);
                this.stackSet.Add(newStack);
            }
            else
            {
                currentStack.Push(value);
            }
        }

        public T Pop()
        {
            var currentStack = this.GetCurrentStack();
            return this.PopFromStack(currentStack, this.stackSet.Count - 1);
        }

        public T PopAt(int stackIndex)
        {
            if (stackIndex >= this.stackSet.Count)
            {
                throw new OverflowException();
            }

            var stack = this.stackSet[stackIndex];
            return this.PopFromStack(stack, stackIndex);
        }

        private T PopFromStack(Stack<T> stack, int stackIndex)
        {
            var value = stack.Pop();
            if (stack.Count == 0 && this.stackSet.Count > 1)
            {
                this.stackSet.RemoveAt(stackIndex);
            }

            return value;
        }

        private Stack<T> GetCurrentStack()
        {
            return this.stackSet[this.stackSet.Count - 1];
        }
    }
}
