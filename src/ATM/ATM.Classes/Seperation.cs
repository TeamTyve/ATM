using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class SeperationEventArgs : EventArgs
    {
        public SeperationEventArgs(string tag1, DateTime time, string tag2)
        {
            Tag1 = tag1;
            Tag2 = tag2;
            Time = time;
            
        }
        
        public string Tag1;
        public string Tag2;
        public DateTime Time; 
    }

    public class Seperation : ISeperation
    {
        public event EventHandler<SeperationEventArgs> SeperationEvent;

        public void CheckSeperation(List<ITrack> list, ITrack current)
        {
            foreach (var track in list)
            {
                if (track.IsInAirspace && current.IsInAirspace)
                {
                    if (current.Tag == track.Tag)
                    {
                    }
                    else if((Math.Abs(current.Vector.Z-track.Vector.Z)<=300) && (
                        (current.Vector.X+5000>=track.Vector.X && current.Vector.X-5000 <= track.Vector.X) &&
                        (current.Vector.Y + 5000 >= track.Vector.Y && current.Vector.Y-5000 <= track.Vector.Y)))
                    {
                        RaiseSeperationEvent(new SeperationEventArgs(current.Tag,DateTime.Now, track.Tag));
                    }
                   
                   
                }
            }
            
        }

        public IEnumerable<Tuple<ITrack, ITrack>> CheckSeperation(List<ITrack> tracks)
        {
            var list = new List<Tuple<ITrack, ITrack>>();


            foreach (var current in tracks)
            {
                foreach (var track in tracks)
                {
                    if (current.Tag == track.Tag)
                    {
                    }
                    else if (Math.Abs(current.Vector.Z - track.Vector.Z) <= 300 &&
                             (current.Vector.X + 5000 <= track.Vector.X || current.Vector.X - 5000 >= track.Vector.X) ||
                             (current.Vector.Y + 5000 <= track.Vector.Y || current.Vector.Y - 5000 >= track.Vector.Y))
                    {
                    }
                    else
                    {
                        list.Add(new Tuple<ITrack, ITrack>(current, track));
                    }
                }
            }

            return list.AsEnumerable();
        }

        protected virtual void RaiseSeperationEvent(SeperationEventArgs e)
        {
            SeperationEvent?.Invoke(this, e);
        }
    }
}
