using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurace
{
    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool PluralsightAccess { get; set; }

        public Developer(string name, int id, bool access)
        {
            Name = name;
            ID = id;
            PluralsightAccess = access;
        }

        public Developer()
        {

        }
    }
}
