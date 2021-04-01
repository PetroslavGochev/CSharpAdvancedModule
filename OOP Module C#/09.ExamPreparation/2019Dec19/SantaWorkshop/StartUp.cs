namespace SantaWorkshop
{
    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Core.Models;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
