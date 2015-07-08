using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ShopManagment.Data;
using ShopManagment.DataAccess;
using ShopManagment.DataAccess.Interfaces;

namespace ShopManagment.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ShopManagmentContext>();
            Bind<IShopData>().To<ShopData>().InSingletonScope();
        }
    }
}
