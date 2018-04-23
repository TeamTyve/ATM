using System.Collections.Generic;
using ATM.Classes.Domain;

namespace ATM.Classes.Interfaces
{
    public interface ISeperationAlertRepository
    {
        void Add(ISeperationAlert seperationAlert);
        ISeperationAlert Get(ISeperationAlert seperationAlert);
        ISeperationAlert Get(string tag1, string tag2);
        void Remove(ISeperationAlert seperationAlert);
        IEnumerable<ISeperationAlert> GetAll();

    }
}