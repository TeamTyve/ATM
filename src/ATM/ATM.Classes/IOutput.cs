using System.Collections.ObjectModel;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public interface IOutput
    {
        void Print(ObservableCollection<ITrack> tracks);
    }
}