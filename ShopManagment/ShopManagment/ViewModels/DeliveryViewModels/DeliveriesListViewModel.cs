using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        private ICommand showCreateDeliveryWindowCommand;

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

        public ICommand ShowCreateDeliveryWindowCommand
        {
            get
            {
                if (this.showCreateDeliveryWindowCommand == null)
                {
                    this.showCreateDeliveryWindowCommand = new RelayCommand(
                            this.ShowCreateDeliveryWindow
                        );
                }
                return this.showCreateDeliveryWindowCommand;
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

        private void ShowCreateDeliveryWindow()
        {
            var createDeliveryWindow = new CreateDelivery();
            createDeliveryWindow.Show();
        }
    }
}
