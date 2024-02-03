using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Administratif:PersonneDepartement
    {
        public string Fonction { get; set; }
        public int AdministratifID { get; set; }
    }
}