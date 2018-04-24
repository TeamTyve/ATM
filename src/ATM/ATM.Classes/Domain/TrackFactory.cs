using System;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public class TrackFactory : ITrackFactory
    {
        public ITrack GetTrack(string track)
        {
            var _track = new Track();

            var split = track.Split(';');
            _track.Tag = split[0];
            _track.Vector.X = Int32.Parse(split[1]);
            _track.Vector.Y = Int32.Parse(split[2]);
            _track.Vector.Z = Int32.Parse(split[3]);
            _track.Timestamp = DateTime.ParseExact(split[4], "yyyyMMddHHmmssfff", null);

            return _track;
        }
    }
}