using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;

namespace ATM.Classes.TrackController
{
    public class TrackController
    {
        public ITrackRepository TrackRepository { get; set; }
        public IAirSpace AirSpace { get; set; }
        public ITrackFactory TrackFactory { get; set; }

        public TrackController(ITrackRepository trackRepository, IAirSpace airSpace, ITrackFactory trackFactory)
        {
            TrackRepository = trackRepository;
            AirSpace = airSpace;
            TrackFactory = trackFactory;
        }

        public void AddTracks(List<string> rawTracks)
        {
            var newTracks = new List<ITrack>();

            // Objectify new tracks
            foreach (var rawTrack in rawTracks)
            {
                var track = TrackFactory.CreateTrack(rawTrack);
                if (AirSpace.CheckAirSpace(track.Vector))
                {
                    newTracks.Add(track);
                }
            }

            //Compare to old tracks and update

            var curTracks = TrackRepository.GetAll().ToList();

            foreach (var newTrack in newTracks)
            {
                if (!curTracks.Contains(newTrack))
                {
                    
                }
            }



            

        }
    }
}
