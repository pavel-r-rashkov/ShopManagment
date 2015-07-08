using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopManagment.Data;
using ShopManagment.ViewModels.SaleViewModels;

namespace ShopManagment.AutoMapperProfiles
{
    public class SaleMapProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CreateSaleViewModel, Sale>()
                .ForMember(dest => dest.ProductId,
                    opts => opts.MapFrom(
                        src => src.SelectedProduct.ProductId))
                .AfterMap((src, dest) => dest.SaleDate = DateTime.Now);
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
