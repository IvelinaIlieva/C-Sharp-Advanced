using System;
using System.Collections.Generic;

namespace P04._Product_Shop
{
    internal class Program
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string,double>> shopSheet = new SortedDictionary<string, Dictionary<string,double>>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Revision")
            {
                string[]shopInfo = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = shopInfo[0];
                string product = shopInfo[1];
                double price = double.Parse(shopInfo[2]);

                if (!shopSheet.ContainsKey(shop))
                {
                    shopSheet[shop] = new Dictionary<string, double>();
                }

                shopSheet[shop].Add(product, price);
            }

            foreach (string shop in shopSheet.Keys)
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in shopSheet[shop])
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
