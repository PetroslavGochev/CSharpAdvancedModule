
using LogerExercise.Layout;
using LoggerExercise.Appenders;
using LoggerExercise.Engine;
using LoggerExercise.Enumerators;
using LoggerExercise.Layout;
using LoggerExercise.Logger;
using System;

namespace LogerExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {           
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
