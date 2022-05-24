using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Average_Student_Grades
{
    internal class Program
    {
        static void Main()
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 1; i <= countOfStudents; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }

                students[name].Add(grade);
            }

            foreach (var (name, grades) in students)
            {
                Console.WriteLine($"{name} -> {string.Join(" ", grades.Select(g=>g.ToString("f2")))} (avg: {grades.Average() :f2})");
            }
        }
    }
}
