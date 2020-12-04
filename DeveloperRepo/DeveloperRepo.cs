using System.Collections.Generic;

namespace KomodoInsurace
{
    public class DeveloperRepo
    {
        private List<Developer> devList = new List<Developer>();

        //C
        public void AddDeveloper(Developer dev)
        {
            devList.Add(dev);
        }

        //R
        public List<Developer> GetDeveloperList()
        {
            return devList;
        }

        //U
        public bool UpdateExistingDeveloper(int id, Developer newDev)
        {
            Developer oldDev = GetDevById(id);
            if(oldDev != null)
            {
                oldDev.Name = newDev.Name;
                oldDev.ID = newDev.ID;
                oldDev.PluralsightAccess = newDev.PluralsightAccess;
                return true;
            }
            return false;
        }

        //D
        public bool RemoveDeveloper(int id)
        {
            Developer dev = GetDevById(id);
            if (dev != null)
            {
                int initialCount = devList.Count;
                devList.Remove(dev);
                if(initialCount > devList.Count)
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

        public Developer GetDevById(int id)
        {
            foreach(Developer dev in devList)
            {
                if(dev.ID == id)
                {
                    return dev;
                }
            }

            return null;
        }
    }
}
