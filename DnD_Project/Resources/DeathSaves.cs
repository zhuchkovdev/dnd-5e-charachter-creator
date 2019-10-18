using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project
{
    class DeathSaves
    {
        internal int Successes { get; private set; }
        internal int Fails { get; private set; }

        public DeathSaves()
        {
            Successes = 0;
            Fails = 0;
        }

        public void AddSuccess()
        {
            if(Successes < 2)
            {
                Successes += 1;
            }
        }
        public void AddFail()
        {
            if (Fails < 2)
            {
                Fails += 1;
            }
        }
    }
}
