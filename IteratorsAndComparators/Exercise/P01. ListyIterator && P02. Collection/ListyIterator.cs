using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>: IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public List<T> List { get => list; set => list = value; }

        public int Index = 0;

        public ListyIterator(params T[] arr)
        {
            this.List = new List<T>(arr);
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext() => index < list.Count - 1;
        
        public void Print()=> Console.WriteLine(list.Count == 0 ? "Invalid Operation!" : list[index].ToString());
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
