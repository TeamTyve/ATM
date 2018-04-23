using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Classes.Boundary;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Domain
{
    public class SeperationAlertRepository : ISeperationAlertRepository
    {
        public SeperationAlertRepository()
        {
            LogHelper.Log(LoggerTarget.Event, String.Empty, true);
        }
        private readonly List<ISeperationAlert> _seperationAlerts = new List<ISeperationAlert>();

        public void Add(ISeperationAlert seperationAlert)
        {
            if (Get(seperationAlert) == null)
            {
                _seperationAlerts.Add(seperationAlert);
                LogHelper.Log(LoggerTarget.Event, $"Adding Seperation Event:{seperationAlert.Tag1} with {seperationAlert.Tag2} at {seperationAlert.Time}");
            }
            else
                Update(seperationAlert);
        }

        public void Add(ISeperationAlert seperationAlert, bool persist)
        {
            if (Get(seperationAlert) == null)
            {
                _seperationAlerts.Add(seperationAlert);
                if (persist)
                {
                    LogHelper.Log(LoggerTarget.Event, $"Adding Seperation Event:{seperationAlert.Tag1} with {seperationAlert.Tag2} at {seperationAlert.Time}");
                }
            }
            else
                Update(seperationAlert);
        }

        public void Update(ISeperationAlert seperationAlert)
        {
            Remove(seperationAlert, false);
            Add(seperationAlert, false);
        }

        public ISeperationAlert Get(string tag1, string tag2)
        {
            return _seperationAlerts.FirstOrDefault(o => o.Tag1 == tag1 && o.Tag2 == tag2);
        }

        public ISeperationAlert Get(ISeperationAlert seperationAlert)
        {
            return _seperationAlerts.Find(o => o.Tag1 == seperationAlert.Tag1 && o.Tag2 == seperationAlert.Tag2);
        }

        public void Remove(ISeperationAlert seperationAlert)
        {
            var sepToRemove = Get(seperationAlert);
            if (sepToRemove == null) return;

            _seperationAlerts.Remove(sepToRemove);
            LogHelper.Log(LoggerTarget.Event, $"Removing Seperation Event:{seperationAlert.Tag1} with {seperationAlert.Tag2} at {seperationAlert.Time}");
        }

        public void Remove(ISeperationAlert seperationAlert, bool persist)
        {
            var sepToRemove = Get(seperationAlert);
            if (sepToRemove == null) return;

            _seperationAlerts.Remove(sepToRemove);
            if (persist)
            {
                LogHelper.Log(LoggerTarget.Event, $"Removing Seperation Event:{seperationAlert.Tag1} with {seperationAlert.Tag2} at {seperationAlert.Time}");
            }
        }

        public IEnumerable<ISeperationAlert> GetAll()
        {
            return _seperationAlerts.AsEnumerable();
        }
    }
}