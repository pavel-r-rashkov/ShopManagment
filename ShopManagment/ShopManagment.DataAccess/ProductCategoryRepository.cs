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
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext context)
            :base(context)
        {
        }
    }
}
