using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using System.Linq;
using GadgetHub.Domain.Entities;    

namespace GadgetHub.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IGadgetRepository repository;

        public AdminController(IGadgetRepository repo)
        {
           repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Gadgets);
        }

        public ViewResult Edit(int GadgetID)
        {
            Gadget gadget = repository.Gadgets
                .FirstOrDefault(g => g.GadgetID == GadgetID);
            return View(gadget);
        }   
    }
}