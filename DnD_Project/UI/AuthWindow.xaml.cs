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
using DnD_Project.DBResources;

namespace DnD_Project.UI
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private DBController dbController;

        public User CurrentUser { get; private set; }
        public AuthWindow()
        {
            InitializeComponent();
            dbController = new DBController(@"Data Source =.\SQLEXPRESS;Initial Catalog=dndDB; Integrated Security=True");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = String.Empty;
            CurrentUser = new User
            {
                Password = PasswordBox.Password,
                Login = UsernameBox.Text
            };

            CurrentUser.ID = dbController.GetUserID(CurrentUser);

            if (CurrentUser.ID.HasValue)
            {
                this.DialogResult = true;
            }
            else
            {
                ErrorText.Text = "Такой учетной записи не существует";
            }
        }
        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = String.Empty;

            CurrentUser = new User
            {
                Password = PasswordBox.Password,
                Login = UsernameBox.Text
            };

            if (dbController.UserExists(CurrentUser))
            {
                ErrorText.Text = "Такая учетная запись уже существует";
            }
            else
            {
                dbController.CreateUser(CurrentUser);
                this.DialogResult = true;
            }
            
        }
    }
}
