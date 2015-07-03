using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ShopManagment
{
    public static class ObjectFactory
    {
        private static IKernel kernel;

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }

        public static void InitializeKernel(IKernel appKernel)
        {
            kernel = appKernel;
        }
    }
}
