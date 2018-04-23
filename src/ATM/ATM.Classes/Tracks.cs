﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class Tracks : ITracks
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
                double distance = CalculateDistance(model, toRemove);
                var time = CalculateTime(model, toRemove);
                try
                {
                    model.AirSpeed = CalculateAirSpeed(model, distance, time);
                }
                catch (DivideByZeroException e)
                {
                    model.AirSpeed = 0;
                }
                model.Direction = CalculateDirection(model, toRemove);
                FlightTracks.Remove(toRemove);
                FlightTracks.Add(model);
            }
        }

        private static decimal CalculateAirSpeed(Track model, double distance, double time)
        {
            return model.AirSpeed = (decimal)distance / (decimal)time;
        }

        private static double CalculateDirection(Track model, ITrack toRemove)
        {
            return model.Direction = Math.Atan2((model.Vector.X - toRemove.Vector.X),
                                  (model.Vector.Y - toRemove.Vector.Y)) * (180 / Math.PI);
        }

        private static double CalculateTime(ITrack model, ITrack toRemove)
        {
            return model.Timestamp.Subtract(toRemove.Timestamp).TotalSeconds;
        }

        private static double CalculateDistance(ITrack model, ITrack toRemove)
        {
            // sqrt((x1-x2)^2+(y1-y2)^2+(z1-z2)^2)
            return Math.Abs(Math.Sqrt(Math.Pow((toRemove.Vector.X - model.Vector.X), 2)
                                     + Math.Pow((toRemove.Vector.Y - model.Vector.Y), 2)));
        }
    }
}
