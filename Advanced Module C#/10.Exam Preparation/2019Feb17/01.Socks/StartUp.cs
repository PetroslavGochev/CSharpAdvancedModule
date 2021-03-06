using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class StartUp
    {
        private static List<int> pairs = new List<int>();
        private static Stack<int> leftSock = new Stack<int>();
        private static Queue<int> rightSock = new Queue<int>();
        static void Main(string[] args)
        {
            var leftArgs = ReadSocskArgsFromConsole();
            foreach (var ls in leftArgs)
            {
                leftSock.Push(ls);
            }
            var rightArgs = ReadSocskArgsFromConsole();
            foreach (var rs in rightArgs)
            {
                rightSock.Enqueue(rs);
            }
            Combination();
            Console.WriteLine(pairs.Max());
            Console.WriteLine(String.Join(" ", pairs));
        }
        private static void Combination()
        {
            while (IsTrue())
            {
                int areEqual = leftSock.Peek().CompareTo(rightSock.Peek());
                if (areEqual == 1)
                {
                    pairs.Add(leftSock.Pop() + rightSock.Dequeue());
                }
                else if (areEqual == 0)
                {
                    leftSock.Push(leftSock.Pop() + 1);
                    rightSock.Dequeue();
                }
                else
                {
                    leftSock.Pop();
                }
            }
        }
        private static bool IsTrue()
            => leftSock.Count != 0 && rightSock.Count != 0;
        private static int[] ReadSocskArgsFromConsole()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
