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

            foreach (var rawTrack in rawTracks)
            {
                newTracks.Add(TrackFactory.CreateTrack(rawTrack));
            }

            var currentTracks = TrackRepository.GetAll();
            var tracksToRemove = new List<ITrack>();
            var tracksToAdd = new List<ITrack>();

            foreach (var newTrack in newTracks)
            {

            }





        }




    }
}
