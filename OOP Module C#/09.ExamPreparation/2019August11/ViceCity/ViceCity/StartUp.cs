using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;
using ViceCity.Core.Models;

namespace ViceCity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
