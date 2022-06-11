using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box<T> where T : IComparable<T>
    {
        private T value;
        private List<T> list;
        public Box(T value)
        {
            this.value = value;
        }

        public Box(List<T> list)
        {
            this.list = list;
        }

        public static void Swap(List<T> list, int index1, int index2)
        {
            (list[index1], list[index2]) = (list[index2], list[index1]);
        }

        public static int CountOfGreaterElements(List<T> list, T item)
        {
            int count = 0;

            foreach (var element in list)
            {
                if (element.CompareTo(item) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
