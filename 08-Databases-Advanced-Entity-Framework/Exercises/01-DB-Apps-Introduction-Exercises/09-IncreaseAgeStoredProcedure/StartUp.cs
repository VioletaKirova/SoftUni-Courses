using _01_InitialSetup;
using System;
using System.Data.SqlClient;

namespace _09_IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                IncrementAge(id, connection);
            }
        }

        private static void IncrementAge(int id, SqlConnection connection)
        {
            string minionQuery = "EXEC usp_GetOlder @Id";

            using (SqlCommand command = new SqlCommand(minionQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                }
            }
        }
    }
}
