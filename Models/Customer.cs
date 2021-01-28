using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wypozyczalnia_sprzetu_budowlanego.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Renting = new HashSet<Renting>();
        }

        public int IdCustomer { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerTel { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Renting> Renting { get; set; }
    }
}
