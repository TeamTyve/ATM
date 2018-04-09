using System;
using System.Collections.ObjectModel;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class Output : IOutput
    {
        public void Print(ObservableCollection<ITrack> tracks)
        {
            Console.Clear();
            Console.WriteLine($"Current Time: {DateTime.Now}");
            Console.WriteLine("Track Objectification Software");
            Console.WriteLine("\n---------------------------------------------------------------------------");
            foreach (var track in tracks)
            {
                Console.WriteLine($"Tag:{track.Tag} | Altitude:{track.Altitude} | x:{track.XCoordinate}, y:{track.YCoordinate} | Timestamp:{track.Timestamp}.{track.Timestamp.Millisecond}");
            }
        }
    }
}