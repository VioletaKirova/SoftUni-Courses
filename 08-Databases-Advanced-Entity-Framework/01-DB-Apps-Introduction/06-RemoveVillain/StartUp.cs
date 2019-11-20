using _01_InitialSetup;
using System;
using System.Data.SqlClient;

namespace _06_RemoveVillain
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainName = GetVillainName(id, connection);

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                ReleaseMinions(villainName, id, connection);
            }
        }

        private static void ReleaseMinions(string villainName, int id, SqlConnection connection)
        {
            int deletedMinions = CountDeletedFromMinionsVillains(id, connection);
            DeleteVillain(villainName, id, connection);
            Console.WriteLine($"{deletedMinions} minions were released.");
        }

        private static void DeleteVillain(string villainName, int id, SqlConnection connection)
        {
            string deleteFromMinionsVillainsQuery = @"DELETE FROM Villains
      WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteFromMinionsVillainsQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);

                command.ExecuteNonQuery();
            }

            Console.WriteLine($"{villainName} was deleted.");
        }

        private static int CountDeletedFromMinionsVillains(int id, SqlConnection connection)
        {
            string deleteFromMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteFromMinionsVillainsQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);

                return command.ExecuteNonQuery();
            }
        }

        private static string GetVillainName(int id, SqlConnection connection)
        {
            string villainQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(villainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);

                return (string)command.ExecuteScalar();
            }
        }
    }
}
