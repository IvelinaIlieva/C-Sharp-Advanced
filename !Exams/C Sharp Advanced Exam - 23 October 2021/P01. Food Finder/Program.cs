using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Food_Finder
{
    internal class Program
    {
        static void Main()
        {
            HashSet<char> inputVowels = Console.ReadLine().Split(" ").Select(char.Parse).ToHashSet();
            HashSet<char> inputConsonants = Console.ReadLine().Split(" ").Select(char.Parse).ToHashSet();

            Dictionary<string, int[]> words = new Dictionary<string, int[]>()
            {
                { "pear", new int[2]{4,0}},
                { "flour", new int[2]{5,0}},
                { "pork", new int[2]{4,0}},
                { "olive", new int[2]{5,0}},
            };

            Queue<char> vowels = new Queue<char>(inputVowels);
            Stack<char> consonants = new Stack<char>(inputConsonants);

            int count = 0;
            int vowelCounter = 0;

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();
                
                foreach (var word in words)
                {
                    if (word.Key.Any(w => w == currConsonant))
                    {
                        word.Value[0]--;
                    }

                    if (word.Key.Any(w => w == currVowel) && vowelCounter <= vowels.Count)
                    {
                        word.Value[0]--;
                    }

                    if (word.Value[0] == 0)
                    {
                        word.Value[1]++;
                        word.Value[0] = word.Key.Length;
                        count++;
                    }
                }
                vowelCounter++;
                vowels.Enqueue(currVowel);
            }

            Console.WriteLine($"Words found: {count}");

            foreach (var word in words.Where(w => w.Value[1] > 0))
            {
                Console.WriteLine(word.Key);
            }
        }
    }
}
