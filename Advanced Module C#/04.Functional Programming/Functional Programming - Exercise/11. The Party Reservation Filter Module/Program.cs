using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Print")
            {
                var data = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                var command = data[0];
                var arr = data.Skip(1).ToArray();
                if (command == "Add filter")
                {
                    filters.Add($"{arr[0]} {arr[1]}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{arr[0]} {arr[1]}");
                }
            }

            foreach (var filter in filters)
            {
                list = Filter(filter, list);
            }
            PrintResult(list);

        }
        static Func<string, List<string>, List<string>> Filter = (filters, names) =>
          {
              List<string> listFiltered = new List<string>();
              var filter = filters
                           .Split(" ")
                           .ToArray();
              if (filter[0] == "Starts")
              {
                  listFiltered = names.Where(name => !name.StartsWith(filter[2])).ToList();
              }
              else if (filter[0] == "Ends")
              {
                  listFiltered = names.Where(name => !name.EndsWith(filter[2])).ToList();
              }
              else if (filter[0] == "Length")
              {
                  listFiltered = names.Where(name => name.Length != int.Parse(filter[1])).ToList();
              }
              else if (filter[0] == "Contains")
              {
                  listFiltered = names.Where(name => !name.Contains(filter[1])).ToList();
              }
              return listFiltered;
          };
        static Action<List<string>> PrintResult = names =>
        {
            Console.WriteLine(string.Join(" ", names));
        };


    }
}
