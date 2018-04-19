using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class Track : ITrack
    {
        public Track(string info)
        {
            Extract(info);
        }

        public string Tag { get; set; }

        public Vector3D Vector { get; set; } = new Vector3D();
        

        public DateTime Timestamp { get; set; }
        public decimal AirSpeed { get; set; }
        public bool IsInAirspace { get; set; }

        private void Extract(string info)
        {
            var split = info.Split(';');
            this.Tag = split[0];
            this.Vector.X = Int32.Parse(split[1]);
            this.Vector.Y = Int32.Parse(split[2]);
            this.Vector.Z = Int32.Parse(split[3]);
            this.Timestamp = DateTime.ParseExact(split[4],"yyyyMMddHHmmssfff",null);
        }
    }
}


