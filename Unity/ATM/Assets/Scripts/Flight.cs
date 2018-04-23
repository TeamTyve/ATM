using UnityEngine;

namespace Assets.Scripts
{
	public class Flight : MonoBehaviour {
		public HandleTextFile hTF { get; set; }

		// Use this for initialization
		void Start ()
		{
			hTF = new HandleTextFile();
			hTF.ReadString();
		}
	
		// Update is called once per frame
		void Update ()
		{
		    hTF.ReadString();


			foreach (var track in hTF.Tracks)
			{
				track.Update();
			}
		}
	}
}