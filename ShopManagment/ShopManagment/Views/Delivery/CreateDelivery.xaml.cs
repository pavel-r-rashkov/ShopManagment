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
using ShopManagment.ViewModels.DeliveryViewModels;

namespace ShopManagment.Views.Delivery
{
    /// <summary>
    /// Interaction logic for CreateDelivery.xaml
    /// </summary>
    public partial class CreateDelivery : Window
    {
        public CreateDelivery()
        {
            InitializeComponent();
            this.DataContext = ObjectFactory.Get<CreateDeliveryViewModel>();
        }
    }
}
