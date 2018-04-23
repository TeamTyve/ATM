using ATM.Classes.Domain;
using TransponderReceiver;

namespace ATM.Classes.Interfaces
{
    public interface ITrackObservationSystem
    {
        ITransponderReceiver Receiver { get; set; }
        ITrackRepository TrackRepository { get; set; }
        IOutput Output { get; set; }
        IAirSpace AirSpace { get; set; }
        ISeperation Seperation { get; set; }
        ISeperationAlertRepository SeperationAlertRepository { get; set; }
    }
}