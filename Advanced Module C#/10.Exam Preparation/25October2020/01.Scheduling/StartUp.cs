using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Scheduling
{
    class StartUp
    {
        private static int valueOfTheTask;
        private static Stack<int> tasks = new Stack<int>();
        private static Queue<int> threads = new Queue<int>();
        private const string MESSAGE = "Thread with value {0} killed task {1}";
        static void Main(string[] args)
        {
            int[] taskArgs = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            foreach (var t in taskArgs)
            {
                tasks.Push(t);
            }
            int[] threadArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var t in threadArgs)
            {
                threads.Enqueue(t);
            }
            valueOfTheTask = int.Parse(Console.ReadLine());
            WorksOfCPU();
            Console.WriteLine(String.Format(MESSAGE, threads.Peek(), valueOfTheTask));
            Console.WriteLine(PrintThreads());
        }
        private static string PrintThreads()
        {
            StringBuilder sb = new StringBuilder();
            while(threads.Count != 0)
            {
                sb.Append($"{threads.Dequeue()} ");
            }
            return sb.ToString().TrimEnd();
        }
        private static void WorksOfCPU()
        {
            while (!IsGetsNeededTask())
            {
                if (IsThreadGreaterOrEqualToTask())
                {
                    tasks.Pop();
                }
            }
        }
        private static bool IsGetsNeededTask()
            => tasks.Peek() == valueOfTheTask;

        private static bool IsThreadGreaterOrEqualToTask()
            => tasks.Peek() <= threads.Dequeue();
            
    }
}
