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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Brand>(x => x
        //           .ToTable("Products")
        //           .Property(entity => entity.Name)
        //           .HasColumnType("string")
        //    );
        //}

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
