using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> number = new Stack<int>();
            int numberOfQuery = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfQuery; i++)
            {
                int[] query = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                bool flag = number.Count > 0 ? true : false;
                if(query[0] == 1)
                {
                    number.Push(query[1]);
                }
                else if (query[0] == 2 && flag)
                {
                    number.Pop();
                }
                else if (query[0] == 3 && flag)
                {
                    int maximum = int.MinValue;
                    foreach (var item in number)
                    {
                        if(item > maximum)
                        {
                            maximum = item;
                        }
                    }
                    Console.WriteLine($"{maximum}");
                }
                else if (query[0] == 4 && flag)
                {
                    int minimum = int.MaxValue;
                    foreach (var item in number)
                    {
                        if (item < minimum)
                        {
                            minimum = item;
                        }
                    }
                    Console.WriteLine($"{minimum}");
                }
            }
            List<int> result = new List<int>();
            foreach (var item in number)
            {
                result.Add(item);
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
