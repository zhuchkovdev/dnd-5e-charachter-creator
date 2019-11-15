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

namespace DnD_Project.UI
{
    /// <summary>
    /// Interaction logic for CharacterNameWindow.xaml
    /// </summary>
    public partial class CharacterNameWindow : Window
    {
        public string CharacterName { get; private set; }
        public CharacterNameWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterName = NameTextBox.Text;
            this.DialogResult = true;
        }
    }
}
