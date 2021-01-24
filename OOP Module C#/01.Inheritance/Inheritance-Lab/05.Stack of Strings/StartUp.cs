using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("mitko");
            stack.Push("stef");
            stack.Push("ivan");
            Console.WriteLine(stack.IsEmpty());

            Console.WriteLine(string.Join(" ", stack.AddRange()));
        }
    }
}
