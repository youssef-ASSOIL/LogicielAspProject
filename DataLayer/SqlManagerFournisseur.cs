using LogicielAspProject.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using LogicielAspProject.DataLayer;

public class SqlManagerFournisseur
{
    private readonly DatabaseConnection _dbconnection;

    public SqlManagerFournisseur()
    {
        _dbconnection = new DatabaseConnection();
    }

    public void AddFournisseur(Fournisseur fournisseur, int compteID)
    {
        using (MySqlConnection connection = _dbconnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Fournisseur (adresse, email, gerant, nomSociete, telephone, compteID) 
                                    VALUES (@adresse, @email, @gerant, @nomSociete, @telephone, @compteID)";

                cmd.Parameters.AddWithValue("@adresse", fournisseur.adresse);
                cmd.Parameters.AddWithValue("@email", fournisseur.email);
                cmd.Parameters.AddWithValue("@gerant", fournisseur.gerant);
                cmd.Parameters.AddWithValue("@nomSociete", fournisseur.nomSociete);
                cmd.Parameters.AddWithValue("@telephone", fournisseur.telephone);
                cmd.Parameters.AddWithValue("@compteID", compteID);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateFournisseur(Fournisseur fournisseur, int id)
    {
        using (MySqlConnection connection = _dbconnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = $@"UPDATE Fournisseur SET 
                                      adresse = '{fournisseur.adresse}', 
                                      email = '{fournisseur.email}', 
                                      gerant = '{fournisseur.gerant}', 
                                      nomSociete = '{fournisseur.nomSociete}', 
                                      telephone = '{fournisseur.telephone}' 
                                      WHERE fournisseurID = {id}";

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteFournisseur(int fournisseurID)
    {
        int compteID;

        using (MySqlConnection connection = _dbconnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand($"SELECT compteID FROM Fournisseur WHERE fournisseurID = {fournisseurID}", connection))
            {
                connection.Open();
                compteID = (int)cmd.ExecuteScalar();
            }

            // Delete the supplier
            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM Fournisseur WHERE fournisseurID = {fournisseurID}", connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Delete the associated account
            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM Compte WHERE compteID = {compteID}", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Fournisseur> GetFournisseurs()
    {
        List<Fournisseur> fournisseurs = new List<Fournisseur>();

        using (MySqlConnection connection = _dbconnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Fournisseur", connection))
            {
                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fournisseur fournisseur = new Fournisseur
                        {
                            adresse = Convert.ToString(reader["adresse"]),
                            email = Convert.ToString(reader["email"]),
                            gerant = Convert.ToString(reader["gerant"]),
                            nomSociete = Convert.ToString(reader["nomSociete"]),
                            telephone = Convert.ToString(reader["telephone"]),
                        };

                        fournisseurs.Add(fournisseur);
                    }
                }
            }
        }

        return fournisseurs;
    }

    public Fournisseur GetFournisseurByID(int id)
    {
        using (MySqlConnection connection = _dbconnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Fournisseur WHERE fournisseurID = {id}", connection))
            {
                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Fournisseur fournisseur = new Fournisseur
                        {
                            idFournisseur = Convert.ToInt32(reader["fournisseurID"]),
                            adresse = Convert.ToString(reader["adresse"]),
                            email = Convert.ToString(reader["email"]),
                            gerant = Convert.ToString(reader["gerant"]),
                            nomSociete = Convert.ToString(reader["nomSociete"]),
                            telephone = Convert.ToString(reader["telephone"]),
                            compte = new Compte
                            {
                                idCompte = Convert.ToInt32(reader["compteID"])
                            }
                        };

                        // Accessing idCompte from the compte property
                        int idCompte = fournisseur.compte.idCompte;

                        return fournisseur;
                    }
                }
            }
        }

        // Return null if no fournisseur found with the specified ID
        return null;
    }
}
