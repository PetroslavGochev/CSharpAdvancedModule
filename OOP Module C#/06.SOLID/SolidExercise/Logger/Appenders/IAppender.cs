using LogerExercise.Layout;
using LoggerExercise.Enumerators;

namespace LoggerExercise.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get;  }
        public ReportLevel ReportLevel { get; set; }
        public void Append(string dateTime, ReportLevel report, string message);
    }
}
