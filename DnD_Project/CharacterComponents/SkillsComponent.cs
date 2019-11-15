using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum SkillsEnum
    {
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    }
    public class SkillsComponent
    {
        private Dictionary<SkillsEnum, bool> _skills;

        //DeleteRandomLater
        public SkillsComponent()
        {
            var rand = new Random();
            _skills = new Dictionary<SkillsEnum, bool>(18);
            for(var i = SkillsEnum.Acrobatics; i <= SkillsEnum.Survival; i++)
            {
                if(rand.Next(0,2) == 0)
                {
                    _skills[i] = false;
                }
                else
                {
                    _skills[i] = true;
                }
            }
        }
        internal void SetSkill(SkillsEnum skill, bool value)
        {
            _skills[skill] = value;
        }
        internal bool GetSkill(SkillsEnum skill)
        {
            return _skills[skill];
        }
        internal int GetSkillModifier(PrimaryStatsComponent stats, SkillsEnum skill, int proficiencyBonus)
        {
            int modifier = 0;
            if ((skill == SkillsEnum.Acrobatics) || (skill == SkillsEnum.SleightOfHand))
            {
                modifier = stats.GetStatModifier(StatsEnum.Dexterity);
            }
            else if ((skill == SkillsEnum.Arcana) ||
                (skill == SkillsEnum.History) ||
                (skill == SkillsEnum.Investigation) ||
                (skill == SkillsEnum.Nature) ||
                (skill == SkillsEnum.Religion))
            {
                modifier = stats.GetStatModifier(StatsEnum.Intelligence);
            }
            else if (skill == SkillsEnum.Athletics)
            {

                modifier = stats.GetStatModifier(StatsEnum.Strength);
            }
            else if ((skill == SkillsEnum.Deception) ||
                (skill == SkillsEnum.Intimidation) ||
                (skill == SkillsEnum.Performance) ||
                (skill == SkillsEnum.Persuasion))
            {
                modifier = stats.GetStatModifier(StatsEnum.Charisma);
            }
            else
            {
                modifier = stats.GetStatModifier(StatsEnum.Wisdom);
            }

            if (_skills[skill])
            {
                return modifier + proficiencyBonus;
            }
            return modifier;
        }
    }
}
