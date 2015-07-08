using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.Data;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.ViewModels.SaleViewModels
{
    public class SaleDetailsViewModel
    {
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; }

        public int QuantitySold { get; set; }

        public int ProductId { get; set; }

        public virtual ProductDetailsViewModel Product { get; set; }
    }
}
