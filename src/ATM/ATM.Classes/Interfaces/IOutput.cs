using System;
using System.Collections.ObjectModel;

namespace ATM.Classes.Interfaces
{
    public interface IOutput
    {
        void Print(ObservableCollection<ITrack> tracks);
        void SeperationAlert(string tag1, string tag2, DateTime time);
    }
}