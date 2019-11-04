using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum AlignmentEnum
    {
        LawfulGood,
        NeutralGood,
        ChaoticGood,
        LawfulNeutral,
        Neutral,
        ChaoticNeutral,
        LawfulEvil,
        NeutralEvil,
        ChaoticEvil
    }
    class AlignmentComponent
    {
        private string Alignment { get; set; }
        internal void SetAlignment(AlignmentEnum alignment)
        {
            switch(alignment)
            {
                case AlignmentEnum.LawfulGood:
                    Alignment = "Lawful good";
                    break;
                case AlignmentEnum.NeutralGood:
                    Alignment = "Neutral good";
                    break;
                case AlignmentEnum.ChaoticGood:
                    Alignment = "Chaotic good";
                    break;
                case AlignmentEnum.LawfulNeutral:
                    Alignment = "Lawful neutral";
                    break;
                case AlignmentEnum.Neutral:
                    Alignment = "Neutral";
                    break;
                case AlignmentEnum.ChaoticNeutral:
                    Alignment = "Chaotic neutral";
                    break;
                case AlignmentEnum.LawfulEvil:
                    Alignment = "Lawful evil";
                    break;
                case AlignmentEnum.NeutralEvil:
                    Alignment = "Neutral evil";
                    break;
                case AlignmentEnum.ChaoticEvil:
                    Alignment = "Chaotic evil";
                    break;
            }
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Alignment))
            {
                return base.ToString();
            }
            return Alignment;
        }
    }
}
