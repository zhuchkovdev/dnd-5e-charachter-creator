using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    enum ClassEnum
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wisard
    }
    class ClassComponent
    {
        internal string Class { get; private set; }

        internal void SetClass(ClassEnum @class)
        {
            switch (@class)
            {
                case ClassEnum.Barbarian:
                    Class = "Barbarian";
                    ClassChanged?.Invoke(ClassEnum.Barbarian);
                    break;
                case ClassEnum.Bard:
                    ClassChanged?.Invoke(ClassEnum.Bard);
                    Class = "Bard";
                    break;
                case ClassEnum.Cleric:
                    Class = "Cleric";
                    ClassChanged?.Invoke(ClassEnum.Cleric);
                    break;
                case ClassEnum.Druid:
                    Class = "Druid";
                    ClassChanged?.Invoke(ClassEnum.Druid);
                    break;
                case ClassEnum.Fighter:
                    Class = "Fighter";
                    ClassChanged?.Invoke(ClassEnum.Fighter);
                    break;
                case ClassEnum.Monk:
                    Class = "Monk";
                    ClassChanged?.Invoke(ClassEnum.Monk);
                    break;
                case ClassEnum.Paladin:
                    Class = "Paladin";
                    ClassChanged?.Invoke(ClassEnum.Paladin);
                    break;
                case ClassEnum.Ranger:
                    Class = "Ranger";
                    ClassChanged?.Invoke(ClassEnum.Ranger);
                    break;
                case ClassEnum.Rogue:
                    Class = "Rogue";
                    ClassChanged?.Invoke(ClassEnum.Rogue);
                    break;
                case ClassEnum.Sorcerer:
                    Class = "Sorcerer";
                    ClassChanged?.Invoke(ClassEnum.Sorcerer);
                    break;
                case ClassEnum.Warlock:
                    Class = "Warlock";
                    ClassChanged?.Invoke(ClassEnum.Warlock);
                    break;
                case ClassEnum.Wisard:
                    Class = "Wisard";
                    ClassChanged?.Invoke(ClassEnum.Wisard);
                    break;
            }
        }

        public delegate void ClassEventHandler(ClassEnum @class);
        public event ClassEventHandler ClassChanged;
    }
}
