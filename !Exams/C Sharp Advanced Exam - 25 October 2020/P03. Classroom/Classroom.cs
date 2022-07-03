using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;
        private int count;

        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Count => Students.Count;

        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (Students.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                Student student = Students.First(s => s.FirstName == firstName && s.LastName == lastName);
                Students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            if (Students.All(s => s.Subject != subject))
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in Students.Where(s => s.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName) => Students.First(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
