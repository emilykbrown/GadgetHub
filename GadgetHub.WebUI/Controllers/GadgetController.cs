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

        public ViewResult List(string GadgetCategory, int page = 1)
        {
            GadgetsListViewModel model = new GadgetsListViewModel
            {
                Gadgets = myrepospitory.Gadgets
                                        .Where(g => GadgetCategory == null || g.GadgetCategory == GadgetCategory)
                                        .OrderBy(g => g.GadgetID)
                                        .Skip((page - 1) * PageSize)
                                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = myrepospitory.Gadgets.Count()
                },
                CurrentGadgetCategory = GadgetCategory



            };
            return View(model);
        }
    }
}