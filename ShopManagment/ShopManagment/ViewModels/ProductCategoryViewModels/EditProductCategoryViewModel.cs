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
    public class EditProductCategoryViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private ICommand editProductCategoryCommand;
        private string name;
        private string message;

        public EditProductCategoryViewModel(IShopData shopData)
        {
            this.shopData = shopData;
        }

        public int ProductCategoryId { get; set; }

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

        public ICommand EditProductCategoryCommand
        {
            get
            {
                if (this.editProductCategoryCommand == null)
                {
                    this.editProductCategoryCommand = 
                        new RelayCommand(() => this.UpdateProductCategory(), () => this.IsValid());
                }
                return this.editProductCategoryCommand;
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

        private void UpdateProductCategory()
        {
            try
            {
                if (this.IsValid())
                {
                    var productCategory = this.shopData.ProductCategoryRepository.GetById(this.ProductCategoryId);
                    Mapper.Map(this, productCategory);
                    this.shopData.ProductCategoryRepository.Update(productCategory);
                    this.shopData.Save();
                    this.Message = "Product category updated successfully";
                }
            }
            catch
            {
                this.Message = "Product category updated unsuccessfully";
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
