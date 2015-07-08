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
using ShopManagment.ViewModels.ProductCategoryViewModels;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.Views.Product
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Window
    {
        public ProductDetails(int id)
        {
            InitializeComponent();
            var product = ObjectFactory.Get<IShopData>().ProductRepository.GetById(id);
            var productViewModel = Mapper.Map<ProductDetailsViewModel>(product);
            this.DataContext = productViewModel;
        }
    }
}
