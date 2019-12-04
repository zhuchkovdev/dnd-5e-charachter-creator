using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Project.Enums;

namespace DnD_Project.CharacterModule
{
    class ClassComponent
    {
        public string Class { get; set; }

        public event Action<Class> ClassSet;

        public void SetClass(Class @class)
        {
            Class = Enum.GetName(typeof(Class), @class);
            ClassSet?.Invoke(@class);
        }
    }
}
