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
    public class ShopData : IShopData
    {
        private DbContext context;
        private bool disposed;
        private IProductCategoryRepository productCategoryRepository;
        private IProductRepository productRepository;
        private IDeliveryRepository deliveryRepository;
        private IProductDeliveryRepository productDeliveryRepository;
        private ISaleRepository saleRepository;

        public ShopData(DbContext context)
        {
            this.context = context;
        }

        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (this.productCategoryRepository == null)
                {
                    this.productCategoryRepository = new ProductCategoryRepository(this.context);
                }
                return this.productCategoryRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(this.context);
                }
                return this.productRepository;
            }
        }

        public IDeliveryRepository DeliveryRepository
        {
            get
            {
                if (this.deliveryRepository == null)
                {
                    this.deliveryRepository = new DeliveryRepository(this.context);
                }
                return this.deliveryRepository;
            }
        }

        public IProductDeliveryRepository ProductDeliveryRepository
        {
            get
            {
                if (this.productDeliveryRepository == null)
                {
                    this.productDeliveryRepository = new ProductDeliveryRepository(this.context);
                }
                return this.productDeliveryRepository;
            }
        }

        public ISaleRepository SaleRepository
        {
            get
            {
                if (this.saleRepository == null)
                {
                    this.saleRepository = new SaleRepository(this.context);
                }
                return this.saleRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
