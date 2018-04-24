using System;
using System.Collections.Generic;
using ATM.Classes.Interfaces;

namespace ATM.Classes.SeperationController
{
    public class Seperation : ISeperation
    {
        public List<SeperationEvent> CheckSeperation(List<ITrack> list)
        {
            var seperationEvents = new List<SeperationEvent>();
            foreach (var current in list)
            {
                foreach (var track in list)
                {
                    if (track.IsInAirspace && current.IsInAirspace)
                    {
                        if (current.Tag == track.Tag)
                        {
                        }
                        else if ((Math.Abs(current.Vector.Z - track.Vector.Z) <= 300) && (
                                     (current.Vector.X + 5000 >= track.Vector.X &&
                                      current.Vector.X - 5000 <= track.Vector.X) &&
                                     (current.Vector.Y + 5000 >= track.Vector.Y &&
                                      current.Vector.Y - 5000 <= track.Vector.Y)))
                        {
                           seperationEvents.Add(new SeperationEvent(current.Tag, DateTime.Now, track.Tag));
                        }
                    }
                }
            }
            return seperationEvents;
        }
    }
}
