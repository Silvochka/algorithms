using System;
using System.Collections.Generic;

namespace Algorithms.Interview.Chapter3
{
    public static class StackExt
    {
        /// <summary>
        /// Sorting of stack with usage of just 1 stack. Minimal element of result should be on top
        /// </summary>
        /// <typeparam name="T">Content type</typeparam>
        /// <param name="stack">Stack to sort</param>
        /// <returns>Sorted stack</returns>
        public static Stack<T> Sort<T>(this Stack<T> stack) where T : IComparable
        {
            var result = new Stack<T>();

            while (stack.Count > 0)
            {
                var currentValue = stack.Pop();
                if (result.Count == 0 || result.Peek().CompareTo(currentValue) >= 0)
                {
                    result.Push(currentValue);
                }
                else
                {
                    var countOfMoved = 0;
                    while (result.Count > 0 && result.Peek().CompareTo(currentValue) < 0)
                    {
                        stack.Push(result.Pop());
                        countOfMoved++;
                    }

                    result.Push(currentValue);

                    for (var i = 0; i < countOfMoved; i++)
                    {
                        result.Push(stack.Pop());
                    }
                }
            }

            return result;
        }
    }
}
