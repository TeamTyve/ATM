﻿using System;
using ATM.Classes.Interfaces;
using ATM.Utility;

namespace ATM.Classes.Domain
{
    public class Track : ITrack
    {
        public Track(string info)
        {
            Extract(info);
        }

        public string Tag { get; set; }

        public Vector3D Vector { get; set; } = new Vector3D();
        
        public double Direction { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal AirSpeed { get; set; }
        public bool IsInAirspace { get; set; }

        private void Extract(string info)
        {
            try
            {
                var split = info.Split(';');
                this.Tag = split[0];
                this.Vector.X = Int32.Parse(split[1]);
                this.Vector.Y = Int32.Parse(split[2]);
                this.Vector.Z = Int32.Parse(split[3]);
                this.Timestamp = DateTime.ParseExact(split[4], "yyyyMMddHHmmssfff", null);
            }
            catch (FormatException e)
            {
                throw;
            }
           
        }
    }
}


