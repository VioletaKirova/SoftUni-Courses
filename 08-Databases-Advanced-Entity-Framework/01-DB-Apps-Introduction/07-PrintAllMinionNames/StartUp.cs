using _01_InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07_PrintAllMinionNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> minions = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                GetMinionsNames(minions, connection);
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - 1 - i]);
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }

        private static void GetMinionsNames(List<string> minions, SqlConnection connection)
        {
            string minionsQuery = "SELECT Name FROM Minions";

            using (SqlCommand command = new SqlCommand(minionsQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader[0]);
                    }
                }
            }
        }
    }
}
