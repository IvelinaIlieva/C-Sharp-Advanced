namespace P01.FlowerWreaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            const int WREATH_FLOWERS = 15;
            const int WREATH_MIN_COUNT = 5;

            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wreathCount = 0;
            int currentSum = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentLilies = lilies.Pop();
                int currentRoses = roses.Peek();

                if (currentLilies + currentRoses == WREATH_FLOWERS)
                {
                    roses.Dequeue();
                    wreathCount++;
                }
                else if (currentLilies + currentRoses > WREATH_FLOWERS)
                {
                    lilies.Push(currentLilies - 2);
                }
                else
                {
                    currentSum += currentRoses + currentLilies;
                    roses.Dequeue();
                }
            }

            wreathCount += currentSum / WREATH_FLOWERS;

            Console.WriteLine(wreathCount >= WREATH_MIN_COUNT
                ? $"You made it, you are going to the competition with {wreathCount} wreaths!"
                : $"You didn't make it, you need {WREATH_MIN_COUNT - wreathCount} wreaths more!");
        }
    }
}
