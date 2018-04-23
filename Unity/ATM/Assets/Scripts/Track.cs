using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Track
    {
        public string Tag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public GameObject Flight { get; set; }

        public Track()
        {
        }

        public void Instantiate()
        {
            Flight = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Update();
        }

        public void Update()
        {
            Flight.name = Tag;
            Flight.transform.position = new Vector3(X, Y, Z);
        }

        public void Update(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            Update();
        }
    }
}