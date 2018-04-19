using System;
using System.Collections.Generic;

namespace ATM.Classes.Interfaces
{
    public interface ISeperation
    {
        event EventHandler<SeperationEventArgs> SeperationEvent;

        void CheckSeperation(List<ITrack> list, ITrack current);
    }
}