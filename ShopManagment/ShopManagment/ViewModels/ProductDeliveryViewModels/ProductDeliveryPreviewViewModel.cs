using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.Data;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.ViewModels.ProductDeliveryViewModels
{
    public class ProductDeliveryPreviewViewModel
    {
        public int DeliveryQuantity { get; set; }

        public virtual ProductPreviewViewModel Product { get; set; }
    }
}
