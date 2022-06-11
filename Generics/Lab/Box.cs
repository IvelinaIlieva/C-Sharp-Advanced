using System.Collections.Generic;

namespace BoxOfT
{
    internal class Box<T>
    {
        public int Count => this.BoxStack.Count;
        public Stack<T> BoxStack { get; set; }

        public Box()
        {
            this.BoxStack = new Stack<T>();
        }

        public void Add(T element)
        {
            this.BoxStack.Push(element);
        }

        public T Remove()
        {
           return this.BoxStack.Pop();
        }

    }
}
