using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class OrderPanne
    {
        public TypeOrderLogiciel OrderLogiciel { get; set; }
        public Materiel OrderMateriel { get; set; }
    }
}