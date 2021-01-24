using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {          
            int numberOfCommands = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stackText = new Stack<string>();
            stackText.Push(text.ToString());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                int command = int.Parse(input[0]);
                if (command == 1)
                {
                    text.Append(input[1]);
                    stackText.Push(text.ToString());
                }
                else if (command == 2)
                {
                    int length = int.Parse(input[1]);
                    text.Remove(text.Length - length, length);
                    stackText.Push(text.ToString());
                }
                else if (command == 3)
                {
                    int index = int.Parse(input[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (command == 4)
                {
                    stackText.Pop();
                    text = new StringBuilder();
                    text.Append(stackText.Peek());
                }
            }
        }
    }
}



