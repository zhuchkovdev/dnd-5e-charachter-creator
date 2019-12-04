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

namespace DnD_Project.UI.CharacterCreation
{
    /// <summary>
    /// Interaction logic for ConfirmWin.xaml
    /// </summary>
    public partial class ConfirmWin : Window
    {

        public ConfirmWin(UserControl userControl)
        {
            InitializeComponent();
            UC.Content = userControl;
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
