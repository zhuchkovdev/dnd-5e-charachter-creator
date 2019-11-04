using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    class SecondaryStatsComponent
    {
        internal int ProficiencyBonus { get; private set; }
        internal int Perception { get; private set; }
        internal int Initiative { get; private set; }
        internal int Speed { get; private set; }
        internal int ArmorClass { get; private set; }

        internal void CalculateProficiencyBonus(int level)
        {
            if(level <= 4) { ProficiencyBonus = 2; }
            else if(level <= 8) { ProficiencyBonus = 3; }
            else if(level <= 12) { ProficiencyBonus = 4; }
            else if(level <= 16) { ProficiencyBonus = 5; }
            else { ProficiencyBonus = 6; }
        }

        //10 + PerceptionBonus(Skills)
        //event in Skills
        //internal void CalculatePerception(SkillsComponent skills)
        //{
        //}

        internal void CalculateInitiative(PrimaryStatsComponent stats)
        {
            Initiative = stats.GetStatModifier(StatsEnum.Dexterity);
        }

        internal void CalculateSpeed(RaceEnum race)
        {
            if ((race == RaceEnum.HillDwarf) ||
                (race == RaceEnum.MountainDwarf) ||
                (race == RaceEnum.LightfootHalfling) ||
                (race == RaceEnum.StoutHalfling) ||
                (race == RaceEnum.ForestGnome) || 
                (race == RaceEnum.RockGnome))
            {
                Speed = 25;
            }
            if ((race == RaceEnum.HighElf) ||
                (race == RaceEnum.DarkElf) ||
                (race == RaceEnum.Human) ||
                (race == RaceEnum.Dragonborn) ||
                (race == RaceEnum.HalfElf) ||
                (race == RaceEnum.HalfOrk) ||
                (race == RaceEnum.Tiefling))
            {
                Speed = 30;
            }
            if ((race == RaceEnum.WoodElf))
            {
                Speed = 35;
            }
        }

        //Inventory and armor will be added soon(c)
        internal void ClaculateArmorClass()
        {

        }
    }
}
