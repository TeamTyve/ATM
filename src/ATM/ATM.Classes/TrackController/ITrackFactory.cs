using ATM.Classes.Interfaces;

namespace ATM.Classes.TrackController
{
    public interface ITrackFactory
    {
        ITrack CreateTrack(string rawTrack);
    }
}