using System;
using ATM.Classes.Interfaces;
using ATM.Utility;

namespace ATM.Classes.Domain
{
    public class Track : ITrack
    {
        public string Tag { get; set; }
        public Vector3D Vector { get; set; } = new Vector3D();
        public double Direction { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal AirSpeed { get; set; }
        public bool IsInAirspace { get; set; }

        
    }
}


