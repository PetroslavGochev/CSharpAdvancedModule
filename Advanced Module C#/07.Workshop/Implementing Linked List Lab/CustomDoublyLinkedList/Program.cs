using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list.AddFirst(i);
            }
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());
            Console.WriteLine(list.RemoveLast());
            Console.WriteLine(list.RemoveLast());
            list.ForEach(n => Console.WriteLine(n));
            Console.WriteLine(string.Join(" ", list.ToArray()));

        }
    }
}
