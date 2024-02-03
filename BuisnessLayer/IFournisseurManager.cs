using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicielAspProject.BuisnessLayer
{
    public interface IFournisseurManager
    {
        bool AddFournisseur(Fournisseur fournisseur, Compte compte);
        void DeleteFournisseur(int id);
        List<Fournisseur> GetFournisseur();
        Fournisseur GetFournisseurById(int id);

        void UpdateFournisseur(int id, Fournisseur fournisseur);
    }
}
