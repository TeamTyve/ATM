using System.Collections.ObjectModel;

namespace ATM.Classes.Interfaces
{
    public interface ITracks
    {
        ObservableCollection<ITrack> FlightTracks { get; }
        void Add(string track);
    }
}