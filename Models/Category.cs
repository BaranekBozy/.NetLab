using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wypozyczalnia_sprzetu_budowlanego.Models
{
    public partial class Category
    {
        public Category()
        {
            Tool = new HashSet<Tool>();
        }

        public int IdCategory { get; set; }
        public string NazwaKategorii { get; set; }

        public virtual ICollection<Tool> Tool { get; set; }
    }
}
