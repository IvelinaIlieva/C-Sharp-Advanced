using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> stack;
        public List<T> Stack { get => stack; set => stack = value; }
        public MyStack(params T[] input)
        {
            Stack = new List<T>(input);
        }

        public void Push(params T[] input)
        {
            foreach (var param in input)
            {
                stack.Insert(stack.Count, param);
            }
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T popped = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return popped;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
