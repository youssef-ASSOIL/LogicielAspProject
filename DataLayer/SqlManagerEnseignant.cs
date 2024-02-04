using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LogicielAspProject.DataLayer
{
    public class SqlManagerEnseignant
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public SqlManagerEnseignant()
        {
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\source\repos\Esisa2024\4emeAnnee\SectionB\WebApplication5\WebApplication5\App_Data\webapplication5.mdf;";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            cmd.Connection = connection;
        }
        public void AddEnseignant(Enseignant enseignant, int compteID)
        {
            // First, add the PersonneDepartement
            cmd.CommandText = @"INSERT INTO PersonneDepartement (nom, nomDepartement, prenom, compteID) 
                        VALUES (@nom, @nomDepartement, @prenom, @compteID);
                        SELECT SCOPE_IDENTITY();";

            cmd.Parameters.AddWithValue("@nom", enseignant.Nom);
            cmd.Parameters.AddWithValue("@nomDepartement", enseignant.NomDepartement);
            cmd.Parameters.AddWithValue("@prenom", enseignant.Prenom);
            cmd.Parameters.AddWithValue("@compteID", compteID);

            int personneDepartementID = Convert.ToInt32(cmd.ExecuteScalar());

            // Now, add the Enseignant
            cmd.CommandText = @"INSERT INTO Enseignant (nomLaboratoire, email, personneDepartementID, compteID) 
                        VALUES (@nomLaboratoire, @email, @personneDepartementID, @compteID)";

            cmd.Parameters.AddWithValue("@nomLaboratoire", enseignant.NomLaboratoire);
            cmd.Parameters.AddWithValue("@email", enseignant.Email);
            cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);

            cmd.ExecuteNonQuery();
        }
        public void UpdateEnseignant(Enseignant enseignant, int personneDepartementID)
        {
            // Update PersonneDepartement
            cmd.CommandText = @"UPDATE PersonneDepartement SET 
                            nom = @nom, 
                            nomDepartement = @nomDepartement, 
                            prenom = @prenom 
                        WHERE personneDepartementID = @personneDepartementID";

            cmd.Parameters.AddWithValue("@nom", enseignant.Nom);
            cmd.Parameters.AddWithValue("@nomDepartement", enseignant.NomDepartement);
            cmd.Parameters.AddWithValue("@prenom", enseignant.Prenom);
            cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);

            cmd.ExecuteNonQuery();

            // Update Enseignant
            cmd.CommandText = @"UPDATE Enseignant SET 
                            nomLaboratoire = @nomLaboratoire, 
                            email = @email 
                        WHERE personneDepartementID = @personneDepartementID";

            cmd.Parameters.AddWithValue("@nomLaboratoire", enseignant.NomLaboratoire);
            cmd.Parameters.AddWithValue("@email", enseignant.Email);

            cmd.ExecuteNonQuery();
        }

        public void DeleteEnseignant(int personneDepartementID)
        {
            // Delete Enseignant
            cmd.CommandText = "DELETE FROM Enseignant WHERE personneDepartementID = @personneDepartementID";
            cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);
            cmd.ExecuteNonQuery();

            // Delete PersonneDepartement
            cmd.CommandText = "DELETE FROM PersonneDepartement WHERE personneDepartementID = @personneDepartementID";
            cmd.ExecuteNonQuery();
        }

        public List<Enseignant> GetEnseignants()
        {
            List<Enseignant> enseignants = new List<Enseignant>();

            cmd.CommandText = "SELECT * FROM Enseignant";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Enseignant enseignant = new Enseignant
                    {
                        NomLaboratoire = Convert.ToString(reader["nomLaboratoire"]),
                        Email = Convert.ToString(reader["email"]),
                        PersonneDepartementID = Convert.ToInt32(reader["personneDepartementID"]),
                        // Add other properties as needed
                    };

                    enseignants.Add(enseignant);
                }
            }

            return enseignants;
        }

        public Enseignant GetEnseignantByID(int personneDepartementID)
        {
            cmd.CommandText = "SELECT * FROM Enseignant WHERE personneDepartementID = @personneDepartementID";
            cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Enseignant enseignant = new Enseignant
                    {
                        NomLaboratoire = Convert.ToString(reader["nomLaboratoire"]),
                        Email = Convert.ToString(reader["email"]),
                        PersonneDepartementID = Convert.ToInt32(reader["personneDepartementID"]),
                        // Add other properties as needed
                    };

                    return enseignant;
                }
            }

            // Return null if no enseignant found with the specified ID
            return null;
        }


    }
}