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

        private void HumanButton_Click(object sender, RoutedEventArgs e)
        {
            var confirmWin = new ConfirmRaceWin(Race.Human);
            if(confirmWin.ShowDialog() == true)
            {
                this.
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
