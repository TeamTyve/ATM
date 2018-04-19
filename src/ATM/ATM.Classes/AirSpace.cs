using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;
using ATM.Utility;

namespace ATM.Classes
{
    public class AirSpace : IAirSpace
    {
        public Vector3D Coordinate1 { get; set; }
        public Vector3D Coordinate2 { get; set; }

        public AirSpace(Vector3D coordinate1 = null, Vector3D coordinate2 = null)
        {
            // Lower Bounds
            Coordinate1 = coordinate1 ?? new Vector3D(10000, 10000, 500);

            if (!Coordinate1.IsPositive())
                throw new ArgumentException();

            // Higher bounds
            Coordinate2 = coordinate2 ?? new Vector3D(90000, 90000, 20000);

            if (!Coordinate2.IsPositive())
                throw new ArgumentException();

            if ((Coordinate2.X <= Coordinate1.X) ||
                (Coordinate2.Y <= Coordinate1.Y) ||
                (Coordinate2.Z <= Coordinate1.Z))
                throw new ArgumentException();
        }

        public Vector3D Center()
        {
            return new Vector3D
            {
                X = Math.Abs(Coordinate2.X + Coordinate1.X) / 2,
                Y = Math.Abs(Coordinate2.Y + Coordinate1.Y) / 2,
                Z = Math.Abs(Coordinate1.Z + Coordinate2.Z) / 2
            };
        }

        public bool CheckAirSpace(int x, int y, int z)
        {
            return CheckAirSpace(new Vector3D(x, y, z));
        }

        public bool CheckAirSpace(Vector3D track)
        {
            return (track.X >= Coordinate1.X && track.X <= Coordinate2.X) &&
                   (track.Y >= Coordinate1.Y && track.Y <= Coordinate2.Y) &&
                   (track.Z >= Coordinate1.Z && track.Z <= Coordinate2.Z);
        }
    }
}
