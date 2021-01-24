using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vlogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Statistics")
            {
                var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(command[1] == "joined")
                {
                    var name = command[0];
                    Joined(vlogger, name);
                }
                else if(command[1] == "followed")
                {
                    var follower = command[0];
                    var followed = command[2];
                    if(followed == follower)
                    {
                        continue;
                    }
                    if(vlogger.ContainsKey(followed) && vlogger.ContainsKey(follower))
                    {
                        Follow(vlogger, follower, followed);
                    }
                }
            }
            PrintResult(vlogger);
        }
        static void Joined(Dictionary<string, Dictionary<string, HashSet<string>>> vlogger,string name)
        {
            if (!vlogger.ContainsKey(name))
            {
                vlogger.Add(name, new Dictionary<string, HashSet<string>>());
                vlogger[name].Add("followers", new HashSet<string>());
                vlogger[name].Add("following", new HashSet<string>());
            }
        }
        static void Follow(Dictionary<string, Dictionary<string, HashSet<string>>> vlogger, string follower,string followed)
        {
            vlogger[followed]["followers"].Add(follower);
            vlogger[follower]["following"].Add(followed);
        }
        static void PrintResult(Dictionary<string, Dictionary<string, HashSet<string>>> vlogger)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");
            vlogger = vlogger.OrderByDescending(x => x.Value["followers"].Count)
                             .ThenBy(x => x.Value["following"].Count)
                             .ToDictionary(x => x.Key, y => y.Value);
            int counter = 1;
            foreach (var item in vlogger)
            {
                if(counter == 1)
                {
                    result.AppendLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count}" +
                        $" following");
                    foreach (var followers in item.Value["followers"].OrderBy(x=>x))
                    {
                        result.AppendLine($"*  {followers}");
                    }
                    counter++;
                    continue;
                }
                result.AppendLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} " +
                    $"following");
                counter++;
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
