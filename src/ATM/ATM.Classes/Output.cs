using System;
using System.Collections.ObjectModel;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class Output : IOutput
    {
        public IConsoleOut ConsoleOut { get; set; } = new ConsoleOut();

        public void Print(ObservableCollection<ITrack> tracks)
        {
            ConsoleOut.Clear();
            ConsoleOut.WriteLine($"Current Time: {DateTime.Now}");
            ConsoleOut.WriteLine("Track Objectification Software");
            ConsoleOut.WriteLine("\n---------------------------------------------------------------------------");
            foreach (var track in tracks)
            {
                ConsoleOut.WriteLine($"Tag:{track.Tag} | Altitude:{track.Altitude} | x:{track.XCoordinate}, y:{track.YCoordinate} | Timestamp:{track.Timestamp}.{track.Timestamp.Millisecond}");
            }
        }
    }
}