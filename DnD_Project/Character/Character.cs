using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DnD_Project.CharacterComponents;

namespace DnD_Project.Character
{
    class Character
    {
        public PrimaryStatsComponent PrimaryStats { get; }
        public SecondaryStatsComponent SecondaryStats { get; }
        private LevelComponent _level;
        public int Level
        {
            get { return _level.Level; }
        }
        private RaceComponent _race;
        public string Race
        {
            get { return _race.Race; }
        }
        private ClassComponent _class;
        public string Class
        {
            get { return _class.Class; }
        }
        public HitPointsComponent HP { get; }
        public SavingThrowsComponent SavingThrows { get; }
        public DeathSavesComponent DeathSaves { get; }

        public Character()
        {
            PrimaryStats = new PrimaryStatsComponent();
            SecondaryStats = new SecondaryStatsComponent();
            _level = new LevelComponent(startingLvl:1);
            _race = new RaceComponent();
            _class = new ClassComponent();
            HP = new HitPointsComponent(Level);
            SavingThrows = new SavingThrowsComponent();
            DeathSaves = new DeathSavesComponent();            

            //Add Race and Class EventHandlers
            PrimaryStats.StatsChanged += SecondaryStats.CalculateInitiative;
            PrimaryStats.StatsChanged += HP.CalculateHP;
            _level.LevelChanged += SecondaryStats.CalculateProficiencyBonus;
            _class.ClassChanged += HP.CalculateHitDice;
        }
    }
}