using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Data
{
    public class Delivery : IEntity
    {
        public Delivery()
        {
            this.ProductDeliveries = new HashSet<ProductDelivery>();    
        }

        public int DeliveryId { get; set; }

        public string DeliverySource { get; set; }

        public string Description { get; set; }

        public DateTime DeliveryDate { get; set; }

        public virtual ICollection<ProductDelivery> ProductDeliveries { get; set; }
    }
}
