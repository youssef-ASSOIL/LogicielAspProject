using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace LogicielAspProject.DataLayer
{
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {

            connectionString = @"Server=35.203.77.255;Database=gestionressources;Uid=admin;Pwd=Admin1234;";
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Successfully connected to the database.");
                return connection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error in connecting to the database: {ex.Message}");
                throw;
            }
        }
    }
}