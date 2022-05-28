using System;
using System.Collections.Generic;
using System.Linq;

namespace P08._Ranking
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, string> contestInfo = new Dictionary<string, string>();

            string contestInput;
            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                string[] contestArgs = contestInput.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = contestArgs[0];
                string contestPass = contestArgs[1];

                contestInfo.Add(contest, contestPass);
            }

            SortedDictionary<string, Dictionary<string, int>> studentDictionary = new SortedDictionary<string, Dictionary<string, int>>();

            string studentInput;
            while ((studentInput = Console.ReadLine()) != "end of submissions")
            {
                string[] studentArgs = studentInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = studentArgs[0];
                string contestPass = studentArgs[1];

                if (!contestInfo.ContainsKey(contest) || contestInfo[contest] != contestPass)
                {
                    continue;
                }

                string username = studentArgs[2];
                int points = int.Parse(studentArgs[3]);

                if (!studentDictionary.ContainsKey(username))
                {
                    studentDictionary.Add(username, new Dictionary<string, int>());
                }
                
                if (studentDictionary[username].ContainsKey(contest))
                {
                    if (studentDictionary[username][contest] < points)
                    {
                        studentDictionary[username][contest] = points;
                    }
                }
                else
                {
                    studentDictionary[username].Add(contest, points);
                }
            }

            int maxPoints = int.MinValue;
            string bestUser = null;
            
            foreach (var (username, contest) in studentDictionary)
            {
                int currPoints = contest.Values.Sum();

                if (maxPoints < currPoints)
                {
                    maxPoints = currPoints;
                    bestUser = username;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {maxPoints} points.");
            
            Console.WriteLine($"Ranking:");
            foreach (var (username, contestData) in studentDictionary)
            {
                Console.WriteLine(username);

                foreach (var (contest, points) in studentDictionary[username].OrderByDescending(p=>p.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
