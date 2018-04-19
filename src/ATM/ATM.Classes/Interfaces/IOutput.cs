using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ATM.Classes.Domain;

namespace ATM.Classes.Interfaces
{
    public interface IOutput
    {
        void Print(IEnumerable<ITrack> tracks);
        void SeperationAlert(ISeperationAlert seperationAlert);
    }
}