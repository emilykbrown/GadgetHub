using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetRepository myrepospitory;

        public GadgetController (IGadgetRepository gadgetRepospitory, IGadgetRepository IGadgetRepository)
        {
            this.myrepospitory = IGadgetRepository;
        }   

        public ViewResult List ()
        {
            return View(myrepospitory.Gadgets);
        }
    }
}