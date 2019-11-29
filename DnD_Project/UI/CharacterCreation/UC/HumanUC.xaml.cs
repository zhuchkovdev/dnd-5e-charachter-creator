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
using DnD_Project.Enums;

namespace DnD_Project.UI.CharacterCreation.Races
{
    /// <summary>
    /// Interaction logic for HumanUC.xaml
    /// </summary>
    public partial class HumanUC : UserControl
    {
        public HumanUC(Race race)
        {
            InitializeComponent();
            switch (race)
            {
                case Race.Human:
                    LoadHumanInfo();
                    break;
            }
        }
        void LoadHumanInfo()
        {
            RaceName.Text = "Человек";
            RaceDescription.Text = "Люди - наиболее адаптивные и амбициозные создания среди стандартных рас. Что бы ими ни двигало, они всегда стремятся к прогрессу и достижению личных целей.";
            RaceImage.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\HumanPortrait.jpg"));
            RaceBonuses.Text = "+1 ко всем Модификаторам Характеристик, дополнительный язык на выбор";
        }
    }
}
