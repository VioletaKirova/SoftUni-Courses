using _01_InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08_IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                foreach (var id in minionIds)
                {
                    IncrementAge(id, connection);
                }

                PrintMinions(connection);
            }
        }

        private static void PrintMinions(SqlConnection connection)
        {
            string minionsQuery = "SELECT Name, Age FROM Minions";

            using (SqlCommand command = new SqlCommand(minionsQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }
        }

        private static void IncrementAge(int id, SqlConnection connection)
        {
            string minionQuery = @" UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(minionQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
