using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.Data;
using ShopManagment.DataAccess.Interfaces;

namespace ShopManagment.DataAccess
{
    public class ProductDeliveryRepository : GenericRepository<ProductDelivery>, IProductDeliveryRepository
    {
        public ProductDeliveryRepository(DbContext context)
            :base(context)
        {
        }
    }
}
