using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DnD_Project.CharacterModule;

namespace DnD_Project
{
    /// <summary>
    /// Логика взаимодействия для CharSheet.xaml
    /// </summary>
    public partial class CharSheet : UserControl
    {
        private Character _character { get; set; }
        public CharSheet(Character character)
        {
            _character = character;
            InitializeComponent();
            CharacterName.Text = _character.Name.ToString();
            Race.Text = _character.Race.ToString();
            Class.Text = _character.Class.ToString();
            Level.Text = _character.Level.ToString();
            Alignment.Text = _character.Alignment.ToString();
            Speed.Text = _character.SecondaryStats.Speed.ToString();
            Initiative.Text = _character.SecondaryStats.Initiative.ToString();
            CurrentHitDice.Text = _character.HP.HitDiceAmount.ToString();
            MaxHitDice.Text = _character.HP.HitDiceAmount.ToString();
            UpdateStats();
            UpdateSavingThrows();
            UpdateSkills();
            UpdateHP();

        }
        public void UpdateHP()
        {
            CurrentHP.Text = _character.HP.CurrentHP.ToString();
            MaxHP.Text = _character.HP.MaximumHP.ToString();
            TempHP.Text = _character.HP.TemporaryHP.ToString();
        }
        
        private void UpdateStats()
        {
            Strength.Text = _character.PrimaryStats.Strength.ToString();
            Dexterity.Text = _character.PrimaryStats.Dexterity.ToString();
            Constitution.Text = _character.PrimaryStats.Constitution.ToString();
            Intelligence.Text = _character.PrimaryStats.Intelligence.ToString();
            Wisdom.Text = _character.PrimaryStats.Wisdom.ToString();
            Charisma.Text = _character.PrimaryStats.Charisma.ToString();
            Perception.Text = _character.SecondaryStats.Perception.ToString();
        }

        private void UpdateSkills()
        {
            AcrobaticsSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Acrobatics);
            ArcanaSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Arcana);
            AnimalHandlingSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.AnimalHandling);
            AthleticsSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Athletics);
            DeceptionSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Deception);
            HistorySkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.History);
            InsightSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Insight);
            IntimidationSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Intimidation);
            InvestigationSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Investigation);
            MedicineSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Medicine);
            NatureSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Nature);
            PerceptionSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Perception);
            PerformanceSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Performance);
            PersuasionSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Persuasion);
            ReligionSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Religion);
            SleightOfHandSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.SleightOfHand);
            StealthSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Stealth);
            SurvivalSkill.IsChecked = _character.Skills.GetSkill(CharacterComponents.SkillsEnum.Survival);
        }

        private void UpdateSavingThrows()
        {
            StrengthSaveThrow.IsChecked = _character.SavingThrows.GetSavingThrow(CharacterComponents.StatsEnum.Strength);
            DexteritySaveThrow.IsChecked = _character.SavingThrows.GetSavingThrow(CharacterComponents.StatsEnum.Dexterity);
            ConstitutionSaveThrow.IsChecked = _character.SavingThrows.GetSavingThrow(CharacterComponents.StatsEnum.Constitution);
            IntelligenceSaveThrow.IsChecked = _character.SavingThrows.GetSavingThrow(CharacterComponents.StatsEnum.Intelligence);
            WisdomSaveThrow.IsChecked = _character.SavingThrows.GetSavingThrow(CharacterComponents.StatsEnum.Wisdom);
            WisdomSaveThrow.IsChecked = _character.SavingThrows.GetSavingThrow(CharacterComponents.StatsEnum.Charisma);

            int fails = _character.DeathSaves.Fails;
            if(fails > 0)
            {
                FirstDeathThrow.IsChecked = true;
            }
            if(fails == 2)
            {
                SecondDeathThrow.IsChecked = true;
            }

            int saves = _character.DeathSaves.Successes;
            if (saves > 0)
            {
                FirstLifeThrow.IsChecked = true;
            }
            if (saves == 2)
            {
                SecondLifeThrow.IsChecked = true;
            }
        }

        private void GenerateStats_Click(object sender, RoutedEventArgs e)
        {
            _character.PrimaryStats.Generate();
            UpdateStats();
        }
    }
}
