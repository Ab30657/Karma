using Ninject;
using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyResolver(IKernel param)
        {
            kernel = param;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepos>().To<ProductRepository>();
        }

        public object GetService(Type serviceType)
        {
           return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}