using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.DataLayer
{
    public class SqlManagerFournisseur
    {

        public SqlManagerFournisseur()
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=D:\source\repos\Esisa2024\4emeAnnee\SectionB\WebApplication5\WebApplication5\App_Data\webapplication5.mdf;";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            cmd.Connection = connection;

            public void AddFournisseur(Fournisseur fournisseur)
            {
                {
                    cmd.CommandText = $@"insert into Fournisseur (username,password,role) 
                values('{account.UserName}','{account.Password}','{account.Role}')";
                    cmd.ExecuteNonQuery();
                }

                public void DeleteFournisseur(string id)
                {
                    cmd.CommandText = $@"select idstudent from accounts where username like '{id}';";
                    int idStudent = (int)cmd.ExecuteScalar();
                    cmd.CommandText = $@"delete from accounts where username like '{id}'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $@"delete from student where id like {idStudent}";
                    cmd.ExecuteNonQuery();
                }
                public void UpdateFournisseur(string id, Fournisseur fournisseur)
                {
                    cmd.CommandText = $@"update accounts set password='{account.Password}',
                                role='{account.Role}'
                                where username like '{id}'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $@"update student set name='{account.Student.Name}',
                                        firstname='{account.Student.FirstName}',
                                        email='{account.Student.Email}',
                                        phone='{account.Student.Phone}'
                                where id= {account.Student.Id}";
                    cmd.ExecuteNonQuery();

                }

            }

        }
    }