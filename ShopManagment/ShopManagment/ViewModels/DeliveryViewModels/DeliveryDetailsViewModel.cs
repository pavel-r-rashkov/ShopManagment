using System;
using System.Collections.Generic;
using ShopManagment.ViewModels.ProductDeliveryViewModels;

namespace ShopManagment.ViewModels.DeliveryViewModels
{
    public class DeliveryDetailsViewModel
    {
        public string DeliverySource { get; set; }

        public string Description { get; set; }

        public DateTime DeliveryDate { get; set; }

        public virtual ICollection<ProductDeliveryPreviewViewModel> ProductDeliveries { get; set; }
    }
}
