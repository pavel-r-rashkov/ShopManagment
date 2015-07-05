using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.ViewModels.ProductDeliveryViewModels
{
    public class CreateProductDeliveryViewModel : ViewModelBase, IDataErrorInfo
    {
        private int deliveryQuantity;

        public ProductPreviewViewModel SelectedProduct { get; set; }
        
        public string Name { get; set; }

        public int DeliveryQuantity
        {
            get
            {
                return this.deliveryQuantity;
            }
            set
            {
                if (this.deliveryQuantity == value)
                {
                    return;
                }
                this.deliveryQuantity = value;
                this.OnPropertyChanged("DeliveryQuantity");
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
                    case "DeliveryQuantity":
                        error = ValidateQuantity(this.DeliveryQuantity);
                        break;
                    default:
                        throw new ArgumentException("Invalid property name");
                }

                return error;
            }
        }

        public bool IsValid()
        {
            bool quantityValid = this.ValidateQuantity(this.DeliveryQuantity) == null;
            return quantityValid;
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
    }
}
