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
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }

        private void Extract(string info)
        {
            var split = info.Split(';');
            this.Tag = split[0];
            this.XCoordinate = Int32.Parse(split[1]);
            this.YCoordinate = Int32.Parse(split[2]);
            this.Altitude = Int32.Parse(split[3]);
            this.Timestamp = DateTime.ParseExact(split[4],"yyyyMMddHHmmssfff",null);
        }
    }
}


