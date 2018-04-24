using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;

namespace ATM.Classes.SeperationController
{
    public class SeperationController
    {
        private ISeperation seperation;
        public List<SeperationEvent> Events;
        public List<SeperationEvent> toBeRemoved {get;} = new List<SeperationEvent>();
        public SeperationController(ISeperation seperation)
        {
            this.seperation = seperation;
        }
        public List<SeperationEvent> CheckSeperation(List<ITrack> list)
        {
            var newEvents = seperation.CheckSeperation(list);
            
            foreach (var seperationEvent in newEvents)
            {
                if (!Events.Contains(seperationEvent))
                {
                    toBeRemoved.Add(seperationEvent);
                }
            }

            Events = newEvents; 

            return seperation.CheckSeperation(list);
        }
    }

}
