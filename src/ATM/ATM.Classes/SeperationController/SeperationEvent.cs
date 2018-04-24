using System;

namespace ATM.Classes
{
    public class SeperationEvent
    {
        public SeperationEvent(string tag1, DateTime time, string tag2)
        {
            Tag1 = tag1;
            Tag2 = tag2;
            Time = time;
        }

        public string Tag1;
        public string Tag2;
        public DateTime Time;
    }
}