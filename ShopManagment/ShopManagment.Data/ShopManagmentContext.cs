using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Data
{
    public class ShopManagmentContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<ProductDelivery> ProductDeliveries { get; set; }
    }
}
