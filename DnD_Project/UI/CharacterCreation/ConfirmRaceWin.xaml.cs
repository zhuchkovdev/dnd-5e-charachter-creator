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
using DnD_Project.Enums;
using DnD_Project.UI.CharacterCreation.Races;

namespace DnD_Project.UI
{
    /// <summary>
    /// Interaction logic for ConfirmRace.xaml
    /// </summary>
    public partial class ConfirmRaceWin : Window
    {
        public ConfirmRaceWin(Race race)
        {
            InitializeComponent();
            Content.Content = new HumanUC(race);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
