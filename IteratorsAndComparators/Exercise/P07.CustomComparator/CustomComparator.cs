using System.Collections.Generic;

namespace P07.CustomComparator
{
    public class CustomComparator : IComparer<int>
    {
        private int[] array;
        public int[] Array { get; set; }

        public CustomComparator(int[] array)
        {
            Array = array;
        }

        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
}
