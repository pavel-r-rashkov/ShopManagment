using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopManagment.Data;
using ShopManagment.ViewModels.ProductDeliveryViewModels;
using ShopManagment.ViewModels.ProductViewModels;

namespace ShopManagment.AutoMapperProfiles
{
    public class ProductDeliveryMapProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CreateProductDeliveryViewModel, ProductDelivery>()
                .ForMember(dest => dest.ProductId,
                    opts => opts.MapFrom(
                        src => src.SelectedProduct.ProductId));

            Mapper.CreateMap<ProductDelivery, ProductDeliveryPreviewViewModel>();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
