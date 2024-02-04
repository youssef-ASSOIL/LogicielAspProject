using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Panne
    {
        public Frequence Frequence { get; set; }
        public int IdPanne { get; set; }
        public Resource Ressource { get; set; }
        //public OrderPanne TypePanne { get; set; }
        public TypePanne TypePanne { get; set; } // Property for TypePanne

        public string Constat { get; set; } // varchar(50)
        public DateTime DatePanne { get; set; } // datetime
        public Decision Decision { get; set; } // int, enum mapping
        public string Explication { get; set; } // Ensure this property exists

        public int? RessourceID { get; set; } // Ensure this property exists. It's nullable, assuming it can be null in the database.


    }
}