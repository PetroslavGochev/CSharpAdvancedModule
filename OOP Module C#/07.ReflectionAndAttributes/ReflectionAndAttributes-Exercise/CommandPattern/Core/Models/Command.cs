using CommandPattern.Core.Contracts;
using System;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class Command : ICommand
    {
        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in args)
            {
                sb.AppendLine($"Hello, {item}");
            }
            return sb.ToString();
        }
    }
}
