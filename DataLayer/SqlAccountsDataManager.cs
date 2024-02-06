using LogicielAspProject.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.DataLayer
{
    public class SqlAccountsDataManager : IAccountDataManager
    {
        private readonly DatabaseConnection _dbConnection;

        public SqlAccountsDataManager()
        {
            _dbConnection = new DatabaseConnection();
        }

        public void AddCompte(Compte compte)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Compte (username, password, role) VALUES (@username, @password, @role)", connection);
                command.Parameters.AddWithValue("@username", compte.Username);
                command.Parameters.AddWithValue("@password", compte.Password );
                command.Parameters.AddWithValue("@role", compte.Role);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCompte(int id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Compte WHERE compteID = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public List<Compte> GetAllComptes()
        {
            var comptes = new List<Compte>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Compte", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comptes.Add(new Compte
                        {
                            idCompte = reader.GetInt32("compteID"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Role = reader.GetString("role")
                        });
                    }
                }
            }
            return comptes;
        }

        public string[] GetAllRoles()
        {
            var roles = new List<string>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT DISTINCT role FROM Compte", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString("role"));
                    }
                }
            }
            return roles.ToArray();
        }

        public string[] GetRolesForUser(string username)
        {
            var roles = new List<string>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT role FROM Compte WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString("role"));
                    }
                }
            }
            return roles.ToArray();
        }



        public Compte GetCompte(int id)
        {
            Compte compte = null;
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Compte WHERE compteID = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        compte = new Compte
                        {
                            idCompte = reader.GetInt32("compteID"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Role = reader.GetString("role")
                        };
                    }
                }
            }
            return compte;
        }

        public Compte GetCompteByUsername(string username)
        {
            Compte compte = null;
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Compte WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        compte = new Compte
                        {
                            idCompte = reader.GetInt32("compteID"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Role = reader.GetString("role")
                        };
                    }
                }
            }
            return compte;
        }



        public bool IsUserInRole(string role)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Compte WHERE role = @role ", connection);

                command.Parameters.AddWithValue("@role", role);
                var res = command.ExecuteScalar();
                return res != null;
            }
        }

        public void UpdateCompte(Compte compte)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Compte SET username = @username, password = @password, role = @role WHERE compteID = @id", connection);
                command.Parameters.AddWithValue("@id", compte.idCompte);
                command.Parameters.AddWithValue("@username", compte.Username);
                command.Parameters.AddWithValue("@password", compte.Password); // Remember to hash and salt the password
                command.Parameters.AddWithValue("@role", compte.Role);
                command.ExecuteNonQuery();
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Compte WHERE username = @username AND password = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password); // Remember to hash and salt the password
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

    }
}