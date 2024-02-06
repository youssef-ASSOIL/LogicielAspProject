using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicielAspProject.BusinessLayer
{
    internal interface IAccountManager
    {
        Compte GetCompte(int id);
        Compte GetCompteByUsername(string username);
        void AddCompte(Compte compte);
        void UpdateCompte(Compte compte);
        void DeleteCompte(int id);
        bool ValidateCredentials(string username, string password);
        bool IsUserInRole( string role);
        List<Compte> GetAllComptes();
        string[] GetAllRoles();
        string[] GetRolesForUser(string username);
    }
}
