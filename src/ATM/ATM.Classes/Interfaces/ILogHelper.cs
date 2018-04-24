using ATM.Classes.Interfaces;

namespace ATM.Classes.Boundary
{
    public interface ILogHelper
    {
        ILogger Logger { get; set; }
        void Log(LoggerTarget target, string message, bool clear = false);
    }
}