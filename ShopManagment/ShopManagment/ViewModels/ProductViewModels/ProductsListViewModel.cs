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
using ShopManagment.Views.Product;

namespace ShopManagment.ViewModels.ProductViewModels
{
    public class ProductsListViewModel : ViewModelBase
    {
        private IShopData shopData;
        private ICommand editProductCommand;
        private ICommand showProductDetailsCommand;
        private ICommand showProductCreateWindowCommand;

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

        public ICommand ShowProductCreateWindowCommand
        {
            get
            {
                if (this.showProductCreateWindowCommand == null)
                {
                    this.showProductCreateWindowCommand = new RelayCommand(
                            this.ShowProductCreateWindow
                        );
                }
                return this.showProductCreateWindowCommand;
            }
        }

        private bool ProductIsSelected()
        {
            return this.SelectedProduct != null;
        }

        private void ShowEditProductWindow()
        {
            var editProductWindow = new EditProduct(this.SelectedProduct.ProductId);
            editProductWindow.Show();
        }

        private void ShowProductDetailsWindow()
        {
            var productWindow = new ProductDetails(this.SelectedProduct.ProductId);
            productWindow.Show();
        }

        private void ShowProductCreateWindow()
        {
            var createProduct = new CreateProduct();
            createProduct.Show();
        }
    }
}
