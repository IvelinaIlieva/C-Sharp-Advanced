using System;
using System.Collections.Generic;
using System.Linq;

namespace P10._ForceBook
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> forceDictionary = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string forceSide = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries)[0];
                    string forceUser = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (!forceDictionary.ContainsKey(forceSide))
                    {
                        forceDictionary[forceSide] = new HashSet<string>();
                    }

                    if (forceDictionary.Any(f => f.Value.Contains(forceUser)))
                    {
                        continue;
                    }

                    forceDictionary[forceSide].Add(forceUser);
                }
                else if (input.Contains(" -> "))
                {
                    string forceSide = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[1];
                    string forceUser = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[0];

                    bool alreadyThere = false;

                    if (forceDictionary.Any(f => f.Value.Contains(forceUser)))
                    {
                        foreach (var (side, user) in forceDictionary)
                        {
                            if (user.Contains(forceUser))
                            {
                                if (side == forceSide)
                                {
                                    alreadyThere = true;
                                    break;
                                }

                                forceDictionary[side].Remove(forceUser);
                            }
                        }
                    }
                    
                    if (!forceDictionary.ContainsKey(forceSide))
                    {
                        forceDictionary[forceSide] = new HashSet<string>();
                    }

                    forceDictionary[forceSide].Add(forceUser);

                    if (!alreadyThere)
                    {
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
                else
                {
                    continue;
                }
            }

            foreach (var (side, userHashSet) in forceDictionary
                         .OrderByDescending(x => x.Value.Count)
                         .ThenBy(x => x.Key))
            {
                if (userHashSet.Count == 0)
                {
                    break;
                }
                Console.WriteLine($"Side: {side}, Members: {userHashSet.Count}");

                foreach (var user in userHashSet.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
