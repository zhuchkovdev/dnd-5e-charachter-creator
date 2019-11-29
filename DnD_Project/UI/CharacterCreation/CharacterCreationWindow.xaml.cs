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
using System.Windows.Shapes;
using DnD_Project.CharacterModule;
using DnD_Project.UI.CharacterCreation;

namespace DnD_Project.UI
{
    /// <summary>
    /// Interaction logic for CharacterCreationWindow.xaml
    /// </summary>
    public partial class CharacterCreationWindow : Window
    {
        public Character character;
        public CharacterCreationWindow()
        {
            InitializeComponent();
            character = new Character();
            ChooseRace();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChooseRace()
        {
            RaceChoice raceChoice = new RaceChoice();
            raceChoice.RaceSelected += ChooseClass;
            CreationStage.Content = raceChoice;
        }

        private void ChooseClass()
        {
            ClassChoice classChoice = new ClassChoice();
            classChoice.ClassSelected += ChooseAbilities;
            CreationStage.Content = classChoice;
        }
        private void ChooseAbilities()
        {
            AbilitiesChoice abilitiesChoice = new AbilitiesChoice();
            CreationStage.Content = abilitiesChoice;
        }
    }
}
