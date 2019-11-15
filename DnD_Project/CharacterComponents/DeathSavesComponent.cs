using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Project.CharacterComponents
{
    public class DeathSavesComponent
    {
        internal int Successes { get; private set; }
        internal int Fails { get; private set; }

        //DeleteLater
        public DeathSavesComponent()
        {
            var rand = new Random();
            Successes = rand.Next(0, 3);
            Fails = rand.Next(0, 3);
        }
        public void AddSuccess()
        {
            if (Successes <= 2)
            {
                Successes += 1;
            }
        }
        public void AddFail()
        {
            if (Fails <= 2)
            {
                Fails += 1;
            }
        }
    }
}
