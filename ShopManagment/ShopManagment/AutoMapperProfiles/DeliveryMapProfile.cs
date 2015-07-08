using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopManagment.Data;
using ShopManagment.ViewModels.DeliveryViewModels;
using ShopManagment.ViewModels.ProductDeliveryViewModels;

namespace ShopManagment.AutoMapperProfiles
{
    public class DeliveryMapProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CreateDeliveryViewModel, Delivery>()
                .AfterMap((src, dest) => dest.DeliveryDate = DateTime.Now);

            Mapper.CreateMap<Delivery, DeliveryPreviewViewModel>();

            Mapper.CreateMap<Delivery, DeliveryDetailsViewModel>();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
