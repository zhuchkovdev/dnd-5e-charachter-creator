using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    public class LevelComponent
    {
        private int Level { get; set; }
        public LevelComponent(int startingLvl)
        {
            Level = startingLvl;
        }
        public override string ToString()
        {
            return Level.ToString();
        }
        public int GetLevel()
        {
            return Level;
        }
        public delegate void LevelEventHandler(int level);
        public event LevelEventHandler LevelChanged;
    }
}
