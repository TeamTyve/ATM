using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public interface ISeperation
    {
        event EventHandler<SeperationEventArgs> SeperationEvent;

        void CheckSeperation(List<ITrack> list, ITrack current);
    }
}