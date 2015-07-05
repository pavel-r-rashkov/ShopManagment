using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using ShopManagment.Commands;
using ShopManagment.Data;
using ShopManagment.DataAccess;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.ProductCategoryViewModels;

namespace ShopManagment.ViewModels.ProductViewModels
{
    public class CreateProductViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private ICommand createProductCommand;
        private string name;
        private decimal price;
        private string message;
        //private int selectedCategoryId;

        public CreateProductViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.PopulateProductCategories();
        }

        public IEnumerable<ProductCategoryPreviewViewModel> Categories { get; set; }

        public int SelectedCategoryId { get; set; }
        //public int SelectedCategoryId
        //{
        //    get
        //    {
        //        return this.selectedCategoryId;
        //    }
        //    set
        //    {
        //        if (this.selectedCategoryId == value)
        //        {
        //            return;
        //        }
        //        this.selectedCategoryId = value;
        //        this.OnPropertyChanged("");
        //    }
        //}

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != null && this.name.Equals(value))
                {
                    return;
                }
                this.name = value;
                this.OnPropertyChanged("Name");
            } 
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price.Equals(value))
                {
                    return;
                }
                this.price = value;
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
                    case "Name":
                        error = ValidateProductName(this.Name);
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
                    var product = Mapper.Map<Product>(this);
                    this.shopData.ProductRepository.Add(product);
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
            var validName = ValidateProductName(this.Name) == null;
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

        private void PopulateProductCategories()
        {
            var categories = this.shopData.ProductCategoryRepository.Get();
            this.Categories = Mapper.Map<IEnumerable<ProductCategoryPreviewViewModel>>(categories);
        }
    }
}
