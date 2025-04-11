using System.Linq;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IGadgetRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IGadgetRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
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

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed", shippingDetails);
            }
            else
            {
                return View(new ShippingDetails());
            }          
        }
    } 
}
