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
                if (track.IsInAirspace)
                {
                ConsoleOut.WriteLine($"Tag:{track.Tag} | Altitude:{track.Vector.Z} | x:{track.Vector.X}, y:{track.Vector.Y} | Timestamp:{track.Timestamp}.{track.Timestamp.Millisecond} | Airspeed: {track.AirSpeed:#.##} | Is in airspace: {track.IsInAirspace}" );

                }
            }
        }
        public void SeperationAlert(string tag1, string tag2, DateTime time)
        {
            Console.WriteLine($"Flight: {tag1} collision warning with flight: {tag2}. TIME:{time}");
        }
    }

    
}