using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopManagment.DataAccess.Interfaces;
using AutoMapper;
using ShopManagment.Commands;
using ShopManagment.Views.Delivery;

namespace ShopManagment.ViewModels.DeliveryViewModels
{
    public class DeliveriesListViewModel : ViewModelBase
    {
        private IShopData shopData;
        private ICommand showDeliveryDetailsCommand;

        public DeliveriesListViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.Deliveries = Mapper.Map<ObservableCollection<DeliveryPreviewViewModel>>(this.shopData.DeliveryRepository.Get());
        }

        public ObservableCollection<DeliveryPreviewViewModel> Deliveries { get; set; }

        public DeliveryPreviewViewModel SelectedDelivery { get; set; }

        public ICommand ShowDeliveryDetailsCommand
        {
            get
            {
                if (this.showDeliveryDetailsCommand == null)
                {
                    this.showDeliveryDetailsCommand = new RelayCommand(
                            this.ShowDeliveryDetails,
                            this.DeliveryIsSelected
                        );
                }
                return this.showDeliveryDetailsCommand;
            }
        }

        private bool DeliveryIsSelected()
        {
            return this.SelectedDelivery != null;
        }

        private void ShowDeliveryDetails()
        {
            var deliveryDetailsWindow = new DeliveryDetails(SelectedDelivery.DeliveryId);
            deliveryDetailsWindow.Show();
        }
    }
}
