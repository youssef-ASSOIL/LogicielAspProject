using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Enseignant:PersonneDepartement
    {
        public string Email { get; set; }
        public string NomLaboratoire { get; set; }
        public int EnseignantID { get; set; }
    }
}