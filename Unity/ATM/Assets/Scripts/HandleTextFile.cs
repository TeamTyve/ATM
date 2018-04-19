using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class HandleTextFile
    {
        public List<Track> Tracks { get; set; }

        public HandleTextFile()
        {
            Tracks = new List<Track>();
        }

        public void ReadString()
        {
            string path = "Assets/Resources/test.txt";

            StreamReader reader = new StreamReader(path);

            while (reader.Peek() >= 0)
            {
                Objectify(reader.ReadLine());
            }

            reader.Close();
        }

        public void Objectify(string track)
        {
            var trk = new Track();
            var str = track.Split(',');

            trk.Tag = str[0];
            trk.X = Int32.Parse(str[1]);
            trk.Y = Int32.Parse(str[2]);
            trk.Z = Int32.Parse(str[3]);

            if (!Exists(trk))
            {
                trk.Instantiate();
            }
            else
            {
                Update(trk);
            }
            Tracks.Add(trk);
        }

        public bool Exists(Track track)
        {
            return Tracks.Find(o => o.Tag == track.Tag) != null;
        }

        public void Update(Track newTrack)
        {
            var track = Tracks.Find(o => o.Tag == newTrack.Tag);

            track.Update(newTrack.X, newTrack.Y, newTrack.Z);
        }
    }
}