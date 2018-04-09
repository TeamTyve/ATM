using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Classes
{
    public class Tracks
    {
        public Tracks()
        {
            FlightTracks = new ObservableCollection<Track>();
        }

        public ObservableCollection<Track> FlightTracks { get; set; }
    }
}
