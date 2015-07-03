using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment
{
    public class ViewModelLocator
    {
        public CreateProductViewModel CreateProductViewModel
        {
            get
            {
                return ObjectFactory.Get<CreateProductViewModel>();
            }
        }
    }
}
