using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Project.Enums;

namespace DnD_Project.CharacterModule
{
    public class SavingThrowsComponent
    {
        public Dictionary<Stat, bool> SavingThrows { get; set; }

        public SavingThrowsComponent()
        {
            SavingThrows = new Dictionary<Stat, bool>();
            for (var i = Stat.Str; i <= Stat.Cha; i++)
            {
                SavingThrows.Add(i, false);
            }
        }

        public void UpdateClassSavingThrows(Class @class)
        {
            switch(@class)
            {
                case Class.Barbarian:
                    SavingThrows[Stat.Str] = true;
                    SavingThrows[Stat.Con] = true;
                    break;
                case Class.Ranger:
                    SavingThrows[Stat.Str] = true;
                    SavingThrows[Stat.Dex] = true;
                    break;
                case Class.Wisard:
                    SavingThrows[Stat.Int] = true;
                    SavingThrows[Stat.Wis] = true;
                    break;
            }
        }
    }
}
