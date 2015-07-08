using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.Data;
using ShopManagment.ViewModels.ProductCategoryViewModels;

namespace ShopManagment.ViewModels.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ProductCategoryPreviewViewModel ProductCategory { get; set; }
    }
}
