using ATM.Classes.Interfaces;

namespace ATM.Classes.Boundary
{
    public static class LogHelper
    {
        private static ILogger logger = null;

        public static void Log(LoggerTarget target, string message, bool clear = false)
        {
            switch (target)
            {
                case LoggerTarget.Console:
                    logger = new ConsoleLogger();
                    logger.WriteLine(message);
                    if (clear)
                        logger.Clear();
                    break;
                case LoggerTarget.Event:
                    logger = new EventLogger();
                    logger.WriteLine(message);
                    if (clear)
                        logger.Clear();
                    break;
                default:
                    return;
            }
        }
    }
}