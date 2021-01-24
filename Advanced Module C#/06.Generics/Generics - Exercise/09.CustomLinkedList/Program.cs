using System;

namespace _09.CustomLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList<string> list = new CustomList<string>();
            list.Add("Pesho");
            list.Add("Ivan");
            list.Add("Mitko");
            list.Add("Gosho");
            list.Insert(4, "Rosko");
            Console.WriteLine(list.Contains("Ivan"));
            Console.WriteLine(list);
        }
    }
}
