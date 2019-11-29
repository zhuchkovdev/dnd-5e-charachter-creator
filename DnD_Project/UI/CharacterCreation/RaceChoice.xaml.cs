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
using DnD_Project.Enums;
using DnD_Project.UI.CharacterCreation.Races;

namespace DnD_Project.UI.CharacterCreation
{
    /// <summary>
    /// Interaction logic for RaceChoice.xaml
    /// </summary>
    public partial class RaceChoice : UserControl
    {
        public RaceChoice()
        {
            InitializeComponent();
        }

        public delegate void ChoiceHanldler();
        public event ChoiceHanldler RaceSelected;

        private void HumanButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl humanUC = new HumanUC(Race.Human);
            var confirmWin = new ConfirmWin(humanUC);
            if(confirmWin.ShowDialog() == true)
            {
                var parentWindow = (CharacterCreationWindow)Window.GetWindow(this);
                parentWindow.character.Race.SetRace(CharacterComponents.RaceEnum.Human);
                RaceSelected?.Invoke();
            }
        }

        private void HillDwarfButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MountainDwarfButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HighElfButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WoodElfButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DrowButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
