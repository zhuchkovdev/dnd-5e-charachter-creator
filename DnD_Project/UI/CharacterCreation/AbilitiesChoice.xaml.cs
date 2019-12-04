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
using System.Reflection;
using DnD_Project.Enums;

namespace DnD_Project.UI.CharacterCreation
{
    /// <summary>
    /// Interaction logic for AbilitiesChoice.xaml
    /// </summary>
    public partial class AbilitiesChoice : UserControl
    {
        string[] stats;
        Dictionary<string, Label> statLabels;
        List<TextBlock> statTexts;

        public delegate void StatsHandler();
        public event StatsHandler StatsSelected;

        public AbilitiesChoice()
        {
            InitializeComponent();
            statLabels = GetAllLabels();
            statTexts = GetAllStatTexts();
            stats = new string[6];
        }

        private List<TextBlock> GetAllStatTexts()
        {
            List<TextBlock> statTexts = new List<TextBlock>();
            statTexts.Add(StrDrop);
            statTexts.Add(DexDrop);
            statTexts.Add(ConDrop);
            statTexts.Add(IntDrop);
            statTexts.Add(WisDrop);
            statTexts.Add(ChaDrop);
            return statTexts;
        }

        private void Stat_Drop(object sender, DragEventArgs e, ref string stat)
        {
            if (((TextBlock)sender).Text == String.Empty)
            {
                string data = e.Data.GetData(DataFormats.Text).ToString();
                ((TextBlock)sender).Text = data;
                stat = data;
                DisableLabel(statLabels[data]);
            }
            else
            {
                EnableLabel(statLabels[stat]);
                string data = e.Data.GetData(DataFormats.Text).ToString();
                ((TextBlock)sender).Text = data;
                stat = data;
                DisableLabel(statLabels[data]);
            }

            if (IsFinished())
            {
                EnableContinueButton();
            }
        }

        private void StrDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref stats[(int)Stat.Str]);
        }

        private void DexDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref stats[(int)Stat.Dex]);
        }

        private void ConDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref stats[(int)Stat.Con]);
        }

        private void IntDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref stats[(int)Stat.Int]);
        }

        private void WisDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref stats[(int)Stat.Wis]);
        }

        private void ChaDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref stats[(int)Stat.Cha]);
        }

        private void Stat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            DragDrop.DoDragDrop(label, label.Content, DragDropEffects.Copy);
        }

        private void DisableLabel(Label label)
        {
            label.Background = new SolidColorBrush(Colors.Gray);
            label.MouseDown -= Stat_MouseDown;
        }

        private void EnableLabel(Label label)
        {
            if(!String.IsNullOrEmpty(label.Content.ToString()))
            {
                label.Background = new SolidColorBrush(Colors.White);
                label.MouseDown += Stat_MouseDown; 
            }
            
        }

        private Dictionary<string, Label> GetAllLabels()
        {
            Dictionary<string, Label> labels = new Dictionary<string, Label>();
            RecurseChildren(this, ref labels);
            return labels;
        }

        private void RecurseChildren(DependencyObject current, ref Dictionary<string, Label> dict)
        {
            foreach (object o in LogicalTreeHelper.GetChildren(current))
            {
                if (o is Label)
                {
                    var label = (Label)o;
                    dict.Add(label.Content.ToString(), label);
                }
                if (o is DependencyObject)
                {
                    RecurseChildren((DependencyObject)o, ref dict);
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetLabels();
            ResetStats();
            ResetBorders();
            DisableContinueButton();
        }

        private void ResetLabels()
        {
            foreach(var keyValue in statLabels)
            {
                EnableLabel(keyValue.Value);
            }
        }

        private void ResetStats()
        {
            for(int i = 0; i < stats.Length; i++)
            {
                stats[i] = String.Empty;
            }
        }

        private void ResetBorders()
        {
            foreach(var stat in statTexts)
            {
                stat.Text = String.Empty;
            }
        }


        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            int[] characterStats = new int[6];
            for (int i = 0; i < characterStats.Length; i++)
            {
                characterStats[i] = Int32.Parse(stats[i]);
            };

            var parentWindow = (CharacterCreationWindow)Window.GetWindow(this);
            parentWindow.character.Stats.AddStats(characterStats);
            StatsSelected?.Invoke();
            
        }

        private bool IsFinished()
        {
            for (int i = 0; i < stats.Length; i++)
            {
                if(String.IsNullOrEmpty(stats[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void EnableContinueButton()
        {
            ContinueButton.IsEnabled = true;
        }

        private void DisableContinueButton()
        {
            ContinueButton.IsEnabled = false;
        }
    }
}
