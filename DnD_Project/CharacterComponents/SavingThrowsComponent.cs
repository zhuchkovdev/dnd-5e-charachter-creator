using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    public class SavingThrowsComponent
    {
        private Dictionary<StatsEnum, bool> _savingThrows;


        //DeleteRandomLater
        public SavingThrowsComponent()
        {
            var rand = new Random();

            _savingThrows = new Dictionary<StatsEnum, bool>(6);
            for(var i = StatsEnum.Strength; i <= StatsEnum.Charisma; i++)
            {
                if (rand.Next(0, 2) == 0)
                {
                    _savingThrows[i] = false;
                }
                else
                {
                    _savingThrows[i] = true;
                }
            }
        }
        internal void SetSavingThrow(StatsEnum stat, bool value)
        {
            _savingThrows[stat] = value;
        }
        internal bool GetSavingThrow(StatsEnum stat)
        {
            return _savingThrows[stat];
        }
        internal int GetSavingThrowModifier(StatsEnum stat, int statModifier, int proficiencyBonus)
        {
            if(_savingThrows[stat])
            {
                return statModifier + proficiencyBonus;
            }
            else
            {
                return statModifier;
            }   
        }
    }
}
