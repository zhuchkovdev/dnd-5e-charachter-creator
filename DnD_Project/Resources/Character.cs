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
        public Stats BonusStats { get; }
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
        public void SetRace(string race)
        {

        }

    }
}