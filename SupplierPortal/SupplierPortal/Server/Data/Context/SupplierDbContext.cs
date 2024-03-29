﻿using Microsoft.EntityFrameworkCore;
using SupplierPortal.Shared.Models;

namespace SupplierPortal.Server.Data.Context
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasData(
                new Supplier()
                {
                    Id = Guid.NewGuid(), Name = "XYZ", Company = "GetTechLimited", Email = "gt@gt.com"
                },
                new Supplier()
                {
                    Id = Guid.NewGuid(), Name = "XYZ", Company = "Cleaning Limited", Email = "clean@clean.com"
                });
        }
    }
}
