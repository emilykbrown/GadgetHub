using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;

namespace GadgetHub.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernal myKenral;

        public NinjectDependencyResolver(IKernal kernalParm)
        {
            myKenral = kernalParm;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return myKenral.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return myKenral.GetServices(myserviceType);
        }

        public void AddBindings()
        {
            myKenral.Bind<IGadget>().
        }

    }
}