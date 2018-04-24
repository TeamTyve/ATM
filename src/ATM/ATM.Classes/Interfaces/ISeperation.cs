using System;
using System.Collections.Generic;

namespace ATM.Classes.Interfaces
{
    public interface ISeperation
    {
        List<SeperationEvent> CheckSeperation(List<ITrack> list);
        
    }
}