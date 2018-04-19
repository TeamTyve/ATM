using System;
using ATM.Utility;

namespace ATM.Classes.Interfaces
{
    public interface ITrack
    {
        
        string Tag { get; set; }
        DateTime Timestamp { get; set; }
        Vector3D Vector { get; set; }
        Decimal AirSpeed { get; set; }
        bool IsInAirspace { get; set; }
        
    }
}