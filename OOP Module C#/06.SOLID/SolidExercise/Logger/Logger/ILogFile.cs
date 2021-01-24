namespace LoggerExercise.Logger
{
    public interface ILogFile
    {
        public int Size { get;}

        public void Write(string message);
    }
}
