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

namespace DnD_Project.UI.CharacterCreation.UC
{
    /// <summary>
    /// Interaction logic for BarbarianUC.xaml
    /// </summary>
    public partial class BarbarianUC : UserControl
    {
        public BarbarianUC(ClassEnum @class)
        {
            InitializeComponent();
            switch(@class)
            {
                case ClassEnum.Barbarian:
                    LoadBarbarianInfo();
                    break;
            }
        }

        private void LoadBarbarianInfo()
        {
            ClassName.Text = "Варвар";
            ClassDescription.Text = "Свирепые воины, использующие в бою свою первобытную ярость";
            ClassImage.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\BarbarianIcon.png"));
            ClassBonuses.Text = "Кость хитов: d12\nОсновная характеристика: Сила\nСпасброски: Сила и Телосложение";
        }
    }
}
