using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            Queue<string> listOfSong = new Queue<string>(input);
            while(listOfSong.Count > 0)
            {
                string command = Console.ReadLine();
                if(command.Contains("Play"))
                {
                    listOfSong.Dequeue();
                }
                else if(command.Contains("Add"))
                {
                    string song = command.Substring(4, command.Length - 4);
                    if (!listOfSong.Contains(song))
                    {
                        listOfSong.Enqueue(song);
                        continue;
                    }
                    Console.WriteLine($"{song} is already contained!");
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", listOfSong));
                }
            }
            Console.WriteLine("No more songs!");

        }
    }
}
