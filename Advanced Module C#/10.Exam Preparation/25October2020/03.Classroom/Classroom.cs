using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private ICollection<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if(this.Count < Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.students
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .FirstOrDefault();
            if(student != null)
            {
                this.students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            return $"Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            var subjectStudents = this.students
                .Where(x => x.Subject == subject)
                .ToList();
            if(subjectStudents.Count == 0)
            {
                return $"No students enrolled for the subject";
            }
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var s in subjectStudents)
            {
                sb.AppendLine($"{s.FirstName} {s.LastName}");
            }
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount() => this.Count;
        public Student GetStudent(string firstName, string lastName)
            => this.students
            .Where(x => x.FirstName == firstName && x.LastName == lastName)
            .FirstOrDefault();
    }
}
