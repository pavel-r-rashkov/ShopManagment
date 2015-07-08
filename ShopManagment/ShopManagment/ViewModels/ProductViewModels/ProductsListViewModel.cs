using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopManagment.DataAccess.Interfaces;
using AutoMapper;
using ShopManagment.Commands;

namespace ShopManagment.ViewModels.ProductViewModels
{
    public class ProductsListViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private ICommand editProductCommand;
        private ICommand showProductDetailsCommand;

        public ProductsListViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.Products = Mapper.Map<ObservableCollection<ProductPreviewViewModel>>(this.shopData.ProductRepository.Get());
        }

        public ObservableCollection<ProductPreviewViewModel> Products { get; set; }

        public ProductPreviewViewModel SelectedProduct { get; set; }

        public ICommand EditProductCommand
        {
            get
            {
                if (this.editProductCommand == null)
                {
                    this.editProductCommand = new RelayCommand(
                            this.ShowEditProductWindow,
                            this.ProductIsSelected
                        );
                }
                return this.editProductCommand;   
            }
        }

        public ICommand ShowProductDetailsCommand
        {
            get
            {
                if (this.showProductDetailsCommand == null)
                {
                    this.showProductDetailsCommand = new RelayCommand(
                            this.ShowProductDetailsWindow,
                            this.ProductIsSelected
                        );
                }
                return this.showProductDetailsCommand;
            }
        }

        private bool ProductIsSelected()
        {
            return this.SelectedProduct != null;
        }

        private void ShowEditProductWindow()
        {
            
        }

        private void ShowProductDetailsWindow()
        {
            
        }
    }
}
