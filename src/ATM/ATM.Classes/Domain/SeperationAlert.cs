using System;
using System.Net.Http.Headers;

namespace ATM.Classes.Domain
{
    public class SeperationAlert : ISeperationAlert
    {
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public DateTime Time { get; set; }

        public SeperationAlert(string tag1, string tag2, DateTime time)
        {
            Tag1 = tag1;
            Tag2 = tag2;
            Time = time;
        }
    }
}