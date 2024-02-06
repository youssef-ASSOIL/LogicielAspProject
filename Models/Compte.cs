using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.Models
{
    public class Compte
    {
        public string Username { get; set; } // Username should typically be a string rather than an int
        public string Password { get; set; } // Password should also be a string and stored securely
        public string Role { get; set; }

        public int idCompte {  get; set; } 

        // Constructors, methods, and other functionality would be added here.
        // Ensure to hash and salt the password rather than storing it in plain text.
    }
}