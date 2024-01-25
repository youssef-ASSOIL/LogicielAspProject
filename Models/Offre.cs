using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Offre
    {
        public int DateLivraison { get; set; }
        public int Garantie { get; set; }
        public ReponseOffre ReponseOffre { get; set; }
        public int Total { get; set; }

        // Constructors
        public Offre()
        {
        }
    }
}