using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Imprimante :Resource
    {
        public int Marque { get; set; }
        public int Resolution { get; set; }
        public int VitesseImpression { get; set; }
    }
}