using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wypozyczalnia_sprzetu_budowlanego.Models
{
    public partial class Renting
    {
        public int IdRenting { get; set; }
        public int CustomerId { get; set; }
        public int ToolId { get; set; }
        public DateTime Data { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
