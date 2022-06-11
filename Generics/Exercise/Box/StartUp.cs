using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Box
{
    public class StartUp
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            var list = new List<double>();

            for (int i = 0; i < count; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);

            var itemToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(Box<double>.CountOfGreaterElements(list, itemToCompare));
        }
    }
}
