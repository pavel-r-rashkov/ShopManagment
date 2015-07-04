using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopManagment.Data;
using ShopManagment.DataAccess.Interfaces;
using ShopManagment.ViewModels.ProductCategoryViewModels;

namespace ShopManagment.AutoMapperProfiles
{
    public class ProductCategoryMapProfile : Profile
    {
        private readonly IShopData shopData;

        public ProductCategoryMapProfile(IShopData shopData)
        {
            this.shopData = shopData;
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CreateProductCategoryViewModel, ProductCategory>();

            Mapper.CreateMap<ProductCategory, EditProductCategoryViewModel>().ConstructUsingServiceLocator();

            Mapper.CreateMap<EditProductCategoryViewModel, ProductCategory>();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
