using System;
using System.Collections.Generic;
using System.Linq;

namespace P09._Predicate_Party_
{
    internal class Program
    {
        static void Main()
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                string command = cmd.Split()[0];
                string criteria = cmd.Split()[1];
                string arg = cmd.Split()[2];

                Predicate<string> startWith = str => str.StartsWith(arg);
                Predicate<string> endsWith = str => str.EndsWith(arg);
                Predicate<string> isInLength = str => str.Length == int.Parse(arg);

                if (command == "Remove")
                {
                    if (criteria == "StartsWith")
                    {
                        guests.RemoveAll(startWith);
                    }
                    else if (criteria == "EndsWith")
                    {
                        guests.RemoveAll(endsWith);
                    }
                    else if (criteria == "Length")
                    {
                        guests.RemoveAll(isInLength);
                    }
                }
                else if (command == "Double")
                {
                    if (criteria == "StartsWith")
                    {
                        for(int i = 0; i < guests.Count; i++)
                        {
                            if (startWith(guests[i]))
                            {
                                guests.Insert(i + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else if (criteria == "EndsWith")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (endsWith(guests[i]))
                            {
                                guests.Insert(i + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else if (criteria == "Length")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (isInLength(guests[i]))
                            {
                                guests.Insert(i + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
        }
    }
}
