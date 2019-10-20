using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project
{
    class Stats
    {
        internal int Strength { get; private set; }
        internal int Dexterity { get; private set; }
        internal int Constitution { get; private set; }
        internal int Inteligence { get; private set; }
        internal int Wisdom { get; private set; }
        internal int Charisma { get; private set; }


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

            Strength = GenStat();
            Dexterity = GenStat();
            Constitution = GenStat();
            Inteligence = GenStat();
            Wisdom = GenStat();
            Charisma = GenStat();
        }

        public static Stats operator +(Stats first, Stats second)
        {
            return new Stats
            {
                Strength = first.Strength + second.Strength,
                Dexterity = first.Dexterity + second.Dexterity,
                Constitution = first.Constitution + second.Constitution,
                Inteligence = first.Inteligence + second.Inteligence,
                Wisdom = first.Wisdom + second.Wisdom,
                Charisma = first.Charisma + second.Charisma
            };
        }
    }
}
