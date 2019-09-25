using _01_InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05_ChangeTownNamesCasing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                int affectedRows = UpdateTowns(countryName, connection);

                if (affectedRows == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                PrintTownNames(countryName, connection);
            }
        }

        private static void PrintTownNames(string countryName, SqlConnection connection)
        {
            List<string> townNames = new List<string>();

            string getTownsQuery = @" SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName";

            using (SqlCommand command = new SqlCommand(getTownsQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        townNames.Add((string)reader[0]);
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", townNames)}]");
        }

        private static int UpdateTowns(string countryName, SqlConnection connection)
        {
            string updateTownsQuery = @"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using (SqlCommand command = new SqlCommand(updateTownsQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                return command.ExecuteNonQuery();
            }
        }
    }
}
