using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Project.Enums;

namespace DnD_Project.CharacterComponents
{
    public class HitPointsComponent
    {
        public int MaxHP { get; set; }
        public string Dice { get; set; }
        
        public void UpdateClassHP(Class @class)
        {
            switch (@class)
            {
                case Class.Barbarian:
                    Dice = "D12";
                    MaxHP = 12;
                    break;
                case Class.Ranger:
                    Dice = "D10";
                    MaxHP = 10;
                    break;
                case Class.Wisard:
                    Dice = "D6";
                    MaxHP = 6;
                    break;
            }
        }
    }
}
