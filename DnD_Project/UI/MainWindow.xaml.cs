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
using DnD_Project.DAL;
using DnD_Project.CharacterModule;

namespace DnD_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RadioButton currentTab;
        DBController db;
        User currentUser;
        List<int> characterIDs;
        Character currentCharacter;

        public MainWindow()
        {
            InitializeComponent();
            db = new DBController(@"Data Source =D:\Projects\DnD_Project\DnD_Project\DnD_DB.db");
            Authorization();

            characterIDs = db.GetCharactersList(currentUser);

            DisplayTabs();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Character newCharacter = new Character();

            var nameWindow = new CharacterNameWindow();
            if (nameWindow.ShowDialog() == true)
            {
                var Tab = (RadioButton)this.TryFindResource("TabButton");
                Tab.Content = nameWindow.CharacterName;
                CharTabs.Children.Add(Tab);

                this.Hide();
                var creationWindow = new CharacterCreationWindow();
                if(creationWindow.ShowDialog() == true)
                {
                    newCharacter = creationWindow.character;

                    int newCharacterID;
                    db.CreateBlankCharacter(currentUser, nameWindow.CharacterName, out newCharacterID);
                    characterIDs.Add(newCharacterID);
                    newCharacter.ID = newCharacterID;
                    newCharacter.Name = nameWindow.CharacterName;
                    db.SaveCharacter(new CharacterData(newCharacter));

                    this.Show();

                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Tab_Checked(object sender, RoutedEventArgs e)
        {
            int currentCharID = 0;
            for(int i = 0; i < CharTabs.Children.Count; i++)
            {
                if(sender == (RadioButton)CharTabs.Children[i])
                {
                    currentCharID = characterIDs[i];
                }
            }
            currentCharacter = db.GetCharacter(currentCharID);
            UserControl CharacterPanel = new CharSheet(currentCharacter);
            CharPanel.Content = CharacterPanel;

            currentTab = (RadioButton)sender;
            RemoveButton.IsEnabled = true;
        }

        public void Authorization()
        {
            this.Hide();
            var authWindow = new AuthWindow(db);

            if (authWindow.ShowDialog() == true)
            {
                UsernameTextBlock.Text = authWindow.CurrentUser.Login;
                currentUser = authWindow.CurrentUser;

                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        
        void DisplayTabs()
        {
            foreach (var characterID in characterIDs)
            {
                var Tab = (RadioButton)this.TryFindResource("TabButton");
                var charName = db.GetCharacterName(characterID);
                Tab.Content = charName;
                CharTabs.Children.Add(Tab);
            }
        }

        void DeleteCharacter(Character character)
        {
            CharTabs.Children.Remove(currentTab);

            for (int i = 0; i < CharTabs.Children.Count; i++)
            {
                if (currentTab == (RadioButton)CharTabs.Children[i])
                {
                    characterIDs.Remove(i);
                }
            }

            db.DeleteCharacter(character);

            CharPanel.Content = null;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            DeleteCharacter(currentCharacter);
        }
    }
}
