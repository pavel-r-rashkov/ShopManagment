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
using ShopManagment.Views.Sale;

namespace ShopManagment.ViewModels.SaleViewModels
{
    public class SalesListViewModel : ViewModelBase
    {
        private IShopData shopData;
        private ICommand showSaleDetailsCommand;

        public SalesListViewModel(IShopData shopData)
        {
            this.shopData = shopData;
            this.Sales = Mapper.Map<ObservableCollection<SalePreviewViewModel>>(this.shopData.SaleRepository.Get());
        }

        public ObservableCollection<SalePreviewViewModel> Sales { get; set; }

        public SalePreviewViewModel SelectedSale { get; set; }

        public ICommand ShowSaleDetailsCommand
        {
            get
            {
                if (this.showSaleDetailsCommand == null)
                {
                    this.showSaleDetailsCommand = new RelayCommand(
                            this.ShowSaleDetails,
                            this.SaleIsSelected
                        );
                }
                return this.showSaleDetailsCommand;
            }
        }

        private bool SaleIsSelected()
        {
            return this.SelectedSale != null;
        }

        private void ShowSaleDetails()
        {
            var saleDetailsWindow = new SaleDetails(this.SelectedSale.SaleId);
            saleDetailsWindow.Show();
        }
    }
}
