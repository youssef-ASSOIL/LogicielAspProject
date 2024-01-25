using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Fournisseur
    {
        private string adresse { get; set; }
        private string email { get; set; }
        private List<Offre> offres { get; set; } // Assuming 'Offre' is a defined class elsewhere
        private string nom { get; set; }
        private string telephone { get; set; }

        public Fournisseur()
        {
            offres = new List<Offre>();
        }
    }
}