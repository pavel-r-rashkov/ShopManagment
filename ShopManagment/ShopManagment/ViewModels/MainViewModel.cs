using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.DeliveryViewModels;
using ShopManagment.ViewModels.ProductViewModels;
using ShopManagment.ViewModels.SaleViewModels;

namespace ShopManagment.ViewModels
{
    public class MainViewModel
    {
        private IShopData shopData;

        public MainViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.Tabs = new List<ViewModelBase>()
            {
                new ProductsListViewModel(this.shopData),
                new DeliveriesListViewModel(this.shopData),
                new CreateSaleViewModel(this.shopData)
            };
        }

        public IEnumerable<ViewModelBase> Tabs { get; set; }
    }
}
