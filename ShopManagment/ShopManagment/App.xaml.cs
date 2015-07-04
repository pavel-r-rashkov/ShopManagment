﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using Ninject;
using ShopManagment.NinjectModules;
using ShopManagment.Views.Product;

namespace ShopManagment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            this.ConfigureContainer();
            ObjectFactory.InitializeKernel(this.kernel);
            AutoMapperConfig.InitializeKernel(this.kernel);
            AutoMapperConfig.RegisterMappings();
            base.OnStartup(e);
        }

        private void ConfigureContainer()
        {
            this.kernel = new StandardKernel(new DataModule());
        }
    }
}
