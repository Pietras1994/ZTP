using System.Collections.Generic;

namespace App1.Classes
{
    public interface ISignals
    {
        List<(string dt, bool sg)> xx(List<(string dt, double pr)> D);
        string[] dates { get; set; }
        bool[] signals { get; set; }        
    }
}
