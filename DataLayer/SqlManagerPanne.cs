using System;
using System.Data;
using System.Data.SqlClient;

namespace LogicielAspProject.DataLayer
{
    public class SqlManagerPanne
    {
        private readonly SqlConnection connection;

        public SqlManagerPanne()
        {
            string connectionString = @"Server=35.203.77.255;Database=gestionressources;User Id=admin;Password=Admin1234;";
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
        public bool AddPanne(Panne panne)
        {
            const string query = "INSERT INTO Panne (constat, datePanne, explication, ressourceID, typepanne, decision, frequence) " +
                                "VALUES (@Constat, @DatePanne, @Explication, @RessourceID, @TypePanne, @Decision, @Frequence)";
            
            var command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Constat", panne.Constat);
            command.Parameters.AddWithValue("@DatePanne", panne.DatePanne);
            command.Parameters.AddWithValue("@Explication", panne.Explication);
            command.Parameters.AddWithValue("@RessourceID", panne.RessourceID);
            command.Parameters.AddWithValue("@TypePanne", (int)panne.Type);
            command.Parameters.AddWithValue("@Decision", (int)panne.Decision);
            command.Parameters.AddWithValue("@Frequence", (int)panne.Frequence);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            int result = command.ExecuteNonQuery();
            return result > 0;
        }
        public bool DeletePanne(int panneID)
        {
            const string query = "DELETE FROM Panne WHERE panneID = @PanneID";
            
            var command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@PanneID", panneID);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            int result = command.ExecuteNonQuery();
            return result > 0;
        }

         public bool UpdatePanne(Panne panne)
        {
            const string query = "UPDATE Panne SET constat = @Constat, datePanne = @DatePanne, explication = @Explication, " +
                                "ressourceID = @RessourceID, typepanne = @TypePanne, decision = @Decision, frequence = @Frequence " +
                                "WHERE panneID = @PanneID";
            
            var command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Constat", panne.Constat);
            command.Parameters.AddWithValue("@DatePanne", panne.DatePanne);
            command.Parameters.AddWithValue("@Explication", panne.Explication);
            command.Parameters.AddWithValue("@RessourceID", panne.RessourceID);
            command.Parameters.AddWithValue("@TypePanne", (int)panne.Type);
            command.Parameters.AddWithValue("@Decision", (int)panne.Decision);
            command.Parameters.AddWithValue("@Frequence", (int)panne.Frequence);
            command.Parameters.AddWithValue("@PanneID", panne.PanneId);

            int result = command.ExecuteNonQuery();
            return result > 0;
        }
         public Panne GetPanne(int panneID)
        {
            Panne panne = null;
            const string query = "SELECT * FROM Panne WHERE panneID = @PanneID";
            
            var command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@PanneID", panneID);

             MySqlDataReader reader = command.ExecuteReader(); 
                if (reader.Read())
                {
                    panne = new Panne
                    {
                        PanneId = reader.GetInt32("panneID"),
                        Constat = reader.IsDBNull(reader.GetOrdinal("constat")) ? null : reader.GetString("constat"),
                        DatePanne = reader.GetDateTime("datePanne"),
                        Explication = reader.IsDBNull(reader.GetOrdinal("explication")) ? null : reader.GetString("explication"),
                        RessourceID = reader.IsDBNull(reader.GetOrdinal("ressourceID")) ? (int?)null : reader.GetInt32("ressourceID"),
                        Type = (TypePanne)reader.GetInt32("typepanne"),
                        Decision = (Decision)reader.GetInt32("decision"),
                        Frequence = (Frequence)reader.GetInt32("frequence")
                    };
                }
            

            return panne;
        }
        public bool ResolvePanne(int panneID)
        {
            const string query = "UPDATE Panne SET decision = @Decision WHERE panneID = @PanneID";
            
            var command = new MySqlCommand(query, _connection);
            // Assuming the decision to resolve the panne is to set a specific decision status
            command.Parameters.AddWithValue("@Decision", (int)Decision.Reparer); // Example decision
            command.Parameters.AddWithValue("@PanneID", panneID);

            int result = command.ExecuteNonQuery();
            return result > 0;
        }
        public List<Panne> ListAllPannes()
    {
        List<Panne> pannes = new List<Panne>();
        const string query = "SELECT * FROM Panne";
        
        var command = new MySqlCommand(query, _connection);

        MySqlDataReader reader = command.ExecuteReader(); 
            while (reader.Read())
            {
                var panne = new Panne
                {
                    PanneId = reader.GetInt32("panneID"),
                    Constat = reader.IsDBNull(reader.GetOrdinal("constat")) ? null : reader.GetString("constat"),
                    DatePanne = reader.GetDateTime("datePanne"),
                    Explication = reader.IsDBNull(reader.GetOrdinal("explication")) ? null : reader.GetString("explication"),
                    RessourceID = reader.IsDBNull(reader.GetOrdinal("ressourceID")) ? (int?)null : reader.GetInt32("ressourceID"),
                    Type = (TypePanne)reader.GetInt32("typepanne"),
                    Decision = (Decision)reader.GetInt32("decision"),
                    Frequence = (Frequence)reader.GetInt32("frequence")
                };
                pannes.Add(panne);
            }
        

        return pannes;
    }

    public List<Panne> ListPannesByFrequence(Frequence frequence)
    {
        List<Panne> pannes = new List<Panne>();
        const string query = "SELECT * FROM Panne WHERE frequence = @Frequence";
        
        var command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@Frequence", (int)frequence);

        MySqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                var panne = new Panne
                {
                    PanneId = reader.GetInt32("panneID"),
                    Constat = reader.IsDBNull(reader.GetOrdinal("constat")) ? null : reader.GetString("constat"),
                    DatePanne = reader.GetDateTime("datePanne"),
                    Explication = reader.IsDBNull(reader.GetOrdinal("explication")) ? null : reader.GetString("explication"),
                    RessourceID = reader.IsDBNull(reader.GetOrdinal("ressourceID")) ? (int?)null : reader.GetInt32("ressourceID"),
                    Type = (TypePanne)reader.GetInt32("typepanne"),
                    Decision = (Decision)reader.GetInt32("decision"),
                    Frequence = (Frequence)reader.GetInt32("frequence")
                };
                pannes.Add(panne);
            }
        }
        finally
        {
            reader.Close();
        }

        return pannes;
    }

    public List<Panne> ListPannesByType(TypePanne type)
    {
        List<Panne> pannes = new List<Panne>();
        const string query = "SELECT * FROM Panne WHERE typepanne = @TypePanne";
        
        var command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@TypePanne", (int)type);

        MySqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                var panne = new Panne
                {
                    PanneId = reader.GetInt32("panneID"),
                    Constat = reader.IsDBNull(reader.GetOrdinal("constat")) ? null : reader.GetString("constat"),
                    DatePanne = reader.GetDateTime("datePanne"),
                    Explication = reader.IsDBNull(reader.GetOrdinal("explication")) ? null : reader.GetString("explication"),
                    RessourceID = reader.IsDBNull(reader.GetOrdinal("ressourceID")) ? (int?)null : reader.GetInt32("ressourceID"),
                    Type = (TypePanne)reader.GetInt32("typepanne"),
                    Decision = (Decision)reader.GetInt32("decision"),
                    Frequence = (Frequence)reader.GetInt32("frequence")
                };
                pannes.Add(panne);
            }
        }
        finally
        {
            reader.Close();
        }

        return pannes;
    }

    }
}
