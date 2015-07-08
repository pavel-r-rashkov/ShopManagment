using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopManagment.Data;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.AutoMapperProfiles
{
    public class ProductMapProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CreateProductViewModel, Product>()
                .ForMember(dest => dest.ProductCategoryId,
                    opts => opts.MapFrom(
                        src => src.SelectedCategoryId));

            Mapper.CreateMap<Product, ProductPreviewViewModel>();

            Mapper.CreateMap<Product, EditProductViewModel>();

            Mapper.CreateMap<Product, ProductDetailsViewModel>();

            Mapper.CreateMap<EditProductViewModel, Product>()
                .ForMember(dest => dest.ProductCategoryId,
                    opts => opts.MapFrom(
                        src => src.SelectedCategoryId));
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
