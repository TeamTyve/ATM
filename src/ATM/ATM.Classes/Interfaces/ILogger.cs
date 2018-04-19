namespace ATM.Classes.Interfaces
{
    public interface ILogger
    {
        object LockObj { get; set; }
        void Clear();
        void WriteLine(string message);
    }
}