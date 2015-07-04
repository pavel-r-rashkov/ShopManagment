using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ShopManagment.Commands;
using ShopManagment.Data;
using ShopManagment.DataAccess;
using ShopManagment.DataAccess.Interfaces;

namespace ShopManagment.ViewModels.ProductViewModels
{
    public class CreateProductViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private Product product;
        private ICommand createProductCommand;
        private string message;

        public CreateProductViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.product = new Product();
        }

        public string ProductName 
        {
            get
            {
                return this.product.Name;
            }
            set
            {
                if (this.product.Name != null && this.product.Name.Equals(value))
                {
                    return;
                }
                this.product.Name = value;
                this.OnPropertyChanged("ProductName");
            } 
        }

        public decimal Price
        {
            get
            {
                return this.product.Price;
            }
            set
            {
                if (this.product.Price.Equals(value))
                {
                    return;
                }
                this.product.Price = value;
                this.OnPropertyChanged("Price");
            }
        }

        public ICommand CreateProductCommand
        {
            get
            {
                if (this.createProductCommand == null)
                {
                    this.createProductCommand = 
                        new RelayCommand(() => this.SaveProduct(), () => this.IsValid());
                }
                return this.createProductCommand;
            }
        }

        public string Message {
            get
            {
                return this.message;
            }
            set
            {
                if (this.message != null && this.message.Equals(value))
                {
                    return;
                }
                this.message = value;
                this.OnPropertyChanged("Message");
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
                    case "Price":
                        error = ValidatePrice(this.Price);
                        break;
                    case "ProductName":
                        error = ValidateProductName(this.ProductName);
                        break;
                    default:
                        throw new ArgumentException("Invalid property name");
                }
                
                return error;
            }
        }

        private void SaveProduct()
        {
            try
            {
                if (this.IsValid())
                {
                    this.product.ProductCategoryId = 1;
                    this.shopData.ProductRepository.Add(this.product);
                    this.shopData.Save();
                    this.Message = "Product creation successful";
                }
            }
            catch
            {
                this.Message = "Product creation unsuccessful";
            }       
        }

        private bool IsValid()
        {
            var validName = ValidateProductName(this.ProductName) == null;
            var validPrice = ValidatePrice(this.Price) == null;
            return validName && validPrice;
        }

        private string ValidateProductName(string name)
        {
            string error = null;
            if (String.IsNullOrEmpty(name) ||
                name.Trim() == String.Empty)
            {
                error = "Product name is missing";
            }
            else if (name.Length < 3)
            {
                error = "Name is too short";
            }
            else if (name.Length > 40)
            {
                error = "Name is too long";
            }
            return error;
        }

        private string ValidatePrice(decimal price)
        {
            string error = null;
            if (price < 0)
            {
                error = "Price cannot be negative";
            }
            return error;
        }      
    }
}
