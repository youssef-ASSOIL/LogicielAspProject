using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace LogicielAspProject.Models
{
    
        public class Resource
        {
            public Date DateDelevarison { get; set; }
            public Fournisseur Fournisseur { get; set; }
            public int WarrantyDuration { get; set; }
            public ResourceType ResourceType { get; set; }
            public int UniqueCode { get; set; }
        }
    
}