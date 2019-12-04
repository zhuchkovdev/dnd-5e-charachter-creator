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
using DnD_Project.UI.CharacterCreation.UC;

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

        private void ButtonClick(object sender, RoutedEventArgs e, RaceEnum race)
        {
            UserControl raceUC = new ChoiceUC(race);
            var confirmWin = new ConfirmWin(raceUC);
            if (confirmWin.ShowDialog() == true)
            {
                var parentWindow = (CharacterCreationWindow)Window.GetWindow(this);
                parentWindow.character.SetRace(race);
                parentWindow.character.ImageSource = String.Format(@"D:\Projects\DnD_Project\DnD_Project\{0}Icon.png", Enum.GetName(typeof(RaceEnum), race));
                RaceSelected?.Invoke();
            }
        }
        
        private void HumanButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e, RaceEnum.Human);
        }

        private void HillDwarfButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e, RaceEnum.HillDwarf);
        }

        private void MountainDwarfButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e, RaceEnum.MountainDwarf);
        }

        private void HighElfButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e, RaceEnum.HighElf);
        }

        private void WoodElfButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e, RaceEnum.WoodElf);
        }

        private void DrowButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e, RaceEnum.Drow);
        }
    }
}
