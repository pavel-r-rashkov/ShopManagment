using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Data
{
    public class ProductCategory : IEntity
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
