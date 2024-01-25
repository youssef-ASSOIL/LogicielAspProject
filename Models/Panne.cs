using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Panne
    {
        public FrequencePanne Frequence { get; set; }
        public int IdPanne { get; set; }
        public Resource Ressource { get; set; }
        public OrderPanne TypePanne { get; set; }
    }
}