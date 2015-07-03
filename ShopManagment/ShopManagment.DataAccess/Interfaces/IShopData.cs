using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.DataAccess.Interfaces
{
    public interface IShopData
    {
        IProductRepository ProductRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }
        IProductDeliveryRepository ProductDeliveryRepository { get; }
        ISaleRepository SaleRepository { get; }
        void Save();
        void Dispose();
    }
}
