using ATM.Classes.Domain;
using TransponderReceiver;

namespace ATM.Classes.Interfaces
{
    public interface ITrackObservationSystem
    {
        ITransponderReceiver Receiver { get;}
        ITrackRepository TrackRepository { get; }
        IOutput Output { get; set; }
        IAirSpace AirSpace { get;}
        ISeperation Seperation { get;}
        ISeperationAlertRepository SeperationAlertRepository { get; set; }
    }
}