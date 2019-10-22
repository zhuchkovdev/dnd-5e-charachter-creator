using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum Dice
    {
        None = 0,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100
    }
    class HitPointsComponent
    {
        private int BaseHP { get; set; }
        internal int MaximumHP { get; private set; }
        internal int CurrentHP { get; private set; }
        internal int TemporaryHP { get; set; }
        internal Dice HitDice { get; private set; }
        internal int HitDiceAmount { get; private set; }

        public HitPointsComponent(int level)
        {
            HitDiceAmount = level;
            TemporaryHP = 0;
            HitDice = Dice.None; //???
        }

        internal void CalculateHitDice(ClassEnum @class)
        {
            if (@class == ClassEnum.Barbarian) { HitDice = Dice.D12; }
            else if ((@class == ClassEnum.Fighter) || (@class == ClassEnum.Paladin) || (@class == ClassEnum.Ranger)) { HitDice = Dice.D10; }
            else if ((@class == ClassEnum.Sorcerer) || (@class == ClassEnum.Wisard)) { HitDice = Dice.D6; }
            else { HitDice = Dice.D8; }
        }

        internal void CalculateHP(PrimaryStatsComponent stats)
        {
            MaximumHP = (int)HitDice + stats.GetStatModifier(StatsEnum.Constitution);
            CurrentHP = MaximumHP;
        }
    }
}
