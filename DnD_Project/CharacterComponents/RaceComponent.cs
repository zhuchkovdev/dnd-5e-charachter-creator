using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum RaceEnum
    {
        Dwarf, 
        Elf, 
        Halfling, 
        Human, 
        Dragonborn, 
        Gnome, 
        HalfElf, 
        HalfOrk, 
        Tiefling
    }
    class RaceComponent
    {
        internal string Race { get; private set; }

        internal void SetRace(RaceEnum race)
        {
            switch(race)
            {
                case RaceEnum.Dwarf:
                    Race = "Dwarf";
                    RaceChanged?.Invoke(RaceEnum.Dwarf);
                    break;
                case RaceEnum.Elf:
                    Race = "Elf";
                    RaceChanged?.Invoke(RaceEnum.Elf);
                    break;
                case RaceEnum.Halfling:
                    Race = "Halfling";
                    RaceChanged?.Invoke(RaceEnum.Halfling);
                    break;
                case RaceEnum.Human:
                    Race = "Human";
                    RaceChanged?.Invoke(RaceEnum.Human);
                    break;
                case RaceEnum.Dragonborn:
                    Race = "Dragonborn";
                    RaceChanged?.Invoke(RaceEnum.Dragonborn);
                    break;
                case RaceEnum.Gnome:
                    Race = "Gnome";
                    RaceChanged?.Invoke(RaceEnum.Gnome);
                    break;
                case RaceEnum.HalfElf:
                    Race = "HalfElf";
                    RaceChanged?.Invoke(RaceEnum.HalfElf);
                    break;
                case RaceEnum.HalfOrk:
                    Race = "HalfOrk";
                    RaceChanged?.Invoke(RaceEnum.HalfOrk);
                    break;
                case RaceEnum.Tiefling:
                    Race = "Tiefling";
                    RaceChanged?.Invoke(RaceEnum.Tiefling);
                    break;
            }
        }

        public delegate void RaceEventHandler(RaceEnum race);
        public event RaceEventHandler RaceChanged;
    }
}   
