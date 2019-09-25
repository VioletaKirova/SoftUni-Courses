using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] commandArgs = command
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0].ToLower();
                string teamName = commandArgs[1];

                switch (commandType)
                {
                    case "team":
                        try
                        {
                            Team team = new Team(teamName);
                            teams.Add(team);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "add":
                        if (!CheckTeam(teams, teamName))
                        {
                            PrintMissingTeamMessage(teamName);
                            command = Console.ReadLine();
                            continue;
                        }

                        string playerToAdd = commandArgs[2];

                        try
                        {
                            Player player = new Player(playerToAdd);

                            player.Stats.Add(new Stat("Endurance", int.Parse(commandArgs[3])));
                            player.Stats.Add(new Stat("Sprint", int.Parse(commandArgs[4])));
                            player.Stats.Add(new Stat("Dribble", int.Parse(commandArgs[5])));
                            player.Stats.Add(new Stat("Passing", int.Parse(commandArgs[6])));
                            player.Stats.Add(new Stat("Shooting", int.Parse(commandArgs[7])));

                            Team teamToAddTo = teams.First(t => t.Name == teamName);
                            teamToAddTo.Players.Add(player);

                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "remove":
                        if (!CheckTeam(teams, teamName))
                        {
                            PrintMissingTeamMessage(teamName);
                            command = Console.ReadLine();
                            continue;
                        }

                        string playerToRemove = commandArgs[2];

                        Team teamToRemoveFrom = teams.First(t => t.Name == teamName);

                        if (!CheckPlayer(playerToRemove, teamToRemoveFrom))
                        {
                            PrintMissingPlayerMessage(playerToRemove);
                            command = Console.ReadLine();
                            continue;
                        }

                        Player playerForRemoval = teamToRemoveFrom.Players.First(p => p.Name == playerToRemove);

                        teamToRemoveFrom.Players.Remove(playerForRemoval);
                        break;
                    case "rating":
                        if (!CheckTeam(teams, teamName))
                        {
                            PrintMissingTeamMessage(teamName);
                            command = Console.ReadLine();
                            continue;
                        }

                        Team teamToRate = teams.First(t => t.Name == teamName);

                        Console.WriteLine(teamToRate.ToString());
                        break;
                }


                command = Console.ReadLine();
            }
        }

        private static void PrintMissingPlayerMessage(string playerToRemove)
        {
            Console.WriteLine($"Player {playerToRemove} is not in Arsenal team.");
        }

        private static bool CheckPlayer(string playerToRemove, Team currentTeam)
        {
            return currentTeam.Players.Any(p => p.Name == playerToRemove);
        }

        private static void PrintMissingTeamMessage(string teamName)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }

        private static bool CheckTeam(List<Team> teams, string teamName)
        {
            return teams.Any(t => t.Name == teamName);
        }
    }
}
