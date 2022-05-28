using System;
using System.Collections.Generic;
using System.Linq;

namespace P09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = cmd.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = cmdArgs[0];
                string langOrBan = cmdArgs[1];

                if (langOrBan != "banned")
                {
                    int points = int.Parse(cmdArgs[2]);

                    if (!results.ContainsKey(username))
                    {
                        results[username] = 0;
                    }

                    if (!submissions.ContainsKey(langOrBan))
                    {
                        submissions[langOrBan] = 0;
                    }

                    submissions[langOrBan]++;

                    if (results[username] < points)
                    {
                        results[username] = points;
                    }
                }
                else if (langOrBan == "banned")
                {
                    results.Remove(username);
                }
            }

            Console.WriteLine("Results:");
            foreach (var (username, points) in results
                         .OrderByDescending(r => r.Value)
                         .ThenBy(r => r.Key))
            {
                Console.WriteLine($"{username} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var (language, count) in submissions
                         .OrderByDescending(s => s.Value)
                         .ThenBy(s => s.Key))
            {
                Console.WriteLine($"{language} - {count}");
            }
        }
    }
}
