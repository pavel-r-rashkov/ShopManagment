using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Data
{
    public class ProductDelivery : IEntity
    {
        public int ProductDeliveryId { get; set; }

        public int DeliveryQuantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int DeliveryId { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
