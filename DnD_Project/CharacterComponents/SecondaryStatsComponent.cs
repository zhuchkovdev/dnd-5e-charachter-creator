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
        //internal void CalculatePerception(Dictionary<StatsEnum, int> stats)
        //{
        //}

        internal void CalculateInitiative(PrimaryStatsComponent stats)
        {
            Initiative = stats.GetStatModifier(StatsEnum.Dexterity);
        }

        //Event from race + bonus from monk class
        internal void CalculateSpeed()
        {

        }

        //Inventory and armor will be added soon(c)
        internal void ClaculateArmorClass()
        {

        }
    }
}
