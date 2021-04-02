namespace CounterStrike
{
    using CounterStrike.Core.Contracts;
    using CounterStrike.Core.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();

        }   
    }
}
