using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using ShopManagment.Commands;
using ShopManagment.Data;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.ProductCategoryViewModels;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.ViewModels.SaleViewModels
{
    public class CreateSaleViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private ICommand sellCommand;
        private IEnumerable<ProductPreviewViewModel> products;
        private ProductCategoryPreviewViewModel selectedCategory;
        private int quantitySold;
        private string message;

        public CreateSaleViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.Categories = Mapper.Map<IEnumerable<ProductCategoryPreviewViewModel>>(this.shopData.ProductCategoryRepository.Get());
            this.PropertyChanged += this.ShowProductsFromCategory;
        }

        public IEnumerable<ProductCategoryPreviewViewModel> Categories { get; set; }

        public ProductPreviewViewModel SelectedProduct { get; set; }

        public ProductCategoryPreviewViewModel SelectedCategory
        {
            get
            {
                return this.selectedCategory;
            }
            set
            {
                this.selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public IEnumerable<ProductPreviewViewModel> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
                this.OnPropertyChanged("Products");
            }
        }

        public int QuantitySold
        {
            get
            {
                return this.quantitySold;
            }
            set
            {
                if (this.quantitySold == value)
                {
                    return;
                }
                this.quantitySold = value;
                this.OnPropertyChanged("QuantitySold");
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public ICommand SellCommand
        {
            get
            {
                if (this.sellCommand == null)
                {
                    this.sellCommand = new RelayCommand(
                            this.CreateSale,
                            this.IsValid
                        );
                }
                return this.sellCommand;
            }
        }

        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = null;
                switch (propertyName)
                {
                    case "QuantitySold":
                        error = ValidateQuantity(this.QuantitySold);
                        break;
                    default:
                        throw new ArgumentException("Invalid property name");
                }

                return error;
            }
        }

        public bool IsValid()
        {
            bool quantityValid = this.ValidateQuantity(this.QuantitySold) == null;
            bool productValid = this.SelectedProduct != null;
            return quantityValid &&
                productValid;
        }

        private void CreateSale()
        {
            if (this.IsValid())
            {
                try
                {
                    var product = this.shopData.ProductRepository.GetById(this.SelectedProduct.ProductId);
                    if (this.QuantitySold > product.Quantity)
                    {
                        this.Message = "Product out of stock";
                        return;
                    }
                    var sale = Mapper.Map<Sale>(this);
                    this.shopData.SaleRepository.Add(sale);
                    this.shopData.Save();
                    this.Message = "Sale created";
                }
                catch
                {
                    this.Message = "Error creating sale";
                }
            }
        }

        private string ValidateQuantity(int quantityValue)
        {
            string error = null;
            if (quantityValue <= 0)
            {
                error = "Quantity cannot be 0 or negative";
            }
            return error;
        }

        private void ShowProductsFromCategory(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedCategory"))
            {
                var productModels = this.shopData.ProductRepository.Get(
                    p => p.ProductCategoryId == this.SelectedCategory.ProductCategoryId);
                this.Products = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(productModels);
            }
        }
    }
}
