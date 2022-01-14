using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Musik_Affär.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Brand)
                .HasConversion<string>();

            modelBuilder.Entity<Product>()
                .Property(p => p.Color)
                .HasConversion<string>();

            modelBuilder.Entity<Product>()
                .Property(p => p.Category)
                .HasConversion<string>();

            modelBuilder.Entity<CartProductQty>()
                        .HasAlternateKey(e => new { e.ProductId, e.CartId });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CartProductQty> CartProductQty { get; set; }
    }
}
