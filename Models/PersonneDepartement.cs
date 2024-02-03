using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class PersonneDepartement
    {
        public string Nom { get; set; }
        public string NomDepartement { get; set; }
        public string Prenom { get; set; }
        public int PersonneDepartementID { get; set; }

        // Reference to Compte
        public Compte Compte { get; set; }
    }
}