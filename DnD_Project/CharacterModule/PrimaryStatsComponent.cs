using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Project.Enums;

namespace DnD_Project.CharacterComponents
{
    public class PrimaryStatsComponent
    {
        public Dictionary<StatsEnum, int> Stats { get; set; }
        public PrimaryStatsComponent()
        {
            Stats = new Dictionary<StatsEnum, int>();
            for (var i = StatsEnum.Strength; i <= StatsEnum.Charisma; i++)
            {
                Stats.Add(i, 0);
            }
        }
        private void SetStat(StatsEnum stat, int value)
        {
            if (value < 1)
            {
                Stats[stat] = 1;
            }
            else if (value > 20)
            {
                Stats[stat] = 20;
            }
            else
            {
                Stats[stat] = value;
            }
        }
        
        internal int Strength
        {
            get { return Stats[StatsEnum.Strength]; }
            set { SetStat(StatsEnum.Strength, value); }
        }
        internal int Dexterity
        {
            get { return Stats[StatsEnum.Dexterity]; }
            set { SetStat(StatsEnum.Dexterity, value); }
        }
        internal int Constitution
        {
            get { return Stats[StatsEnum.Constitution]; }
            set { SetStat(StatsEnum.Constitution, value); }
        }
        internal int Intelligence
        {
            get { return Stats[StatsEnum.Intelligence]; }
            set { SetStat(StatsEnum.Intelligence, value); }
        }
        internal int Wisdom
        {
            get { return Stats[StatsEnum.Wisdom]; }
            set { SetStat(StatsEnum.Wisdom, value); }
        }
        internal int Charisma
        {
            get { return Stats[StatsEnum.Charisma]; }
            set { SetStat(StatsEnum.Charisma, value); }
        }

        public void UpdateRaceStats(RaceEnum race)
        {
            if ((race == RaceEnum.HillDwarf) || (race == RaceEnum.MountainDwarf))
            {
                Constitution += 2;
                if (race == RaceEnum.HillDwarf)
                {
                    Strength += 2;
                }
                if (race == RaceEnum.MountainDwarf)
                {
                    Wisdom += 1;
                }
            }
            if ((race == RaceEnum.HighElf) || (race == RaceEnum.WoodElf) || (race == RaceEnum.Drow))
            {
                Dexterity += 2;
                if(race == RaceEnum.HighElf)
                {
                    Intelligence += 1;
                }
                if(race == RaceEnum.WoodElf)
                {
                    Wisdom += 1;
                }
                if(race == RaceEnum.Drow)
                {
                    Charisma += 1;
                }
            }
            if (race == RaceEnum.Human)
            {
                Strength += 1;
                Dexterity += 1;
                Constitution += 1;
                Intelligence += 1;
                Wisdom += 1;
                Charisma += 1;
            }
        }

        public void AddStats(int[] stats)
        {
            for (var i = StatsEnum.Strength; i <= StatsEnum.Charisma; i++)
            {
                Stats[i] += stats[(int)i];
            }
        }
    }
}
