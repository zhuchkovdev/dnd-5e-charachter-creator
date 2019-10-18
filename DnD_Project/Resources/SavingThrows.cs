using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project
{
    class SavingThrows
    {
        internal bool Strength { get; private set; }
        internal bool Dexterity { get; private set; }
        internal bool Constitution { get; private set; }
        internal bool Inteligence { get; private set; }
        internal bool Wisdom { get; private set; }
        internal bool Charisma { get; private set; }

        internal SavingThrows()
        {
            Strength = false;
            Dexterity = false;
            Constitution = false;
            Inteligence = false;
            Wisdom = false;
            Charisma = false;
        }
    }
}
