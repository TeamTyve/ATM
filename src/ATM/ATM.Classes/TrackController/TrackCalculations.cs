using System;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public class TrackCalculations : ITrackCalculations
    {
        public decimal CalculateAirSpeed(ITrack model, double distance, double time)
        {
            return model.AirSpeed = (decimal)distance / (decimal)time;
        }

        public double CalculateDirection(ITrack model, ITrack toRemove)
        {
            return model.Direction = Math.Atan2((model.Vector.X - toRemove.Vector.X),
                                         (model.Vector.Y - toRemove.Vector.Y)) * (180 / Math.PI);
        }

        public double CalculateTime(ITrack model, ITrack toRemove)
        {
            return model.Timestamp.Subtract(toRemove.Timestamp).TotalSeconds;
        }

        public double CalculateDistance(ITrack model, ITrack toRemove)
        {
            // sqrt((x1-x2)^2+(y1-y2)^2+(z1-z2)^2)
            return Math.Abs(Math.Sqrt(Math.Pow((toRemove.Vector.Y - model.Vector.Y), 2)
                                      + Math.Pow((toRemove.Vector.X - model.Vector.X), 2)));
        }
    }
}