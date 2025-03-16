using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IGadgetRepository repository;

        public CartController(IGadgetRepository repo)
        {
            repository = repo;
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public RedirectToRouteResult AddToCart(int GadgetID, string returnUrl)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.GadgetID == GadgetID);

            if (gadget != null)
            {
                GetCart().AddItem(gadget, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int GadgetID, string returnUrl)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.GadgetID == GadgetID);

            if (gadget != null)
            {
                GetCart().RemoveLine(gadget);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnURL = returnUrl
            });
        }
        
        public PartialViewResult Summary (Cart cart)
        {
            return PartialView(cart);
        }
    }
}
