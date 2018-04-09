using TransponderReceiver;

namespace ATM.Classes.Interfaces
{
    public interface ITOS
    {
        IOutput Output { get; set; }
        ITransponderReceiver Receiver { get; }
        ITracks Tracks { get; }
    }
}