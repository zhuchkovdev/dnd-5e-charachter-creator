using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum StatsEnum
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    class PrimaryStatsComponent
    {
        private Dictionary<StatsEnum, int> Stats { get; set; }
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
            int GenStat()
            {
                var rand = new Random();
                int[] throws = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    throws[j] = rand.Next(1, 7);
                }
                Array.Sort(throws);
                return (throws[1] + throws[2] + throws[3]);
            }

            for (StatsEnum i = StatsEnum.Strength; i <= StatsEnum.Wisdom; i++)
            {
                Stats[i] = GenStat();
            }

            StatsChanged?.Invoke(this);
        }

        public delegate void PrimaryStatsEventHandler(PrimaryStatsComponent newStats);
        public event PrimaryStatsEventHandler StatsChanged;
    }
}
