using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wypozyczalnia_sprzetu_budowlanego.Models
{
    public partial class baza_sprzetContext : DbContext
    {
        public baza_sprzetContext()
        {
        }

        public baza_sprzetContext(DbContextOptions<baza_sprzetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Renting> Renting { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__E548B6731A0F7ED2");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.NazwaKategorii)
                    .IsRequired()
                    .HasColumnName("nazwa_kategorii")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK__Customer__8CC9BA460F14A790");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTel)
                    .IsRequired()
                    .HasColumnName("numer_tel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Renting>(entity =>
            {
                entity.HasKey(e => e.IdRenting)
                    .HasName("PK__Renting__5B9FC36716996CE5");

                entity.Property(e => e.IdRenting).HasColumnName("id_renting");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.ToolId).HasColumnName("tool_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Renting)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renting_ToCustomer");

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.Renting)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renting_ToTool");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.HasKey(e => e.IdTool)
                    .HasName("PK__Tool__C9346C347522EEAE");

                entity.Property(e => e.IdTool).HasColumnName("id_tool");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Producent)
                    .IsRequired()
                    .HasColumnName("producent")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Tool)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tool_ToCategoty");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
