using System;
using System.Collections.Generic;
using System.Text;
using DnD_Project.CharacterComponents;

namespace DnD_Project.CharacterModule
{
    class Character
    {
        public NameComponent Name { get; }
        private IDComponent ID { get; }
        public PrimaryStatsComponent PrimaryStats { get; }
        public SecondaryStatsComponent SecondaryStats { get; }
        private LevelComponent Level { get; }
        private RaceComponent Race { get; }
        private ClassComponent Class { get; }
        public HitPointsComponent HP { get; }
        public SavingThrowsComponent SavingThrows { get; }
        public DeathSavesComponent DeathSaves { get; }
        private AlignmentComponent Alignment { get; }

        public Character()
        {
            Name = new NameComponent();
            ID = new IDComponent();
            PrimaryStats = new PrimaryStatsComponent();
            SecondaryStats = new SecondaryStatsComponent();
            Level = new LevelComponent(startingLvl:1);
            Race = new RaceComponent();
            Class = new ClassComponent();
            HP = new HitPointsComponent(Level.GetLevel());
            SavingThrows = new SavingThrowsComponent();
            DeathSaves = new DeathSavesComponent();
            Alignment = new AlignmentComponent();

            //Add Race and Class EventHandlers
            PrimaryStats.StatsChanged += SecondaryStats.CalculateInitiative;
            PrimaryStats.StatsChanged += HP.CalculateHP;
            Level.LevelChanged += SecondaryStats.CalculateProficiencyBonus;
            Class.ClassChanged += HP.CalculateHitDice;
            Class.ClassChanged += HP.CalculateHP;
            Race.RaceChanged += SecondaryStats.CalculateSpeed;
        }
    }
}