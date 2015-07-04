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
using ShopManagment.ViewModels.ProductCategoryViewModels;

namespace ShopManagment.Views.ProductCategory
{
    /// <summary>
    /// Interaction logic for CreateProductCategory.xaml
    /// </summary>
    public partial class CreateProductCategory : Window
    {
        public CreateProductCategory()
        {
            InitializeComponent();
            //DataContext="{Binding CreateProductCategoryViewModel, Source={StaticResource ViewModelLocator}}"

            this.DataContext = ObjectFactory.Get<CreateProductCategoryViewModel>();
        }
    }
}
