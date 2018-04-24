using ATM.Classes.Interfaces;

namespace ATM.Classes.Boundary
{
    public class LogHelper : ILogHelper
    {
        public ILogger Logger { get; set; }

        public void Log(LoggerTarget target, string message, bool clear = false)
        {
            switch (target)
            {
                case LoggerTarget.Console:
                    if (Logger == null)
                    {
                        Logger = new ConsoleLogger();
                    }
                    Logger.WriteLine(message);
                    if (clear)
                        Logger.Clear();
                    break;
                case LoggerTarget.Event:
                    if (Logger == null)
                    {
                        Logger = new EventLogger();
                    }
                    Logger.WriteLine(message);
                    if (clear)
                        Logger.Clear();
                    break;
            }
        }
    }
}