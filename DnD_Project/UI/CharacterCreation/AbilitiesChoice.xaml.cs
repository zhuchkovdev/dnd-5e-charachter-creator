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

namespace DnD_Project.UI.CharacterCreation
{
    /// <summary>
    /// Interaction logic for AbilitiesChoice.xaml
    /// </summary>
    public partial class AbilitiesChoice : UserControl
    {
        private string Str;
        private string Dex;
        private string Con;
        private string @Int;
        private string Wis;
        private string Cha;
        public AbilitiesChoice()
        {
            InitializeComponent();
        }

        private void Stat_Drop(object sender, DragEventArgs e, ref string stat)
        {
            if (((TextBlock)sender).Text == String.Empty)
            {
                string data = e.Data.GetData(DataFormats.Text).ToString();
                ((TextBlock)sender).Text = data;
                stat = data;
                DisableLabel(data);
            }
            else
            {
                EnableLabel(stat);
                string data = e.Data.GetData(DataFormats.Text).ToString();
                ((TextBlock)sender).Text = data;
                stat = data;
                DisableLabel(data);
            }
        }

        private void StrDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref Str);
        }

        private void DexDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref Dex);
        }

        private void ConDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref Con);
        }

        private void IntDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref Int);
        }

        private void WisDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref Wis);
        }

        private void ChaDrop_Drop(object sender, DragEventArgs e)
        {
            Stat_Drop(sender, e, ref Cha);
        }

        private void Stat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            DragDrop.DoDragDrop(label, label.Content, DragDropEffects.Copy);
        }

        private void DisableLabel(string index)
        {
            Dictionary<string, Label> labels = GetAllLabels();
            Label label = labels[index];
            label.Background = new SolidColorBrush(Colors.Gray);
            label.MouseDown -= Stat_MouseDown;
        }

        private void EnableLabel(string index)
        {
            if(!String.IsNullOrEmpty(index))
            {
                Dictionary<string, Label> labels = GetAllLabels();
                Label label = labels[index];
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
        }

        private void ResetLabels()
        {
            EnableLabel(Str);
            EnableLabel(Dex);
            EnableLabel(Con);
            EnableLabel(Int);
            EnableLabel(Wis);
            EnableLabel(Cha);
        }

        private void ResetStats()
        {
            Str = String.Empty;
            Dex = String.Empty;
            Con = String.Empty;
            Int = String.Empty;
            Wis = String.Empty;
            Cha = String.Empty;
        }

        private void ResetBorders()
        {
            StrDrop.Text = String.Empty;
            DexDrop.Text = String.Empty;
            ConDrop.Text = String.Empty;
            IntDrop.Text = String.Empty;
            WisDrop.Text = String.Empty;
            ChaDrop.Text = String.Empty;
        }
    }
}
