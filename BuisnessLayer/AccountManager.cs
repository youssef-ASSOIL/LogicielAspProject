using LogicielAspProject.DataLayer;
using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.BusinessLayer
{
    public class AccountManager : IAccountManager
    {
        IAccountDataManager db = new SqlAccountsDataManager();

        public void AddCompte(Compte compte)
        {
            db.AddCompte(compte);
        }

        public void DeleteCompte(int id)
        {
            db.DeleteCompte(id);
        }

        public Compte GetCompte(int id)
        {
            return db.GetCompte(id);
        }

        public Compte GetCompteByUsername(string username)
        {
            return db.GetCompteByUsername(username);
        }

        public bool IsUserInRole(string role)
        {
            return db.IsUserInRole(role);
        }

        public void UpdateCompte(Compte compte)
        {
            db.UpdateCompte(compte);
        }

        public bool ValidateCredentials(string username, string password)
        {
            return db.ValidateCredentials(username, password);
        }
        public List<Compte> GetAllComptes()
        {
            return db.GetAllComptes();
        }

        public string[] GetAllRoles()
        {
            return db.GetAllRoles();
        }

        public string[] GetRolesForUser(string username)
        {
            return db.GetRolesForUser(username);
        }
    }
}