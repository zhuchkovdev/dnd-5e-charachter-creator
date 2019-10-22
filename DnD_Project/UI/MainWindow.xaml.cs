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
using System.Windows.Controls.Primitives;
using DnD_Project.UI;

namespace DnD_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Authorization();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var Tab = (RadioButton)this.TryFindResource("TabButton");
            Tab.Content = "Name";
            CharTabs.Children.Add(Tab);
        }

        private void Tab_Checked(object sender, RoutedEventArgs e)
        {
            UserControl CharacterPanel = new CharSheet();
            CharPanel.Content = CharacterPanel;
        }

        public void Authorization()
        {
            this.Hide();
            var authWindow = new AuthWindow();

            if (authWindow.ShowDialog() == true)
            {
                UsernameTextBlock.Text = authWindow.CurrentUser.Login;
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
