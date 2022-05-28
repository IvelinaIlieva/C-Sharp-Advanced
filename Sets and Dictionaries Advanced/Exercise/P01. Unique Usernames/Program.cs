using System;
using System.Collections.Generic;

namespace P01._Unique_Usernames
{
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 1; i <= count; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
