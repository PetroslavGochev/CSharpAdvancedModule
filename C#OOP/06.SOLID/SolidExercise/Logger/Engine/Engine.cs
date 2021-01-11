using System;

namespace LoggerExercise.Engine
{
    public class Engine : IEngine
    {
     //            2
     //        ConsoleAppender SimpleLayout CRITICAL
     //FileAppender XmlLayout
     //INFO | 3 / 26 / 2015 2:08:11 PM | Everything seems fine
     //WARNING | 3 / 26 / 2015 2:22:13 PM | Warning: ping is too high - disconnect imminent
     //ERROR | 3 / 26 / 2015 2:32:44 PM | Error parsing request
     //CRITICAL | 3 / 26 / 2015 2:38:01 PM | No connection string found in App.config
     //FATAL | 3 / 26 / 2015 2:39:19 PM | mscorlib.dll does not respond
     //END
        public void Run()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
               
            }
        }
    }
}
