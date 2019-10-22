using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    class LevelComponent
    {
        internal int Level { get; private set; }
        public LevelComponent(int startingLvl)
        {
            Level = startingLvl;
        }
        public delegate void LevelEventHandler(int level);
        public event LevelEventHandler LevelChanged;
    }
}
