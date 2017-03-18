using DAL.Models;
using System;
using System.Collections.Generic;
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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
