using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.DeliveryViewModels;
using ShopManagment.ViewModels.ProductViewModels;
using ShopManagment.ViewModels.SaleViewModels;

namespace ShopManagment.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IShopData shopData;

        public MainViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.Tabs = new ObservableCollection<ViewModelBase>()
            {
                new ProductsListViewModel(this.shopData),
                new DeliveriesListViewModel(this.shopData),
                new CreateSaleViewModel(this.shopData),
                new SalesListViewModel(this.shopData)
            };
        }

        public ObservableCollection<ViewModelBase> Tabs { get; set; }
    }
}
