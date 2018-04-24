using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ATM.Classes.Interfaces
{
    public interface ITrackRepository
    {
        ObservableCollection<ITrack> FlightTracks { get; }
        void Add(ITrack model);
        void Add(List<ITrack> tracks);

        ITrack Get(string tag);
        ITrack Get(ITrack track);
        IEnumerable<ITrack> GetAll();
    }
}