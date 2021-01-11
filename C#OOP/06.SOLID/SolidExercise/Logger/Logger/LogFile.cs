using System;
using System.IO;
using System.Linq;

namespace LoggerExercise.Logger
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
        public int Size => File.ReadAllText(LogFilePath).ToCharArray().Sum(x => x);

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message + Environment.NewLine);
        }
    }
}
