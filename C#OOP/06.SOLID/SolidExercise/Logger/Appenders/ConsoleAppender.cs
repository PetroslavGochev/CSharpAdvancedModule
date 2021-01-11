using LogerExercise.Layout;
using LoggerExercise.Enumerators;
using System;

namespace LoggerExercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel report, string message)
        {
            this.MessagesAppended++;
            if(this.ReportLevel <= report)
            {
                Console.WriteLine(Layout.Format, dateTime, report, message);
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
