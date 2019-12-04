using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Project.Enums;

namespace DnD_Project.CharacterModule
{
    class RaceComponent
    {
        public string Race { get; set; }
        public event Action<RaceEnum> RaceSet;

        public void SetRace(RaceEnum race)
        {
            Race = Enum.GetName(typeof(RaceEnum), race);
            RaceSet?.Invoke(race);
        }
    }
}
