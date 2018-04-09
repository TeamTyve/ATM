using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Classes
{
    
        
        public class Track
        {
            public Track(string info)
            {

                var split = info.Split(';');
                this.Tag = split[0];
                this.XCoordinate = split[1];
                this.YCoordinate = split[2];
                this.Altitude = split[3];
                this.Timestamp = split[4];
            }

            public string Tag { get; set; }
            public string XCoordinate { get; set; }
            public string YCoordinate { get; set; }
            public string Altitude { get; set; }
            public string Timestamp { get; set; }

        }
    }
   

