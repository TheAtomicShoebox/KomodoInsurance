using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurace
{
    public class DevTeam
    {
        public List<Developer> Team { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }

        public DevTeam(List<Developer> team, string name, int id)
        {
            Team = team;
            Name = name;
            ID = id;
        }

        public DevTeam()
        {

        }
    }
}
