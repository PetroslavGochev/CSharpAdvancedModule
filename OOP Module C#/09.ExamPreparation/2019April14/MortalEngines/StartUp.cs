using MortalEngines.Core.Contracts;
using MortalEngines.Core.Models;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}