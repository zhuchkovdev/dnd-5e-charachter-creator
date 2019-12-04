using System;
using System.Collections.Generic;
using System.Text;
using DnD_Project.CharacterComponents;
using DnD_Project.Enums;

namespace DnD_Project.CharacterModule
{
    public class Character
    {
        private RaceComponent _race;
        private ClassComponent _class;
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; private set; }
        public string Race
        {
            get => _race.Race;
            set
            {
                _race.Race = value;
            }
        }
        public string Class
        {
            get => _class.Class;
            set
            {
                _class.Class = value;
            }
        }
        public string ImageSource { get; set; }
        public Dictionary<Skill, bool> Skills { get; private set; }
        public SavingThrowsComponent SavingThrows { get; set; }
        public PrimaryStatsComponent Stats { get; }
        public HitPointsComponent HP { get; }

        public Character()
        {
            _race = new RaceComponent();
            _class = new ClassComponent();
            Stats = new PrimaryStatsComponent();
            HP = new HitPointsComponent();
            SavingThrows = new SavingThrowsComponent();
            Level = 1;
            GenerateSkills();


            _race.RaceSet += Stats.UpdateRaceStats;
            _class.ClassSet += SavingThrows.UpdateClassSavingThrows;
            _class.ClassSet += HP.UpdateClassHP;
        }

        public Character(CharacterData data)
        {
            _race = new RaceComponent();
            _class = new ClassComponent();
            HP = new HitPointsComponent();
            Skills = new Dictionary<Skill, bool>();
            SavingThrows = new SavingThrowsComponent();
            Stats = new PrimaryStatsComponent();

            Name = data.Name;
            Race = data.Race;
            Class = data.Class;
            ImageSource = data.ImageSource;
            HP.MaxHP = data.MaxHP;
            HP.Dice = data.DiceHP;

            for(var i = Skill.Acrobatics; i <= Skill.Survival; i++)
            {
                Skills.Add(i, data.Skills[(int)i]);
            }
            for (var i = Stat.Str; i <= Stat.Cha; i++)
            {
                SavingThrows.SavingThrows[i] = data.SavingThrows[(int)i];
            }
            for (var i = StatsEnum.Strength; i <= StatsEnum.Charisma; i++)
            {
                Stats.Stats[i] = data.Stats[(int)i];
            }
        }

        public void SetClass(Class @class)
        {
            _class.SetClass(@class);
        }

        public void SetRace(RaceEnum race)
        {
            _race.SetRace(race);
        }

        private void GenerateSkills()
        {
            InitSkills();
            Random rand = new Random();
            for (var i = Skill.Acrobatics; i <= Skill.Survival; i++)
            {
                rand.Next();
                if (rand.Next(0, 2) == 0)
                {
                    Skills[i] = true;
                }
            }
        }

        private void InitSkills()
        {
            Skills = new Dictionary<Skill, bool>();
            for (var i = Skill.Acrobatics; i <= Skill.Survival; i++)
            {
                Skills.Add(i, false);
            }
        }
    }
}