using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project
{
    enum Dice 
    {
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100
    }
    class HitPoints
    {
        int CurrentHP { get; set; }
        int TemporaryHP { get; set; }
        int MaximumHP { get; set; }
        Dice HitDice { get; set; }
        int HitDiceAmount { get; set; }
    }
}
