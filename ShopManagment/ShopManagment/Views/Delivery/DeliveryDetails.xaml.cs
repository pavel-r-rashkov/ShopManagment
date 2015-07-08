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
using ShopManagment.ViewModels.DeliveryViewModels;
using ShopManagment.ViewModels.ProductCategoryViewModels;

namespace ShopManagment.Views.Delivery
{
    /// <summary>
    /// Interaction logic for DeliveryDetails.xaml
    /// </summary>
    public partial class DeliveryDetails : Window
    {
        public DeliveryDetails(int id)
        {
            InitializeComponent();
            var delivery = ObjectFactory.Get<IShopData>().DeliveryRepository.GetById(id);
            var deliveryDetailsViewModel = Mapper.Map<DeliveryDetailsViewModel>(delivery);
            this.DataContext = deliveryDetailsViewModel;
        }
    }
}
