using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class EShopEntities : DbContext
    {
        public EShopEntities() : base("EShopEntities")
        {
            Database.SetInitializer(new ContextInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //  modelBuilder.Entity<Product>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<Product>().HasKey<string>(u => u.Id);
            //modelBuilder.Entity<Product>().Property(u => u.Id).HasColumnType("int");
            //modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("nvarchar(max)");
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
