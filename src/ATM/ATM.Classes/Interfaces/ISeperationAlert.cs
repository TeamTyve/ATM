using System;

namespace ATM.Classes.Domain
{
    public interface ISeperationAlert
    {
        string Tag1 { get; set; }
        string Tag2 { get; set; }
        DateTime Time { get; set; }
    }
}