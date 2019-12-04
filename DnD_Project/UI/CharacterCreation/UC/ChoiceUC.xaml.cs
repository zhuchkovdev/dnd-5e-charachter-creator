using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DnD_Project.Enums;

namespace DnD_Project.UI.CharacterCreation.UC
{
    /// <summary>
    /// Interaction logic for ChoiceUC.xaml
    /// </summary>
    public partial class ChoiceUC : UserControl
    {
        public ChoiceUC(Class @class)
        {
            InitializeComponent();
            switch (@class)
            {
                case Class.Barbarian:
                    LoadBarbarianInfo();
                    break;
                case Class.Ranger:
                    LoadRangerInfo();
                    break;
                case Class.Wisard:
                    LoadWisardInfo();
                    break;
            }
        }

        public ChoiceUC(RaceEnum race)
        {
            InitializeComponent();
            switch (race)
            {
                case RaceEnum.Human:
                    LoadHumanInfo();
                    break;
                case RaceEnum.MountainDwarf:
                    LoadMountainDwarfInfo();
                    break;
                case RaceEnum.HillDwarf:
                    LoadHillDwarfInfo();
                    break;
                case RaceEnum.HighElf:
                    LoadHighElfInfo();
                    break;
                case RaceEnum.WoodElf:
                    LoadWoodElfInfo();
                    break;
                case RaceEnum.Drow:
                    LoadDrowInfo();
                    break;
            }
        }

        #region LoadClass methods
        private void LoadBarbarianInfo()
        {
            Title.Text = "Варвар";
            Description.Text = "Свирепые воины, использующие в бою свою первобытную ярость";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\BarbarianIcon.png"));
            Bonuses.Text = "Кость хитов: d12\nОсновная характеристика: Сила\nСпасброски: Сила и Телосложение";
        }

        private void LoadRangerInfo()
        {
            Title.Text = "Следопыт";
            Description.Text = "Бойцы диких земель, смертоносные охотники, специализирующиеся на охоте на монстров";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\RangerIcon.png"));
            Bonuses.Text = "Кость хитов: d10\nОсновные характеристики: Ловкость и Мудрость\nСпасброски: Сила и Ловкость";
        }

        private void LoadWisardInfo()
        {
            Title.Text = "Волшебник";
            Description.Text = "Адепты магии, изменяющие ткань мироздания по своему желанию";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\WisardIcon.png"));
            Bonuses.Text = "Кость хитов: d6\nОсновная характеристика: Интеллект\nСпасброски: Интеллект и Мудрость";
        }
        #endregion

        #region LoadRace methods
        void LoadHumanInfo()
        {
            Title.Text = "Человек";
            Description.Text = "Люди - наиболее адаптивные и амбициозные создания среди стандартных рас. Что бы ими ни двигало, они всегда стремятся к прогрессу и достижению личных целей.";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\HumanPortrait.jpg"));
            Bonuses.Text = "+1 ко всем характеристикам";
        }

        private void LoadDrowInfo()
        {
            Title.Text = "Дроу";
            Description.Text = "Произошедшие от более древней подрасы темнокожих эльфов, дроу были изгнаны с земной поверхности мира, и обречены поклоняться богине Лолс и следовать пути зла и упадка.";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\DrowIcon.png"));
            Bonuses.Text = "+2 к Ловкости, +1 к Харизме";
        }

        private void LoadWoodElfInfo()
        {
            Title.Text = "Лесной эльф";
            Description.Text = "Эльфы это волшебный народ, обладающий неземным изяществом, живущий в мире, но не являющийся его частью.";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\WoodElfIcon.png"));
            Bonuses.Text = "+2 к Ловкости, +1 к Мудрости";
        }

        private void LoadHighElfInfo()
        {
            Title.Text = "Высший эльф";
            Description.Text = "Эльфы это волшебный народ, обладающий неземным изяществом, живущий в мире, но не являющийся его частью.";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\HighElfIcon.png"));
            Bonuses.Text = "+2 к Ловкости, +1 к Интеллекту";
        }

        private void LoadHillDwarfInfo()
        {
            Title.Text = "Холмовой дварф";
            Description.Text = "Сильные и выносливые, дварфы приспособлены к жизни в суровых условиях. От сияющих шпилей Невервинтера до Долины Ледяного Ветра дварфы славятся своим кузнечным мастерством.";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\HillDwarfIcon.png"));
            Bonuses.Text = "+2 к Телосложению, +1 к Мудрости, +1 к максимальному здоровью";
        }

        private void LoadMountainDwarfInfo()
        {
            Title.Text = "Горный дварф";
            Description.Text = "Сильные и выносливые, дварфы приспособлены к жизни в суровых условиях. От сияющих шпилей Невервинтера до Долины Ледяного Ветра дварфы славятся своим кузнечным мастерством.";
            Image.Source = new BitmapImage(new Uri(@"D:\Projects\DnD_Project\DnD_Project\MountainDwarfIcon.png"));
            Bonuses.Text = "+2 к Телосложению, +2 к Силе";
        }
        #endregion
    }
}
