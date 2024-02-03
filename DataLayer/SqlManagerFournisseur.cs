using LogicielAspProject.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Security.Principal;
using System;

public class SqlManagerFournisseur
{
    SqlConnection connection = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    public SqlManagerFournisseur()
    {
        connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\source\repos\Esisa2024\4emeAnnee\SectionB\WebApplication5\WebApplication5\App_Data\webapplication5.mdf;";
        if (connection.State == ConnectionState.Closed)
            connection.Open();
        cmd.Connection = connection;
    }

    public void AddFournisseur(Fournisseur fournisseur, int compteID)
    {
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
    public void UpdateFournisseur(Fournisseur fournisseur,int id )
    {
        cmd.CommandText = $@"UPDATE Fournisseur SET 
                                  adresse = '{fournisseur.adresse}', 
                                  email = '{fournisseur.email}', 
                                  gerant = '{fournisseur.gerant}', 
                                  nomSociete = '{fournisseur.nomSociete}', 
                                  telephone = '{fournisseur.telephone}' 
                                  WHERE fournisseurID = {id}";
        cmd.ExecuteNonQuery();
    }
    public void DeleteFournisseur(int fournisseurID)
    {
        int compteID;

        using (SqlCommand cmd = new SqlCommand($"SELECT compteID FROM Fournisseur WHERE fournisseurID = {fournisseurID}", connection))
        {
            compteID = (int)cmd.ExecuteScalar();
        }

        // Delete the supplier
        cmd.CommandText = $"DELETE FROM Fournisseur WHERE fournisseurID = {fournisseurID}";
        cmd.ExecuteNonQuery();

        // Delete the associated account
        cmd.CommandText = $"DELETE FROM Compte WHERE compteID = {compteID}";
        cmd.ExecuteNonQuery();
    }


    public List<Fournisseur> GetFournisseurs()
    {
        List<Fournisseur> fournisseurs = new List<Fournisseur>();

        cmd.CommandText = "SELECT * FROM Fournisseur";
        using (SqlDataReader reader = cmd.ExecuteReader())
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

        return fournisseurs;
    }
    public Fournisseur GetFournisseurByID(int id)
    {
        cmd.CommandText = $"SELECT * FROM Fournisseur WHERE fournisseurID = {id}";

        using (SqlDataReader reader = cmd.ExecuteReader())
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

        // Return null if no fournisseur found with the specified ID
        return null;
    }

}
