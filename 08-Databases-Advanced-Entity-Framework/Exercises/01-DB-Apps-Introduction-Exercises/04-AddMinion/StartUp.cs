using _01_InitialSetup;
using System;
using System.Data.SqlClient;

namespace _04_AddMinion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTownName = minionInfo[3];

            string villainName = villainInfo[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownId(minionTownName, connection);

                if (townId == null)
                {
                    AddTown(minionTownName, connection);
                }

                townId = GetTownId(minionTownName, connection);

                AddMinion(minionName, minionAge, townId, connection);

                int? villainId = GetVillainId(villainName, connection);

                if (villainId == null)
                {
                    AddVillain(villainName, connection);
                }

                villainId = GetVillainId(villainName, connection);
                int minionId = GetMinionId(minionName, connection);
                MakeMinionServant(villainId, villainName, minionId, minionName, connection);
            }
        }

        private static void MakeMinionServant(int? villainId, string villainName, int minionId, string minionName, SqlConnection connection)
        {
            string minionVillainQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(minionVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);

                command.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static int GetMinionId(string minionName, SqlConnection connection)
        {
            string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(minionIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);

                return (int)command.ExecuteScalar();
            }
        }

        private static void AddVillain(string villainName, SqlConnection connection)
        {
            string villainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(villainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);

                command.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static int? GetVillainId(string villainName, SqlConnection connection)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(villainIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);

                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(string minionName, int minionAge, int? townId, SqlConnection connection)
        {
            string minionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(minionQuery, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static void AddTown(string minionTownName, SqlConnection connection)
        {
            string townIdQuery = "INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(townIdQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", minionTownName);

                command.ExecuteNonQuery();

                Console.WriteLine($"Town {minionTownName} was added to the database.");
            }
        }

        private static int? GetTownId(string minionTownName, SqlConnection connection)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";

            using (SqlCommand command = new SqlCommand(townIdQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", minionTownName);

                return (int?)command.ExecuteScalar();
            }
        }
    }
}
