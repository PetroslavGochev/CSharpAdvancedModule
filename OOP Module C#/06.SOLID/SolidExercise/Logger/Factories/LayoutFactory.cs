using LogerExercise.Layout;
using LoggerExercise.Layout;

namespace LoggerExercise.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string layoutArgs)
        {
            ILayout layout = null;
            if (layoutArgs == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (layoutArgs == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            return layout;
        }
    }
}
