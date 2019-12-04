using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Project.Enums;

namespace DnD_Project.CharacterModule
{
    public class CharacterData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string ImageSource { get; set; }
        public bool[] Skills { get; set; }
        public bool[] SavingThrows { get; set; }
        public int[] Stats { get; set; }
        public int MaxHP { get; set; }
        public string DiceHP { get; set; }

        public  CharacterData()
        {

        }
        public CharacterData(Character character)
        {
            ID = character.ID;
            Name = character.Name;
            Level = character.Level;
            Race = character.Race;
            Class = character.Class;
            ImageSource = character.ImageSource;
            MaxHP = character.HP.MaxHP;
            DiceHP = character.HP.Dice;

            Skills = new bool[18];
            SavingThrows = new bool[6];
            Stats = new int[6];

            for(var i = Skill.Acrobatics; i <= Skill.Survival; i++)
            {
                Skills[(int)i] = character.Skills[i];
            }
            for (var i = Stat.Str; i <= Stat.Cha; i++)
            {
                SavingThrows[(int)i] = character.SavingThrows.SavingThrows[i];
            }
            for (var i = StatsEnum.Strength; i <= StatsEnum.Wisdom; i++)
            {
                Stats[(int)i] = character.Stats.Stats[i];
            }
        }
    }
}
