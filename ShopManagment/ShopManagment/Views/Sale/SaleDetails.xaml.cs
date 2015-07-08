using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AutoMapper;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.ProductViewModels;
using ShopManagment.ViewModels.SaleViewModels;

namespace ShopManagment.Views.Sale
{
    /// <summary>
    /// Interaction logic for SaleDetails.xaml
    /// </summary>
    public partial class SaleDetails : Window
    {
        public SaleDetails(int id)
        {
            InitializeComponent();
            var sale = ObjectFactory.Get<IShopData>().SaleRepository.GetById(id);
            var saleViewModel = Mapper.Map<SaleDetailsViewModel>(sale);
            this.DataContext = saleViewModel;
        }
    }
}
