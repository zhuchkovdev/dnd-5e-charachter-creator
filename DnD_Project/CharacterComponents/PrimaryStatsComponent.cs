using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    public enum StatsEnum
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    public class PrimaryStatsComponent
    {
        private Dictionary<StatsEnum, int> Stats { get; set; }
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
            StatsChanged?.Invoke(this);
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
        
        internal int GetStatModifier(StatsEnum stat)
        {
            double statScore = Stats[stat];
            return (int)Math.Floor((statScore - 10) / 2);
        }

        internal void Generate()
        {
            var rand = new Random();
            int GenStat()
            {
                int[] throws = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    throws[j] = rand.Next(1, 7);
                }
                Array.Sort(throws);
                return (throws[1] + throws[2] + throws[3]);
            }

            for (StatsEnum i = StatsEnum.Strength; i <= StatsEnum.Charisma; i++)
            {
                Stats[i] = GenStat();
            }

            StatsChanged?.Invoke(this);
        }

        public void UpdateStats(RaceEnum race)
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
            if ((race == RaceEnum.HighElf) || (race == RaceEnum.WoodElf) || (race == RaceEnum.DarkElf))
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
                if(race == RaceEnum.DarkElf)
                {
                    Charisma += 1;
                }
            }
            if ((race == RaceEnum.LightfootHalfling) || (race == RaceEnum.StoutHalfling))
            {
                Dexterity += 2;
                if(race == RaceEnum.LightfootHalfling)
                {
                    Charisma += 1;
                }
                if(race == RaceEnum.StoutHalfling)
                {
                    Constitution += 1;
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
            if (race == RaceEnum.Dragonborn)
            {
                Strength += 2;
                Charisma += 1;
            }
            if ((race == RaceEnum.ForestGnome) || (race == RaceEnum.RockGnome))
            {
                Intelligence += 2;
                if(race == RaceEnum.ForestGnome)
                {
                    Dexterity += 1;
                }
                if(race == RaceEnum.RockGnome)
                {
                    Constitution += 1;
                }
            }
            if (race == RaceEnum.HalfElf)
            {
                Charisma += 2;
                //Choice stat
            }
            if (race == RaceEnum.HalfOrk)
            {
                Strength += 2;
                Constitution += 1;
            }
            if (race == RaceEnum.Tiefling)
            {
                Intelligence += 1;
                Charisma += 2;
            }
        }

        public delegate void PrimaryStatsEventHandler(PrimaryStatsComponent newStats);
        public event PrimaryStatsEventHandler StatsChanged;
    }
}
