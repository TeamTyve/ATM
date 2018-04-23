using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public class TrackRepository : ITrackRepository
    {
        public ObservableCollection<ITrack> FlightTracks { get; private set; } = new ObservableCollection<ITrack>();

        public void Add(string track)
        {
            var model = new Track(track);

            if (FlightTracks.FirstOrDefault(x => x.Tag == model.Tag) == null)
            {
                FlightTracks.Add(model);

            }
            else
            {
                var toRemove = FlightTracks.First(x => x.Tag == model.Tag);
                try
                {
                    double distance = CalculateDistance(model, toRemove);
                    var time = CalculateTime(model, toRemove);
                    try
                    {
                        model.AirSpeed = CalculateAirSpeed(model, distance, time);
                    }
                    catch (DivideByZeroException)
                    {
                        model.AirSpeed = 0;
                    }

                    model.Direction = CalculateDirection(model, toRemove);
                    FlightTracks.Remove(toRemove);
                    FlightTracks.Add(model);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public ITrack Get(string tag)
            {
                return FlightTracks.FirstOrDefault(o => o.Tag == tag);
            }

            public ITrack Get(ITrack track)
            {
                return FlightTracks.FirstOrDefault(o => o.Tag == track.Tag);
            }

            public IEnumerable<ITrack> GetAll()
            {
                return FlightTracks.AsEnumerable();
            }

            private decimal CalculateAirSpeed(Track model, double distance, double time)
            {
                return model.AirSpeed = (decimal) distance / (decimal) time;
            }

            private double CalculateDirection(Track model, ITrack toRemove)
            {
                return model.Direction = Math.Atan2((model.Vector.X - toRemove.Vector.X),
                                             (model.Vector.Y - toRemove.Vector.Y)) * (180 / Math.PI);
            }

            private double CalculateTime(ITrack model, ITrack toRemove)
            {
                return model.Timestamp.Subtract(toRemove.Timestamp).TotalSeconds;
            }

            private double CalculateDistance(ITrack model, ITrack toRemove)
            {
                // sqrt((x1-x2)^2+(y1-y2)^2+(z1-z2)^2)
                return Math.Abs(Math.Sqrt(Math.Pow((toRemove.Vector.Y - model.Vector.Y), 2)
                                          + Math.Pow((toRemove.Vector.X - model.Vector.X), 2)));
            }
    }
}
