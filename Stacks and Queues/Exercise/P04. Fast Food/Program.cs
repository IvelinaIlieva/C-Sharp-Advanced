using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Fast_Food
{
    internal class Program
    {
        static void Main()
        {
            int countOfFood = int.Parse(Console.ReadLine());
            int[] inputOfOrders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(inputOfOrders.Max());

            Queue<int> orders = new Queue<int>(inputOfOrders);

            for (int i = 0; i < inputOfOrders.Length; i++)
            {
                int currOrder = orders.Peek();

                if (currOrder <= countOfFood)
                {
                    orders.Dequeue();
                    countOfFood -= currOrder;
                }
            }

            Console.WriteLine(orders.Count == 0 
                ? "Orders complete" 
                : $"Orders left: {string.Join(" ", orders)}");
        }
    }
}
