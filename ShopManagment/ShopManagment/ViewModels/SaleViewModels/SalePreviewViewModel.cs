using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.ViewModels.SaleViewModels
{
    public class SalePreviewViewModel
    {
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; }

        public int QuantitySold { get; set; }

        public virtual ProductPreviewViewModel Product { get; set; }
    }
}
