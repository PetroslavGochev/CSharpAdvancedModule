
using LoggerExercise.Appenders;
using LoggerExercise.Enumerators;

namespace LoggerExercise.Logger
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appender)
        {
            this.Appenders = appender;
        }

        public IAppender[] Appenders { get; }


        public void Critical(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.CRITICAL, fileApender);
        }

        public void Error(string dateTime, string fileApender)
        {
            Append(dateTime,ReportLevel.ERROR,fileApender);
        }

        public void Fatal(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.FATAL, fileApender);
        }

        public void Info(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.INFO, fileApender);
        }

        public void Warning(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.WARNING, fileApender);
        }
        private void Append(string dateTime,ReportLevel reportLevel,string fileApender)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(dateTime, reportLevel, fileApender);
            }
        }
    }
}
