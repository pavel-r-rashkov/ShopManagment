using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using ShopManagment.AutoMapperProfiles;
using ShopManagment.DataAccess.Interfaces;

namespace ShopManagment
{
    public static class AutoMapperConfig
    {
        private static IKernel kernel;

        public static void InitializeKernel(IKernel appKernel)
        {
            kernel = appKernel;
        }

        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(t => kernel.Get(t));
                cfg.AddProfile(new ProductCategoryMapProfile(ObjectFactory.Get<IShopData>()));
                cfg.AddProfile(new ProductMapProfile());
                cfg.AddProfile(new DeliveryMapProfile());
                cfg.AddProfile(new ProductDeliveryMapProfile());
            });
        }
    }
}
