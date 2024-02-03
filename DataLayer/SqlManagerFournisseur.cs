using System;
using System.Data;
using System.Data.SqlClient;

namespace LogicielAspProject.DataLayer
{
    public class SqlManagerFournisseur
    {
        private readonly SqlConnection connection;

        public SqlManagerFournisseur()
        {
            string connectionString = @"Server=35.203.77.255;Database=your_database_name;User Id=admin;Password=Admin1234;";
            connection = new SqlConnection(connectionString);
        }

        private void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            SqlCommand cmd = new SqlCommand(query, connection);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        
    }
}
