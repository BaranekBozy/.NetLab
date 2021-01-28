using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wypozyczalnia_sprzetu_budowlanego.Models
{
    public partial class Tool
    {
        public Tool()
        {
            Renting = new HashSet<Renting>();
        }

        public int IdTool { get; set; }
        public int CategoryId { get; set; }
        public string Nazwa { get; set; }
        public string Producent { get; set; }
        public string Model { get; set; }
        public int Cena { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Renting> Renting { get; set; }
    }
}
