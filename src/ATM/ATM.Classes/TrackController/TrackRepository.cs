using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public class TrackRepository : ITrackRepository
    {
        public ITrackCalculations TrackCalculations { get; set; }

        public TrackRepository(ITrackCalculations trackCalculations)
        {
            TrackCalculations = trackCalculations;
        }


        public ObservableCollection<ITrack> FlightTracks { get; private set; } = new ObservableCollection<ITrack>();

        public void Add(string track)
        {
            // Update
            var model = new Track();

            if (FlightTracks.FirstOrDefault(x => x.Tag == model.Tag) == null)
            {
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

        public void Update(ITrack track)
        {
            var toRemove = FlightTracks.First(x => x.Tag == track.Tag);
            try
            {
                double distance = TrackCalculations.CalculateDistance(track, toRemove);
                var time = TrackCalculations.CalculateTime(track, toRemove);
                try
                {
                    track.AirSpeed = TrackCalculations.CalculateAirSpeed(track, distance, time);
                }
                catch (DivideByZeroException)
                {
                    track.AirSpeed = 0;
                }

                track.Direction = TrackCalculations.CalculateDirection(track, toRemove);

                FlightTracks.Remove(toRemove);
                FlightTracks.Add(track);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
