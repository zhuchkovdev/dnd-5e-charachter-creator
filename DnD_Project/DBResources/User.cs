using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DnD_Project.DBResources
{
    public class User
    {
        public int? ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
