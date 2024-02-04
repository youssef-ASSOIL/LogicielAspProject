using LogicielAspProject.DataLayer;
using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.BuisnessLayer
{
    public class EnseignantManager : IEnseignantManager
    {
        SqlManagerEnseignant db = new SqlManagerEnseignant();

        public bool AddEnseignant(Enseignant enseignant, Compte compte)
        {
            db.AddEnseignant(enseignant,compte.idCompte);
            return true;
        }

        public void DeleteEnseignant(int id)
        {
            db.DeleteEnseignant(id);
        }

        public Enseignant GetEnseignantById(int id)
        {
           return db.GetEnseignantByID(id);
        }

        public List<Enseignant> GetEnseignants()
        {
            return db.GetEnseignants();
        }

        public void UpdateEnseignant(int id, Enseignant enseignant)
        {
           db.UpdateEnseignant(enseignant,id);  
        }
    }
}