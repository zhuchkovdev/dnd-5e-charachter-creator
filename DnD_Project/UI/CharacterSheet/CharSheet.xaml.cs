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
            InitializeComponent();

            CharacterName.Text = character.Name;
            Class.Text = character.Class;
            Race.Text = character.Race;
            Level.Text = character.Level.ToString();

            Strength.Text = character.Stats.Strength.ToString();
            Dexterity.Text = character.Stats.Dexterity.ToString();
            Constitution.Text = character.Stats.Constitution.ToString();
            Intelligence.Text = character.Stats.Intelligence.ToString();
            Wisdom.Text = character.Stats.Wisdom.ToString();
            Charisma.Text = character.Stats.Charisma.ToString();

            Perception.Text = "10";

            CurrentHP.Text = character.HP.MaxHP.ToString();
            MaxHP.Text = character.HP.MaxHP.ToString();
            TempHP.Text = "0";

            HitDiceAmount.Text = "1";
            HitDiceType.Text = character.HP.Dice;


            StrengthSaveThrow.IsChecked = character.SavingThrows.SavingThrows[Enums.Stat.Str];
            DexteritySaveThrow.IsChecked = character.SavingThrows.SavingThrows[Enums.Stat.Dex];
            ConstitutionSaveThrow.IsChecked = character.SavingThrows.SavingThrows[Enums.Stat.Con];
            IntelligenceSaveThrow.IsChecked = character.SavingThrows.SavingThrows[Enums.Stat.Int];
            WisdomSaveThrow.IsChecked = character.SavingThrows.SavingThrows[Enums.Stat.Wis];
            CharismaSaveThrow.IsChecked = character.SavingThrows.SavingThrows[Enums.Stat.Cha];

            Acrobatics.IsChecked = character.Skills[Enums.Skill.Acrobatics];
            AnimalHandling.IsChecked = character.Skills[Enums.Skill.AnimalHandling];
            Arcana.IsChecked = character.Skills[Enums.Skill.Arcana];
            Athletics.IsChecked = character.Skills[Enums.Skill.Athletics];
            Deception.IsChecked = character.Skills[Enums.Skill.Deception];
            History.IsChecked = character.Skills[Enums.Skill.History];
            Insight.IsChecked = character.Skills[Enums.Skill.Insight];
            Intimidation.IsChecked = character.Skills[Enums.Skill.Intimidation];
            Investigation.IsChecked = character.Skills[Enums.Skill.Investigation];
            Medicine.IsChecked = character.Skills[Enums.Skill.Medicine];
            Nature.IsChecked = character.Skills[Enums.Skill.Nature];
            PerceptionSkill.IsChecked = character.Skills[Enums.Skill.Perception];
            Performance.IsChecked = character.Skills[Enums.Skill.Performance];
            Persuasion.IsChecked = character.Skills[Enums.Skill.Persuasion];
            Religion.IsChecked = character.Skills[Enums.Skill.Religion];
            SleightOfHand.IsChecked = character.Skills[Enums.Skill.SleightOfHand];
            Stealth.IsChecked = character.Skills[Enums.Skill.Stealth];
            Survival.IsChecked = character.Skills[Enums.Skill.Survival];

            CharacterImage.Source = new BitmapImage(new Uri(character.ImageSource));
        }
    }
}
