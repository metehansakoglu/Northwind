using System.Web.Mvc;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public RedirectToRouteResult AddToCard(Cart cart,int productId)
        {

            Product product = _productService.Get(productId);
            cart.AddToCart(product,1);
            
            return RedirectToAction("Index",cart);
        }
        
        public ViewResult Index(Cart cart)
        {
            
            return View(cart);
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId)
        {
            Product product = _productService.Get(productId);
            cart.RemoveFrommCart(product);
            return RedirectToAction("Index",cart);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDeatils());
        }

        [HttpPost]
        public ActionResult CheckOut(ShippingDeatils shippingDeatils)
        {
            if (ModelState.IsValid)
            {
                return View("Completed");
            }
            else
            {
                return View(shippingDeatils);
            }
        }

        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}