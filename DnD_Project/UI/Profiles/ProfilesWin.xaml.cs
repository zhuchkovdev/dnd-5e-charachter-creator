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
using DnD_Project.DAL;

namespace DnD_Project.UI.Profiles
{
    /// <summary>
    /// Interaction logic for ProfilesWin.xaml
    /// </summary>
    public partial class ProfilesWin : Window
    {
        List<Profile> profiles;
        public Profile currentProfile;
        public ProfilesWin(DBController db)
        {
            InitializeComponent();

            profiles = db.GetProfiles();
            foreach(var profileName in profiles)
            {
                var profileButton = new Button();
                profileButton.Content = profileName;
                profileButton.Margin = new Thickness(0, 10, 0, 0);
                profileButton.Click += ProfileButton_Click;
                Profiles.Children.Add(profileButton);
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            currentProfile = 
            this.DialogResult = true;
        }
    }
}
