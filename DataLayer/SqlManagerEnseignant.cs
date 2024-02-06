using LogicielAspProject.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LogicielAspProject.DataLayer
{
    public class SqlManagerEnseignant
    {
        private readonly DatabaseConnection _dbconnection;

        public SqlManagerEnseignant()
        {
            _dbconnection = new DatabaseConnection();
        }

        public void AddEnseignant(Enseignant enseignant, int compteID)
        {
            using (MySqlConnection connection = _dbconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = @"INSERT INTO PersonneDepartement (nom, nomDepartement, prenom, compteID) 
                                        VALUES (@nom, @nomDepartement, @prenom, @compteID);
                                        SELECT LAST_INSERT_ID();";

                    cmd.Parameters.AddWithValue("@nom", enseignant.Nom);
                    cmd.Parameters.AddWithValue("@nomDepartement", enseignant.NomDepartement);
                    cmd.Parameters.AddWithValue("@prenom", enseignant.Prenom);
                    cmd.Parameters.AddWithValue("@compteID", compteID);

                    int personneDepartementID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = @"INSERT INTO Enseignant (nomLaboratoire, email, personneDepartementID, compteID) 
                                        VALUES (@nomLaboratoire, @email, @personneDepartementID, @compteID)";

                    cmd.Parameters.AddWithValue("@nomLaboratoire", enseignant.NomLaboratoire);
                    cmd.Parameters.AddWithValue("@email", enseignant.Email);
                    cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEnseignant(Enseignant enseignant, int personneDepartementID)
        {
            using (MySqlConnection connection = _dbconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;

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

                    cmd.CommandText = @"UPDATE Enseignant SET 
                                        nomLaboratoire = @nomLaboratoire, 
                                        email = @email 
                                        WHERE personneDepartementID = @personneDepartementID";

                    cmd.Parameters.AddWithValue("@nomLaboratoire", enseignant.NomLaboratoire);
                    cmd.Parameters.AddWithValue("@email", enseignant.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEnseignant(int personneDepartementID)
        {
            using (MySqlConnection connection = _dbconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;

                    cmd.CommandText = "DELETE FROM Enseignant WHERE personneDepartementID = @personneDepartementID";
                    cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM PersonneDepartement WHERE personneDepartementID = @personneDepartementID";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Enseignant> GetEnseignants()
        {
            List<Enseignant> enseignants = new List<Enseignant>();

            using (MySqlConnection connection = _dbconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Enseignant", connection))
                {
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
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
                }
            }

            return enseignants;
        }

        public Enseignant GetEnseignantByID(int personneDepartementID)
        {
            using (MySqlConnection connection = _dbconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Enseignant WHERE personneDepartementID = @personneDepartementID", connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@personneDepartementID", personneDepartementID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
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
                }
            }

            // Return null if no enseignant found with the specified ID
            return null;
        }
    }
}
