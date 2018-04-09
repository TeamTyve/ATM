using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class Tracks : ITracks
    {
        public ObservableCollection<ITrack> FlightTracks { get; private set; } = new ObservableCollection<ITrack>();

        public void Add(string track)
        {
            var model = new Track(track);

            if (FlightTracks.FirstOrDefault(x => x.Tag == model.Tag) == null)
            {
                FlightTracks.Add(model);
            }
            else
            {
                var toRemove = FlightTracks.First(x => x.Tag == model.Tag);
                FlightTracks.Remove(toRemove);
                FlightTracks.Add(model);
            }
        }
    }
}
