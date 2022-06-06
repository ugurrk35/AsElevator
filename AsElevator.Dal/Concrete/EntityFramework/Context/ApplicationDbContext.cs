using AsElevator.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Dal.Concrete.EntityFramework.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-8I58UG8\\SQLEXPRESS;Database=AsElevator;Trusted_Connection=True;");
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductWithCategory> ProductWithCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductWithCategory>()
                .HasKey(t => new { t.CategoryID, t.ProductID });

            builder.Entity<ProductWithCategory>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductWithCategories)
                .HasForeignKey(pt => pt.ProductID);

            builder.Entity<ProductWithCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.ProductWithCategories)
                .HasForeignKey(pt => pt.CategoryID);

            builder.Entity<Category>()
                .HasIndex(u => u.Name)
                .IsUnique();        
        }
    }
}
