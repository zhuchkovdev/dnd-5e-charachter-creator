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

        }

        private void BarbarianButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl barbarianUC = new BarbarianUC(ClassEnum.Barbarian);
            var confirmWin = new ConfirmWin(barbarianUC);
            if (confirmWin.ShowDialog() == true)
            {
                var parentWindow = (CharacterCreationWindow)Window.GetWindow(this);
                parentWindow.character.Class.SetClass(ClassEnum.Barbarian);
                ClassSelected?.Invoke();
            }
        }

        private void WisardButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
