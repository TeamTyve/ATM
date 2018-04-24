using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public interface ITrackFactory
    {
        ITrack GetTrack(string track);
    }
}