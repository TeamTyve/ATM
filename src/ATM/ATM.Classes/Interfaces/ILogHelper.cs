namespace ATM.Classes.Boundary
{
    public interface ILogHelper
    {
        void Log(LoggerTarget target, string message, bool clear = false);
    }
}