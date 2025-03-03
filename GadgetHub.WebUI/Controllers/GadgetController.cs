using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetRepository myrepospitory;

        public GadgetController(IGadgetRepository gadgetRepository)
        {
            this.myrepospitory = gadgetRepository;
        }

        public int PageSize = 3;

        public ViewResult List(int page = 1)
        {
            GadgetsListViewModel model = new GadgetsListViewModel
            {
                Gadgets = myrepospitory.Gadgets.OrderBy(g => g.GadgetID)
                                               .Skip((page - 1) * PageSize)
                                               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = myrepospitory.Gadgets.Count()
                }

            };
        return View(model);

        }
    }
}