using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> ranking = new Dictionary<string, Dictionary<string, int>>();
            HashSet<string> contests = new HashSet<string>();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "end of contests")
            {
                var data = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0] + data[1];
                contests.Add(contest);
            }
            while((input = Console.ReadLine()) != "end of submissions")
            {
                var studentsResult = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string test = studentsResult[0] + studentsResult[1];
                var contest = studentsResult[0];
                var name = studentsResult[2];
                var points = int.Parse(studentsResult[3]);
                if (contests.Contains(test))
                {
                    if (!ranking.ContainsKey(name))
                    {
                        ranking.Add(name, new Dictionary<string, int>());
                        ranking[name].Add(contest, points);
                    }
                    else if(ranking.ContainsKey(name) && !ranking[name].ContainsKey(contest))
                    {
                        ranking[name].Add(contest, points);
                    }
                    else if(ranking[name][contest] < points)
                    {
                        ranking[name][contest] = points;
                    }
                }
            }
   
            PrintResult(ranking);

        }
        static void PrintResult(Dictionary<string, Dictionary<string, int>> ranking)
        {
            StringBuilder result = new StringBuilder();
            foreach (var max in ranking.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                result.AppendLine($"Best candidate is {max.Key} with total {max.Value.Values.Sum()} points.");
                break; ;
            }
            result.AppendLine($"Ranking:");
            foreach (var contest in ranking.OrderBy(x=>x.Key))
            {
                result.AppendLine($"{contest.Key}");
                foreach (var points in contest.Value.OrderByDescending(x=>x.Value))
                {
                    result.AppendLine($"#  {points.Key} -> {points.Value}");
                }
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
