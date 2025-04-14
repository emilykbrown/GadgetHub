using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using System.Linq;
using GadgetHub.Domain.Entities;
using System.Web;

namespace GadgetHub.WebUI.Controllers
{
    [Authorize]
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
        [HttpPost]
        public ActionResult Edit(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGadget(gadget);
                TempData["message"] = string.Format("{0} has been saved", gadget.GadgetName);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(gadget);
            }
        }

        [HttpPost]
        public ActionResult Save(Gadget gadget, HttpPostedFileBase image=null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    gadget.ImageMimeType = image.ContentType;
                    gadget.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(gadget.ImageData, 0, image.ContentLength);
                }
                repository.SaveGadget(gadget);
                TempData["message"] = string.Format("{0} has been saved", gadget.GadgetName);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(gadget);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Gadget());
        }

        [HttpPost]
        public ActionResult Delete(int GadgetID)
        {
            Gadget deletedGadget = repository.DeleteGadget(GadgetID);
            if (deletedGadget != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedGadget.GadgetName);
            }
            return RedirectToAction("Index");
        }
    }
}