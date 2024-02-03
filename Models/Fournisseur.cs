using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Fournisseur
    {
        public string adresse { get; set; }
        public string email { get; set; }
        public List<Offre> offres { get; set; } // Assuming 'Offre' is a defined class elsewhere
        public string nomSociete { get; set; }
        public string telephone { get; set; }
        public string gerant { get; set; }
        public int idFournisseur{ get; set; }
        public Compte compte { get; set; }
        public Fournisseur()
        {
            offres = new List<Offre>();
        }
    }
}