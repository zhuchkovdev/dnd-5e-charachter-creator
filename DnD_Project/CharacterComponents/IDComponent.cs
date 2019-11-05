using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    class IDComponent
    {
        internal int ID { private get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
