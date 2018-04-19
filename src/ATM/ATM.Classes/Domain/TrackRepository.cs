﻿using System;
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
                // sqrt((x1-x2)^2+(y1-y2)^2+(z1-z2)^2)
                var distance = Math.Abs(Math.Sqrt(Math.Pow((toRemove.Vector.X-model.Vector.X),2) 
                                         + Math.Pow((toRemove.Vector.Y - model.Vector.Y), 2) 
                                         + Math.Pow((toRemove.Vector.Z - model.Vector.Z), 2)));
                var time = model.Timestamp.Subtract(toRemove.Timestamp).TotalSeconds;
                try
                {
                    model.AirSpeed = (decimal) distance / (decimal) time;
                }
                catch (DivideByZeroException)
                {
                    model.AirSpeed = 0; 
                }
                FlightTracks.Remove(toRemove);
                FlightTracks.Add(model);
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
    }
}