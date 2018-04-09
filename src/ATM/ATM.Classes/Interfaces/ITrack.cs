using System;

namespace ATM.Classes.Interfaces
{
    public interface ITrack
    {
        int Altitude { get; set; }
        string Tag { get; set; }
        DateTime Timestamp { get; set; }
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
    }
}