using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum RaceEnum
    {
        HillDwarf,
        MountainDwarf,
        HighElf,
        WoodElf,
        DarkElf,
        LightfootHalfling,
        StoutHalfling,
        Human, 
        Dragonborn, 
        ForestGnome,
        RockGnome,
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
                case RaceEnum.HillDwarf:
                    Race = "Hill Dwarf";
                    RaceChanged?.Invoke(RaceEnum.HillDwarf);
                    break;
                case RaceEnum.MountainDwarf:
                    Race = "Mountain Dwarf";
                    RaceChanged?.Invoke(RaceEnum.MountainDwarf);
                    break;
                case RaceEnum.HighElf:
                    Race = "High Elf";
                    RaceChanged?.Invoke(RaceEnum.HighElf);
                    break;
                case RaceEnum.WoodElf:
                    Race = "Wood Elf";
                    RaceChanged?.Invoke(RaceEnum.WoodElf);
                    break;
                case RaceEnum.DarkElf:
                    Race = "Drow";
                    RaceChanged?.Invoke(RaceEnum.DarkElf);
                    break;
                case RaceEnum.LightfootHalfling:
                    Race = "Lightfoot Halfling";
                    RaceChanged?.Invoke(RaceEnum.LightfootHalfling);
                    break;
                case RaceEnum.StoutHalfling:
                    Race = "Stout Halfling";
                    RaceChanged?.Invoke(RaceEnum.StoutHalfling);
                    break;
                case RaceEnum.Human:
                    Race = "Human";
                    RaceChanged?.Invoke(RaceEnum.Human);
                    break;
                case RaceEnum.Dragonborn:
                    Race = "Dragonborn";
                    RaceChanged?.Invoke(RaceEnum.Dragonborn);
                    break;
                case RaceEnum.ForestGnome:
                    Race = "Forest Gnome";
                    RaceChanged?.Invoke(RaceEnum.ForestGnome);
                    break;
                case RaceEnum.RockGnome:
                    Race = "Rock Gnome";
                    RaceChanged?.Invoke(RaceEnum.RockGnome);
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
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Race))
            {
                return base.ToString();
            }
            return Race;
        }

        public delegate void RaceEventHandler(RaceEnum race);
        public event RaceEventHandler RaceChanged;
    }
}   
