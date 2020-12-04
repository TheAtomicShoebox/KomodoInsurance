using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoInsurace
{
    public class ProgramUI
    {
        private DeveloperRepo developerRepo = new DeveloperRepo();
        private DevTeamRepo developerTeamRepo = new DevTeamRepo();
        public void Run()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Management");
                Console.WriteLine("Select an Option:\n" +
                                "1.\tDeveloper Management\n" +
                                "2.\tTeam Management\n" +
                                "3.\tExit");
                int option = 0;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Response");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Run();
                }
                switch (option)
                {
                    case 1:
                        DeveloperManagementMenu();
                        break;
                    case 2:
                        TeamManagementMenu();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Response.");
                        break;
                }
            }
        }

        private void DeveloperManagementMenu()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                DisplayDeveloperList();
                int selection = 0;
                Console.WriteLine("Select an Option:\n" +
                    "1.\tAdd Developer\n" +
                    "2.\tModify Developers\n" +
                    "3.\tRemove Developers\n" +
                    "4.\tBack");
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Response");
                    DeveloperManagementMenu();
                }

                switch (selection)
                {
                    case 1:
                        AddDeveloper();
                        break;
                    case 2:
                        ModifyDeveloper();
                        break;
                    case 3:
                        RemoveDeveloper();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void TeamManagementMenu()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                DisplayTeamList();
                int selection = 0;
                Console.WriteLine("Select an Option:\n" +
                    "1.\tAdd Team\n" +
                    "2.\tModify Team\n" +
                    "3.\tRemove Team\n" +
                    "4.\tBack");
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Response");
                    TeamManagementMenu();
                }
                switch (selection)
                {
                    case 1:
                        AddTeam();
                        break;
                    case 2:
                        ModifyTeam();
                        break;
                    case 3:
                        RemoveTeam();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplayTeamList()
        {
            List<DevTeam> list = developerTeamRepo.GetDeveloperTeamList();
            foreach(DevTeam team in list)
            {
                DisplayTeam(team);
            }
        }

        private void DisplayTeam(DevTeam team, bool showMembers = false)
        {
            Console.WriteLine($"ID: {team.ID,-5}Name: {team.Name,-20}Number of Members: {team.Team.Count,5}");
            if (showMembers)
            {
                foreach(Developer dev in team.Team)
                {
                    DisplayDeveloper(dev);
                }
            }
        }

        private void DisplayTeam(int id, string name, List<Developer> devs, bool showMembers = false)
        {
            Console.WriteLine($"ID: {id,-5}Name: {name,-20}Number of Members: {devs.Count,5}");
            if (showMembers)
            {
                foreach(Developer dev in devs)
                {
                    DisplayDeveloper(dev);
                }
            }
        }

        private void DisplayDeveloperList()
        {
            List<Developer> list = developerRepo.GetDeveloperList();
            foreach(Developer dev in list)
            {
                DisplayDeveloper(dev);
            }
        }

        private Developer FindDeveloper()
        {
            DisplayDeveloperList();
            Console.WriteLine("Dev ID (q to quit):");
            string response = Console.ReadLine();
            if(response.ToLower() != "q")
            {
                int oldId = int.Parse(response);
                return developerRepo.GetDevById(oldId);
            }
            return null;
        }

        private DevTeam FindTeam()
        {
            DisplayTeamList();
            Console.WriteLine("Team ID (q to quit):");
            string response = Console.ReadLine();
            if (response.ToLower() != "q")
            {
                int oldId = int.Parse(response);
                return developerTeamRepo.GetTeamById(oldId);
            }
            return null;
        }

        private void DisplayDeveloper(Developer dev)
        {
            Console.WriteLine($"ID: {dev.ID,-5}Name: {dev.Name,-20}Access: {dev.PluralsightAccess,5}");
        }

        private void DisplayDeveloper(int id, string name, bool access)
        {
            Console.WriteLine($"ID: {id,-5}Name: {name,-20}Access: {access,5}");
        }

        private void AddDeveloper()
        {
            Console.Clear();
            Console.WriteLine("ID:");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid Reponse. Returning...");
                DeveloperManagementMenu();
            }
            
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Pluralsight Access (t/f):");
            string access = Console.ReadLine().ToLower();
            bool p_access;
            if(access == "t")
            {
                p_access = true;
            }
            else if(access == "f")
            {
                p_access = false;
            }
            else
            {
                p_access = false;
            }
            Developer dev = new Developer()
            {
                ID = id,
                Name = name,
                PluralsightAccess = p_access
            };
            developerRepo.AddDeveloper(dev);
        }

        private bool ModifyDeveloper()
        {
            Console.Clear();
            Developer dev = FindDeveloper();
            int oldId = dev.ID;
            string oldName = dev.Name;
            bool oldAccess = dev.PluralsightAccess; 
            
            
            if (dev != null)
            {
                int newId = 0;
                string newName = "";
                bool newAccess = false;
                bool loopExiter = true;
                string response = null;
                if (dev == null)
                {
                    return false;
                }
                DisplayDeveloper(dev);
                while (loopExiter)
                {
                    Console.WriteLine("New ID (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newId = int.Parse(response);
                            loopExiter = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newId = oldId;
                    }
                    loopExiter = false;
                }
                loopExiter = true;
                Console.Clear();
                DisplayDeveloper(dev);
                while (loopExiter)
                {
                    Console.WriteLine("New name (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newName = response;
                            loopExiter = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newName = oldName;
                    }
                    loopExiter = false;
                }
                loopExiter = true;
                Console.Clear();
                DisplayDeveloper(dev);
                while (loopExiter)
                {
                    Console.WriteLine("New Access (t/f) (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            if(response.ToLower() == "t")
                            {
                                newAccess = true;
                            }
                            else if(response.ToLower() == "f")
                            {
                                newAccess = false;
                            }
                            loopExiter = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newAccess = oldAccess;
                    }
                    loopExiter = false;
                }
                DisplayDeveloper(newId, newName, newAccess);
                Console.WriteLine("Is this correct? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if(answer == "y")
                {
                    developerRepo.UpdateExistingDeveloper(oldId, new Developer() { Name = newName, ID = newId, PluralsightAccess = newAccess });
                }
                else if(answer == "n")
                {
                    ModifyDeveloper();
                }
            }
            return false;
        }

        private void RemoveDeveloper()
        {
            Developer dev = FindDeveloper();
            DisplayDeveloper(dev);
            Console.WriteLine("Are you sure you want to remove this developer? (y/n)");
            string response = Console.ReadLine().ToLower();
            if(response == "y")
            {
                Console.WriteLine("Are you certain? (y/n)");
                response = Console.ReadLine().ToLower();
                if(response == "y")
                {
                    developerRepo.RemoveDeveloper(dev.ID);
                    Console.WriteLine("Developer removed");
                }
            }
        }

        private void AddTeam()
        {
            Console.Clear();
            Console.WriteLine("ID:");
            int id = 0;
            List<Developer> devs = new List<Developer>();
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Reponse. Returning...");
                DeveloperManagementMenu();
            }

            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            DevTeam team = new DevTeam()
            {
                ID = id,
                Name = name,
                Team = devs
            };
            developerTeamRepo.AddDeveloperTeam(team);
            Console.WriteLine("Add members? (y/n)");
            string response = Console.ReadLine().ToLower();
            if(response == "y")
            {
                AddDeveloperToTeam(id);
            }
        }

        private void AddDeveloperToTeam(int id)
        {
            Console.Clear();
            bool more = true;
            string response = "";
            DevTeam team = developerTeamRepo.GetTeamById(id);
            string name = team.Name;
            List<Developer> currentList = new List<Developer>();
            while (more)
            {
                Developer dev = FindDeveloper();
                currentList.Add(dev);
                DisplayTeam(id, name, currentList,  true);
                Console.WriteLine("Add more? (y/n)");
                response = Console.ReadLine().ToLower();
                if(response == "n")
                {
                    more = false;
                }
            }
            Console.Clear();
            DisplayTeam(id, name, currentList, true);
            Console.WriteLine("Is this correct? (y/n)");
            response = Console.ReadLine().ToLower();
            if(response == "y")
            {
                developerTeamRepo.AddDeveloperListToTeam(id, currentList);
            }
            
        }

        private bool ModifyTeam()
        {
            Console.Clear();
            DevTeam team = FindTeam();
            if(team == null)
            {
                return false;
            }
            int oldId = team.ID;
            string oldName = team.Name;
            List<Developer> oldMembers = team.Team;

            if (team != null)
            {
                int newId = 0;
                string newName = "";
                List<Developer> newMembers = new List<Developer>();
                bool loopExiter = true;
                string response = null;
                if (team == null)
                {
                    return false;
                }
                DisplayTeam(team, true);
                while (loopExiter)
                {
                    Console.WriteLine("New ID (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newId = int.Parse(response);
                            loopExiter = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newId = oldId;
                    }
                    loopExiter = false;
                }
                loopExiter = true;
                Console.Clear();
                DisplayTeam(team);
                while (loopExiter)
                {
                    Console.WriteLine("New name (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newName = response;
                            loopExiter = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newName = oldName;
                    }
                    loopExiter = false;
                }
                loopExiter = true;
                Console.Clear();
                DisplayTeam(newId, newName, newMembers, true);
                Console.WriteLine("Is this correct? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    developerTeamRepo.UpdateExistingTeam(oldId, new DevTeam() { Name = newName, ID = newId, Team = newMembers });
                }
                else if (answer == "n")
                {
                    ModifyTeam();
                }
            }
            return false;
        }

        private void RemoveTeam()
        {
            DevTeam devTeam = FindTeam();
            DisplayTeam(devTeam);
            Console.WriteLine("Are you sure you want to remove this team? (y/n)");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Are you certain? (y/n)");
                response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    developerTeamRepo.RemoveDeveloperTeam(devTeam.ID);
                    Console.WriteLine("Team removed");
                }
            }
        }
    }
}
