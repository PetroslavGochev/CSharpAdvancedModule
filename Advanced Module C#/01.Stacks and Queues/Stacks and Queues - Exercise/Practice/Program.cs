using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> listOfCommands = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string typeOfCommand = command[0];
                if(typeOfCommand == "1")
                {
                    sb.Append(command[1]);
                    listOfCommands.Push(command[1]);
                }
                else if(typeOfCommand == "2")
                {
                    for (int j = 0; j < int.Parse(command[1]); j++)
                    {

                    }
                }
                else if (typeOfCommand == "3")
                {

                }
                else if (typeOfCommand == "4")
                {

                }

            }
        }
    }
}
