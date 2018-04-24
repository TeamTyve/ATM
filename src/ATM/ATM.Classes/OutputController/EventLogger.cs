using System;
using System.IO;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Boundary
{
    public class EventLogger : ILogger
    {
        private readonly string _path;

        public EventLogger(string path = null)
        {
            if (path == null)
                path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Events.txt";
            _path = path;
        }

        public object LockObj { get; set; } = new object();

        public void Clear()
        {
            lock (LockObj)
            {
                using (var streamWriter = new StreamWriter(_path))
                    streamWriter.Write("");
            }
        }

        public void WriteLine(string message)
        {
            lock (LockObj)
            {
                using (var streamWriter = new StreamWriter(_path, true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
}