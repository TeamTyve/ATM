﻿using System;
using System.Collections.Generic;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Boundary
{
    public class Output : IOutput
    {
        public ILogHelper LogHelper { get; set; } = new LogHelper();

        public void Print(IEnumerable<ITrack> tracks)
        {
            LogHelper.Log(LoggerTarget.Console, String.Empty, true);
            LogHelper.Log(LoggerTarget.Console, $"Current Time: {DateTime.Now}");
            LogHelper.Log(LoggerTarget.Console, "Track Objectification Software");
            LogHelper.Log(LoggerTarget.Console, "\n---------------------------------------------------------------------------");
            foreach (var track in tracks)
            {
                if (track.IsInAirspace)
                {
                    LogHelper.Log(LoggerTarget.Console,
                        $"Tag:{track.Tag} | Altitude:{track.Vector.Z} " +
                        $"| x:{track.Vector.X}, y:{track.Vector.Y} " +
                        $"| Timestamp:{track.Timestamp}.{track.Timestamp.Millisecond} " +
                        $"| Airspeed: {track.AirSpeed:#.##} " +
                        $"| Is in airspace: {track.IsInAirspace}" + 
                        $"| Direction: {track.Direction:#.##}");
                }
            }
        }
        public void SeperationAlert(ISeperationAlert seperationAlert)
        {
            LogHelper.Log(LoggerTarget.Console, $"Flight: {seperationAlert.Tag1} collision warning with flight: {seperationAlert.Tag2}. TIME:{seperationAlert.Time}");
        }
    }


}