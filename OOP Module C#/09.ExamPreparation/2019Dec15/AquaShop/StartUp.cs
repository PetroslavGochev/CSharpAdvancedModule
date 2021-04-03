namespace AquaShop
{
    using AquaShop.Core.Contracts;
    using AquaShop.Core.Models;

    public class StartUp
    {
        public static void Main()
        {

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
