using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicielAspProject.BuisnessLayer
{
    internal interface IFournisseurManager
    {
        bool AddFournisseur(Account account);
        void DeleteFournisseur(string id);
        List<Fournisseur> GetFournisseur();


        void UpdateFournisseur(string id, Account account);
    }
}
