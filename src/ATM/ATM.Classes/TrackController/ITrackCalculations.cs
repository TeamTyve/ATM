using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public interface ITrackCalculations
    {
        decimal CalculateAirSpeed(ITrack model, double distance, double time);
        double CalculateDirection(ITrack model, ITrack toRemove);
        double CalculateDistance(ITrack model, ITrack toRemove);
        double CalculateTime(ITrack model, ITrack toRemove);
    }
}