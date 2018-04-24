using System;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;

namespace ATM.Classes.TrackController
{
    public class TrackFactory : ITrackFactory
    {
        public ITrack CreateTrack(string rawTrack)
        {
            var track = new Track();

            var split = rawTrack.Split(';');
            track.Tag = split[0];
            track.Vector.X = Int32.Parse(split[1]);
            track.Vector.Y = Int32.Parse(split[2]);
            track.Vector.Z = Int32.Parse(split[3]);
            track.Timestamp = DateTime.ParseExact(split[4], "yyyyMMddHHmmssfff", null);

            return track;
        }
    }
}