using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int numberOfStudents = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfStudents; i++)
            {
                string[] student = Console.ReadLine()
                    .Split();
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }
            foreach (var item in students)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():F2})");
            }
        }
    }
}
