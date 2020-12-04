using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurace
{
    public class DevTeamRepo
    {
        private List<DevTeam> devTeamList = new List<DevTeam>();

        //C
        public void AddDeveloperTeam(DevTeam team)
        {
            devTeamList.Add(team);
        }

        //R
        public List<DevTeam> GetDeveloperTeamList()
        {
            return devTeamList;
        }

        //U
        public bool UpdateExistingTeam(int id, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamById(id);
            if(oldTeam != null)
            {
                oldTeam.ID = newTeam.ID;
                oldTeam.Name = newTeam.Name;
                oldTeam.Team = newTeam.Team;
                return true;
            }
            return false;
        }

        public bool AddDeveloperToTeam(int devTeamId, Developer Developer)
        {
            DevTeam team = GetTeamById(devTeamId);
            if(team != null)
            {
                team.Team.Add(Developer);
                return true;
            }
            return false;
        }

        public bool AddDeveloperListToTeam(int devTeamId, List<Developer> devs)
        {
            DevTeam team = GetTeamById(devTeamId);
            if(team != null)
            {
                foreach(Developer dev in devs)
                {
                    team.Team.Add(dev);
                }
                return true;
            }
            return false;
        }

        //D
        public bool RemoveDeveloperTeam(int devTeamId)
        {
            DevTeam team = GetTeamById(devTeamId);
            if(team != null)
            {
                int initialCount = devTeamList.Count;
                devTeamList.Remove(team);
                if(initialCount > devTeamList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public DevTeam GetTeamById(int id)
        {
            foreach(DevTeam team in devTeamList)
            {
                if(team.ID == id)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
