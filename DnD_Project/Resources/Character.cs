using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DnD_Project
{
    enum Property
    {
        ID,
        Name,
        Level,
        Race,
        Background,
        Alignment,
        ProficienceBonus,
        Perception,
        Initiative,
        Speed,
        ArmorClass
    }


    class Character
    {
        Dictionary<Property, string> Props;
        public Stats BaseStats { get; }
        public Stats ActualStats { get; }
        public SavingThrows SavingThrows { get; private set; }
        public HitPoints HitPoints { get; }
        public DeathSaves DeathSaves { get; private set; }
        public List<string> LanguagesAndProficiences { get; private set; }
        public List<Trait> Traits { get; private set; }
        public Character()
        {

        }
        
        public void SetProperty(Property key)
        {
            switch(key)
            {
                
            }

        }
        public void SetRace(string charRace)
        {
            switch(charRace)
            {
                case "Human":
                    break;
                case "Dwarf":
                    break;
                case "Elf":
                    break;
                case "Halfling":
                    break;
                case "Dragonborn":
                    break;
                case "Gnome":
                    break;
                case "Half-Elf":
                    break;
                case "Half-Ork":
                    break;
                case "Tiefling":
                    break;
            }
        }
        public void SetClass(string charClass)
        {
            switch (charClass)
            {
                case "Baarbarian":
                    break;
                case "Bard":
                    break;
                case "Cleric":
                    break;
                case "Druid":
                    break;
                case "Fighter":
                    break;
                case "Monk":
                    break;
                case "Paladin":
                    break;
                case "Ranger":
                    break;
                case "Rogue":
                    break;
                case "Sorcerer":
                    break;
                case "Warlock":
                    break;
                case "Wisard":
                    break;
            }
        }

    }
}