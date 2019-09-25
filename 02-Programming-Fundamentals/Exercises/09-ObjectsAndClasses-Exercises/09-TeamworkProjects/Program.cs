using System;
using System.Collections.Generic;
using System.Linq;


namespace _09_TeamworkProjects
{
    // 25/100
    class Team
    {
        public string Name { get; set; }
        public List<string> Members { get; set; }
        public string Creator { get; set; }
        public int MemberCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> namesAndCreators = GetNamesAndCreators();
            List<string> creators = namesAndCreators.Values.ToList();
            Dictionary<string, List<string>> teamMembers = GetTeamMembers(namesAndCreators, creators);
            List<Team> teams = CreateTeamList(namesAndCreators, teamMembers);
            PrintTeams(teams);
        }

        static Dictionary<string, string> GetNamesAndCreators()
        {
            int n = int.Parse(Console.ReadLine());
            var namesAndCreators = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                string creator = input[0];
                string teamName = input[1];
                
                if (namesAndCreators.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (namesAndCreators.ContainsValue(creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    namesAndCreators[teamName] = creator;
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            return namesAndCreators;
        }

        static Dictionary<string, List<string>> GetTeamMembers(Dictionary<string, string> namesAndCreators, List<string> creators)
        {
            var teamMembers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] inputArr = input.Split('-').ToArray();
                string member = inputArr[0];
                string team = inputArr[1].TrimStart('>').ToString();

                if (!namesAndCreators.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    input = Console.ReadLine();
                    continue;
                }
                else if (!teamMembers.ContainsKey(team))
                {
                    teamMembers[team] = new List<string>();
                }

                if (teamMembers[team].Any(m => m == member) || creators.Any(m => m == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                    input = Console.ReadLine();
                    continue;
                }

                teamMembers[team].Add(member);
                input = Console.ReadLine();
            }

            return teamMembers;
        }

        static List<Team> CreateTeamList(Dictionary<string, string> namesAndCreators, Dictionary<string, List<string>> teamMembers)
        {
            List<Team> teams = new List<Team>();
            int listLength = namesAndCreators.Count;

            foreach (var team in namesAndCreators)
            {
                Team currentTeam = new Team();
                currentTeam.Name = team.Key;
                currentTeam.Creator = team.Value;
                currentTeam.MemberCount = teamMembers[team.Key].Count;
                teams.Add(currentTeam);
            }

            foreach (var team in teamMembers)
            {
                foreach (var t in teams)
                {
                    if (t.Name == team.Key)
                    {
                        t.Members = team.Value;
                    }
                }
            }

            return teams;
        }

        static void PrintTeams(List<Team> teams)
        {
            foreach (var team in teams.OrderByDescending(t => t.MemberCount).ThenBy(n => n.Name))
            {
                if (team.Members.Count >= 1)
                {
                    Console.WriteLine($"{team.Name}");
                    Console.WriteLine($"- {team.Creator}");

                    foreach (var member in team.Members.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teams)
            {
                if (team.Members.Count == 0)
                {
                    Console.WriteLine($"{team.Name}");
                }
            }
        }
    }
}