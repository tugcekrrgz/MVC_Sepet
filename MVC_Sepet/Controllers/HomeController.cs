using Microsoft.AspNetCore.Mvc;
using MVC_Sepet.Models.Context;
using MVC_Sepet.Models.Entity;
using MVC_Sepet.Utils;
using System.Diagnostics;

namespace MVC_Sepet.Controllers
{
    public class HomeController : Controller
    {

        private NorthwindContext _context;
        public HomeController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var products = _context.Products.ToList(); --> IEnumarable
            return View(_context.Products.ToList()); //IQueryable (aynlış yazmış olabilirm) serveri çok meşgul etmez. Daha az işlem olur.
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyCart()
        {
            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
            {
                var sepet = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
                return View(sepet);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult AddToCart(int id)
        {
            //serverda oturum mevcut mu
            Cart cartSession;
            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session,"sepet")==null)
            {
                cartSession = new Cart();
            }
            else
            {
                cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            }


            //Sepete ürünün eklenmesi ve işlemin anasayfaya yönlendirilmesi
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CartItem cartItem = new CartItem()
                {
                    Id = product.ProductId,
                    UnitPrice = product.UnitPrice,
                    ProductName = product.ProductName,

                };
                cartSession.AddItem(cartItem);
                SessionHelper.SetJsonProduct(HttpContext.Session,"sepet",cartSession);

                TempData["CardCount"] = cartSession._myCart.Count();

                return RedirectToAction("Index");

               
               

            }
            
        }

        public IActionResult CompleteCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompleteCart(AppUser user)
        {
            Customer customer=new Customer();
            customer.CustomerId = user.Id;
            customer.ContactName = user.AdSoyad;
            customer.CompanyName = $"{user.AdSoyad} Sanayi Limited Şirketi";

            _context.Customers.Add(customer);
            _context.SaveChanges();

            HttpContext.Session.Remove("sepet");
            return RedirectToAction("Index");
        }
    }
}