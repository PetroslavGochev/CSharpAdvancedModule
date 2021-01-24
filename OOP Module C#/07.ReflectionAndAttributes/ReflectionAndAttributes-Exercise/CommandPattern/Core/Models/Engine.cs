using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var commandRead = Console.ReadLine();
                    var commandResult = commandInterpreter.Read(commandRead);

                    Console.WriteLine(commandResult);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
