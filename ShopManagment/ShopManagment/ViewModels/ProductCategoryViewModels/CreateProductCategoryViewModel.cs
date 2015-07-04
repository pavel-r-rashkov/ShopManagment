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

namespace ShopManagment.ViewModels.ProductCategoryViewModels
{
    public class CreateProductCategoryViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private ICommand createProductCategoryCommand;
        private string name;
        private string message;

        public CreateProductCategoryViewModel(IShopData shopData)
        {
            this.shopData = shopData;
        }

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

        public ICommand CreateProductCategoryCommand
        {
            get
            {
                if (this.createProductCategoryCommand == null)
                {
                    this.createProductCategoryCommand = 
                        new RelayCommand(() => this.SaveProductCategory(), () => this.IsValid());
                }
                return this.createProductCategoryCommand;
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
                    case "Name":
                        error = ValidateProductName(this.Name);
                        break;
                    default:
                        throw new ArgumentException("Invalid property name");
                }
                
                return error;
            }
        }

        private void SaveProductCategory()
        {
            try
            {
                if (this.IsValid())
                {
                    var product = Mapper.Map<ProductCategory>(this);
                    this.shopData.ProductCategoryRepository.Add(product);
                    this.shopData.Save();
                    this.Message = "Product category creation successful";
                }
            }
            catch
            {
                this.Message = "Product category creation unsuccessful";
            }       
        }

        private bool IsValid()
        {
            var validName = ValidateProductName(this.Name) == null;
            return validName;
        }

        private string ValidateProductName(string name)
        {
            string error = null;
            if (String.IsNullOrEmpty(name) ||
                name.Trim() == String.Empty)
            {
                error = "Category name is missing";
            }
            else if (name.Length < 3)
            {
                error = "Category name is too short";
            }
            else if (name.Length > 40)
            {
                error = "Category name is too long";
            }
            return error;
        }
    }
}
