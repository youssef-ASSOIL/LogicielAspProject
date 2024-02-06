using LogicielAspProject.Models;
using System.Collections.Generic;
using System.Security.Principal;

namespace LogicielAspProject.DataLayer
{
    public interface IAccountDataManager
    {
        Compte GetCompte(int id);
        Compte GetCompteByUsername(string username);
        void AddCompte(Compte compte);
        void UpdateCompte(Compte compte);
        void DeleteCompte(int id);
        bool ValidateCredentials(string username, string password);
        bool IsUserInRole(string role);
        List<Compte> GetAllComptes();
        string[] GetAllRoles();
        string[] GetRolesForUser(string username);
    }
}