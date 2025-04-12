using System.Web.Mvc;
using GadgetHub.Domain.Abstract;

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
    }
}