using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Linq;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static object ICollect { get; private set; }

        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int number = int.Parse(Console.ReadLine());
            Collect addCollection = new AddCollection();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyList list = new MyList();
            ForEachData(data, addCollection);
            ForEachData(data, addRemove);
            ForEachData(data, list);
            Remove(data,number,addRemove);
            Remove(data,number,list);
        }
        private static void ForEachData(string[] data,Collect collection)
        {
            foreach (var text in data)
            {
                Console.Write($"{collection.Add(text)} ");
            }
            Console.WriteLine();
        }
        private static void Remove(string[] data,int number,AddRemoveCollection collection)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.Write($"{collection.Remove()} ");
            }
            Console.WriteLine();
        }
    }
}
