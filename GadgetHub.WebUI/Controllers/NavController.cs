using GadgetHub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetHub.WebUI.Controllers
{
    public class NavController : Controller
    {

        private IGadgetRepository repository;

        public NavController (IGadgetRepository repo)
        {
           repository = repo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> GadgetCategories = repository.Gadgets.Select(x => x.GadgetCategory)
                                                                                   .Distinct()
                                                                                   .OrderBy(x => x);

            return PartialView(GadgetCategories);
        }
    }
}