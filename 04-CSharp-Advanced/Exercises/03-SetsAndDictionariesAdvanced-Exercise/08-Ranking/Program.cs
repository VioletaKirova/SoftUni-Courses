using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    class User
    {
        public string Name { get; set; }

        public Dictionary<string, int> Contests { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] contestInfo = ReadContestInfo();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (contestInfo[0] != "end of contests")
            {
                string contest = contestInfo[0];
                string contestPass = contestInfo[1];

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = string.Empty;
                }

                contests[contest] = contestPass;

                contestInfo = ReadContestInfo();
            }

            Dictionary<string, User> users = new Dictionary<string, User>();

            string[] submissionsInfo = ReadSubmission();

            while (submissionsInfo[0] != "end of submissions")
            {
                string contest = submissionsInfo[0];
                string password = submissionsInfo[1];
                string username = submissionsInfo[2];
                int points = int.Parse(submissionsInfo[3]);

                if (!contests.ContainsKey(contest))
                {
                    submissionsInfo = ReadSubmission();

                    continue;
                }

                if (contests[contest] != password)
                {
                    submissionsInfo = ReadSubmission();

                    continue;
                }

                User user = new User();

                user.Name = username;

                if (!users.ContainsKey(user.Name))
                {
                    users[user.Name] = new User();
                    users[user.Name].Contests = new Dictionary<string, int>();
                }

                if (!users[user.Name].Contests.ContainsKey(contest))
                {
                    users[user.Name].Contests[contest] = points;
                }
                else if (users[user.Name].Contests[contest] < points)
                {
                    users[user.Name].Contests[contest] = points;
                }
                
                submissionsInfo = ReadSubmission();
            }

            Dictionary<string, int> userTotalPoints = new Dictionary<string, int>();

            foreach (var user in users)
            {
                int totalPoints = 0;

                foreach (var contest in users[user.Key].Contests)
                {
                    totalPoints += contest.Value;
                }

                userTotalPoints[user.Key] = totalPoints;
            }

            int bestCandidatePoints = userTotalPoints.Values.Max();
            string bestCandidate = string.Empty;

            foreach (var item in userTotalPoints)
            {
                if (userTotalPoints[item.Key] == bestCandidatePoints)
                {
                    bestCandidate = item.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contest in users[user.Key].Contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static string[] ReadContestInfo()
        {
            return Console.ReadLine()
                .Split(':')
                .ToArray();
        }

        private static string[] ReadSubmission()
        {
            return Console.ReadLine()
                .Split("=>")
                .ToArray();
        }
    }
}
