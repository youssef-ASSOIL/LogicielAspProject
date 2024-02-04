using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.BuisnessLayer
{
    public interface IEnseignantManager
    {
        bool AddEnseignant(Enseignant enseignant, Compte compte);
        void DeleteEnseignant(int id);
        List<Enseignant> GetEnseignants();
        Enseignant  GetEnseignantById(int id);

        void UpdateEnseignant(int id, Enseignant enseignant);
    }
}