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
using System.Configuration;
using GadgetHub.WebUI.Infrastructure.Abstract;
using GadgetHub.WebUI.Infrastructure.Concrete;  

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
            mykernel.Bind<IGadgetRepository>().To<EFGadgetRepository>();
            emailSettings emailSettings = new emailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "False")
            };

            mykernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

            // Authentication
            mykernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

    }
}