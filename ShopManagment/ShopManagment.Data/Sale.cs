using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Data
{
    public class Sale : IEntity
    {
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; }

        public int QuantitySold { get; set; }

        public int ProductId { get; set; }  

        public virtual Product Product { get; set; }
    }
}
