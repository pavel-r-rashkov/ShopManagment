using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShopManagment.DataAccess;
using ShopManagment.DataAccess.Interfaces;

namespace ShopManagment.ViewModels.ProductViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        private IShopData shopData;

        public CreateProductViewModel(IShopData shopData)
        {
            this.shopData = shopData;
        }

        
    }
}
