using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] path;

        public int[] Path { get => path; set => path = value; }

        public Lake(int[] path)
        {
            this.Path = path;
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < path.Length; i += 2)
            {
                yield return path[i];
            }

            for (int j = path.Length - 1; j >= 0; j--)
            {
                if (j % 2 != 0)
                {
                    yield return path[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
