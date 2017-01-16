using System.Collections.Generic;

namespace Algorithms.Interview.Chapter3
{
    /// <summary>
    /// Implementation of queue based on 2 stacks
    /// </summary>
    /// <typeparam name="T">Content type</typeparam>
    public class QueueBasedOnStacks<T>
    {
        private Stack<T> inputStack;
        private Stack<T> outputStack;

        public QueueBasedOnStacks()
        {
            this.inputStack = new Stack<T>();
            this.outputStack = new Stack<T>();
        }

        public void Enqueue(T value)
        {
            this.inputStack.Push(value);
        }

        public T Dequeue()
        {
            if (this.outputStack.Count == 0)
            {
                this.MoveInputToOutput();
            }

            return this.outputStack.Pop();
        }

        private void MoveInputToOutput()
        {
            while (this.inputStack.Count > 0)
            {
                this.outputStack.Push(this.inputStack.Pop());
            }
        }
    }
}
