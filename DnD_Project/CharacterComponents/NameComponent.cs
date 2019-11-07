using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    public class NameComponent
    {
        private string Name { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            if(String.IsNullOrEmpty(Name))
            {
                return base.ToString();
            }
            return Name;
        }
    }
}
