using System;
using System.Linq;

namespace Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            StackStructure<int> stack = new StackStructure<int>();
            while ((input = Console.ReadLine()) != "END")
            {
                var command = input
                    .Split()
                    .Take(1)
                    .ToArray();
                var data = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(int.Parse)
                    .ToArray();
                if (command[0] == "Push")
                {
                    stack.Push(data);
                }
                else if (command[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {

                        Console.WriteLine(e.Message);
                    }                    
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
