using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Data
{
    public class Product : IEntity
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
            this.Quantity = 0;
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
