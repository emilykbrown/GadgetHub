using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.Domain.Concrete;

namespace GadgetHub.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernalParm)
        {
            mykernel = kernalParm;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return mykernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type myServiceType)
        {
            return mykernel.GetAll(myServiceType);
        }

        public void AddBindings()
        {
            /*
            Mock<IGadgetRepository> myMock = new Mock<IGadgetRepository>();
            myMock.Setup(m => m.Gadgets).Returns(new List<Gadget>
            {
                new Gadget { Name = "Laptop", Brand = "Lenovo", Price = 999.99m, Description = "Powerful CPU and large SSD", Category = "Computers" },
                new Gadget { Name = "Headphones", Brand = "Bose", Price = 249.99m, Description = "Noise cancelling and comfortable for multiple hours of wear", Category = "Computers" },
                new Gadget { Name = "Keyboard", Brand = "Logitech", Price = 74.99m, Description = "Made for fast, smooth typing", Category = "Accessories" }
            });
            mykernel.Bind<IGadgetRepository>().ToConstant(myMock.Object);
            */
            mykernel.Bind<IGadgetRepository>().To<EFGadgetRepository>();
        }   

    }
}