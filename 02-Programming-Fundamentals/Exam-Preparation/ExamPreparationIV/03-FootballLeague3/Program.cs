using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_FootballLeague
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            key = Regex.Escape(key);
            string input = Console.ReadLine();

            var teamPointsDict = new Dictionary<string, int>();
            var teamGoalsDict = new Dictionary<string, int>();

            while (input != "final")
            {
                // match and decrypt teams
                List<string> teams = new List<string>();

                string teamsPattern = $@"({key})(\S+)({key})";
                Regex teamsRegex = new Regex(teamsPattern);
                MatchCollection matches = teamsRegex.Matches(input);

                foreach (Match m in matches)
                {
                    char[] nameArr = m.Groups[2].Value.ToUpper().ToArray().Reverse().ToArray();
                    string name = string.Join("", nameArr);
                    teams.Add(name);
                }

                // match score
                string scorePattern = @"(\d+):(\d+)";
                Regex scoreRegex = new Regex(scorePattern);
                Match scoreMatch = scoreRegex.Match(input);
                int firstTeamScore = int.Parse(scoreMatch.Groups[1].Value);
                int secondTeamScore = int.Parse(scoreMatch.Groups[2].Value);

                // fill in the team points
                foreach (var team in teams)
                {
                    if (!teamPointsDict.ContainsKey(team))
                        teamPointsDict.Add(team, 0);
                }

                if (firstTeamScore > secondTeamScore)
                    teamPointsDict[teams[0]] += 3;
                else if (secondTeamScore > firstTeamScore)
                    teamPointsDict[teams[1]] += 3;
                else if (firstTeamScore == secondTeamScore)
                {
                    teamPointsDict[teams[0]] += 1;
                    teamPointsDict[teams[1]] += 1;
                }

                // fill in the team goals
                foreach (var team in teams)
                {
                    if (!teamGoalsDict.ContainsKey(team))
                        teamGoalsDict.Add(team, 0);
                }

                teamGoalsDict[teams[0]] += firstTeamScore;
                teamGoalsDict[teams[1]] += secondTeamScore;

                input = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            int place = 1;

            foreach (var team in teamPointsDict.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{place}. {team.Key} {team.Value}");
                place++;
            }

            Console.WriteLine("Top 3 scored goals:");
            int count = 0;

            foreach (var team in teamGoalsDict.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                count++;
                Console.WriteLine($"- {team.Key} -> {team.Value}");
                if (count == 3)
                    break;
            }
        }
    }
}