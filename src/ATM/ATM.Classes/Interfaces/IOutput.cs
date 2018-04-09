using System.Collections.ObjectModel;

namespace ATM.Classes.Interfaces
{
    public interface IOutput
    {
        void Print(ObservableCollection<ITrack> tracks);
    }
}