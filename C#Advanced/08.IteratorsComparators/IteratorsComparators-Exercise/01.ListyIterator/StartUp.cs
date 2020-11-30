using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            ListyIterator<string> list = new ListyIterator<string>(input.Skip(1).ToArray());
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                   Console.WriteLine(list.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HashNext());
                }
            }
        }
    }
}
