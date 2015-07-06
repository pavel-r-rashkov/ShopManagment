using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using ShopManagment.Commands;
using ShopManagment.Data;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.ProductCategoryViewModels;
using ShopManagment.ViewModels.ProductDeliveryViewModels;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.ViewModels.DeliveryViewModels
{
    public class CreateDeliveryViewModel : ViewModelBase, IDataErrorInfo
    {
        private IShopData shopData;
        private string deliverySource;
        private string description;
        private ICommand addDeliveryCommand;
        private ICommand addProductCommand;
        private ICommand removeProductCommand;
        private CreateProductDeliveryViewModel productDelivery;
        private IEnumerable<ProductPreviewViewModel> products;

        public CreateDeliveryViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.ProductDelivery = new CreateProductDeliveryViewModel();
            this.ProductDeliveries = new ObservableCollection<CreateProductDeliveryViewModel>();
            this.Categories = Mapper.Map<IEnumerable<ProductCategoryPreviewViewModel>>(this.shopData.ProductCategoryRepository.Get());
        }

        public IEnumerable<ProductCategoryPreviewViewModel> Categories { get; set; }
        
        public ObservableCollection<CreateProductDeliveryViewModel> ProductDeliveries { get; set; }

        public IEnumerable<ProductPreviewViewModel> Products {
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

        public CreateProductDeliveryViewModel ProductDelivery
        {
            get
            {
                return this.productDelivery;
            }
            set
            {
                this.productDelivery = value;
                this.OnPropertyChanged("ProductDelivery");
            }
        }

        public string DeliverySource
        {
            get
            {
                return this.deliverySource;
            }
            set
            {
                if (this.deliverySource != null && this.deliverySource.Equals(value))
                {
                    return;
                }
                this.deliverySource = value;
                this.OnPropertyChanged("DeliverySource");
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description != null && this.description.Equals(value))
                {
                    return;
                }
                this.description = value;
                this.OnPropertyChanged("Description");
            }
        }

        public ICommand AddDeliveryCommand
        {
            get
            {
                if (this.addDeliveryCommand == null)
                {
                    this.addDeliveryCommand = 
                        new RelayCommand(() => this.SubmitDelivery(), () => this.IsValid());
                }
                return this.addDeliveryCommand;
            }
        }

        public ICommand AddProductCommand
        {
            get
            {
                if (this.addProductCommand == null)
                {
                    this.addProductCommand =
                        new RelayCommand(() => this.AddProductDelivery(), () => this.ProductDelivery.IsValid());
                }
                return this.addProductCommand;
            }
        }

        public ICommand RemoveProductCommand
        {
            get
            {
                if (this.removeProductCommand == null)
                {
                    this.removeProductCommand =
                        new ParameterRelayCommand((param) => this.RemoveProductDelivery(param));
                }
                return this.removeProductCommand;
            }
        }

        public bool IsValid()
        {
            bool deliverySourceValid = this.ValidateDeliverySource(this.DeliverySource) == null;
            bool descriptionValid = this.ValidateDescription(this.Description) == null;
            bool productsNotEmpty = this.ProductDeliveries.Count != 0;
            return deliverySourceValid && 
                descriptionValid &&
                productsNotEmpty;
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
                    case "DeliverySource":
                        error = ValidateDeliverySource(this.DeliverySource);
                        break;
                    case "Description":
                        error = ValidateDescription(this.Description);
                        break;
                    default:
                        throw new ArgumentException("Invalid property name");
                }

                return error;
            }
        }

        public void ShowProductsFromCategory(int categoryId)
        {
            var productModels =
                this.shopData.ProductRepository.Get(p => p.ProductCategoryId == categoryId);
            this.Products = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(productModels);
        }

        private string ValidateDeliverySource(string source)
        {
            string error = null;
            if (String.IsNullOrEmpty(source) || source.Trim().Length < 3)
            {
                error = "Delivery source is too short";
            }
            return error;
        }

        private string ValidateDescription(string descriptionValue)
        {
            string error = null;
            if (String.IsNullOrEmpty(descriptionValue) || descriptionValue.Trim().Length < 3)
            {
                error = "Description is too short";
            }
            return error;
        }

        private void SubmitDelivery()
        {
            if (this.IsValid())
            {
                try
                {
                    var delivery = Mapper.Map<Delivery>(this);
                    this.shopData.DeliveryRepository.Add(delivery);
                    this.shopData.Save();
                }
                catch
                {
                    
                }
            }
        }

        private void AddProductDelivery()
        {
            if (this.ProductDelivery.IsValid())
            {
                this.ProductDeliveries.Add(this.ProductDelivery);
                this.ProductDelivery = new CreateProductDeliveryViewModel();
            }
        }

        private void RemoveProductDelivery(object commandParam)
        {
            var productList = commandParam as ListBox;
            if (productList.SelectedItem != null)
            {
                this.ProductDeliveries.Remove(productList.SelectedItem as CreateProductDeliveryViewModel);
            }
        }
    }
}
