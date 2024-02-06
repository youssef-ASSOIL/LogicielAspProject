using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.BuisnessLayer
{
    public class FournisseurManager : IFournisseurManager
    {
        SqlManagerFournisseur db = new SqlManagerFournisseur();



        public bool AddFournisseur(Fournisseur fournisseur, Compte compte)
            {
                
                db.AddFournisseur(fournisseur,  compte.idCompte);
                return true;

            }
        public void DeleteFournisseur(int id)
            {
                db.DeleteFournisseur(id);

            }
        public List<Fournisseur> GetFournisseur()
            {
                
             return db.GetFournisseurs();
            }


          public  void UpdateFournisseur(int id, Fournisseur fournisseur)
            {
                db.UpdateFournisseur( fournisseur,id);
            }
        public Fournisseur GetFournisseurById(int id)
        {
            return db.GetFournisseurByID(id);
        }
    }
    }
