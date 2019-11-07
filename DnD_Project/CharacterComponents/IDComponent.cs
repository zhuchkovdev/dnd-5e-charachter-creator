using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    public class IDComponent
    {
        private int ID { get; set; }

        public void SetID(int id)
        {
            ID = id;
        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
