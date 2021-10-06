using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WheresThisTaken.Model
{
    interface IRound
    {
        int Score { get; set; }
        int CalculateScore();
    }
}
