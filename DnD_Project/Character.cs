using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DnDLibrary
{
    class Stats
    {
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        int Inteligence { get; set; }
        int Wisdom { get; set; }
        int Charisma { get; set; }

        public Stats()
        {

        }
    }
    class Character
    {
        public Stats BaseStats = new Stats();

        public Character()
        {

        }
        public void GenBaseStats()
        {
            var rand = new Random();
            for(int i = 0; i < 6; i++)
            {
                //According to DnD rules to get a stat you tax max of 4 D6 rolls
                int[] throws = new int[4];
                for(int j = 0; j < 4; j++)
                {
                    throws[j] = rand.Next(1, 7);
                }
                Array.Sort(throws);
            }
        }
    }
}