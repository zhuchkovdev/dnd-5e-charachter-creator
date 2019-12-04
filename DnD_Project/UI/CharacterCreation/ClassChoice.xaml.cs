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
using DnD_Project.CharacterComponents;
using DnD_Project.Enums;
using DnD_Project.UI.CharacterCreation.UC;

namespace DnD_Project.UI.CharacterCreation
{
    /// <summary>
    /// Interaction logic for ClassChoice.xaml
    /// </summary>
    public partial class ClassChoice : UserControl
    {
        public ClassChoice()
        {
            InitializeComponent();
        }

        public delegate void ClassHandler();
        public event ClassHandler ClassSelected;

        private void RangerButton_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e, Class.Ranger);
        }

        private void BarbarianButton_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e, Class.Barbarian);
        }

        private void WisardButton_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e, Class.Wisard);
        }

        private void Button_Click(object sender, RoutedEventArgs e, Class @class)
        {
            UserControl classUC = new ChoiceUC(@class);
            var confirmWin = new ConfirmWin(classUC);
            if (confirmWin.ShowDialog() == true)
            {
                var parentWindow = (CharacterCreationWindow)Window.GetWindow(this);
                parentWindow.character.SetClass(@class);
                ClassSelected?.Invoke();
            }
        }
    }
}
