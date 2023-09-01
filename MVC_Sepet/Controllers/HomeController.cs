using Microsoft.AspNetCore.Mvc;
using MVC_Sepet.Models.Context;
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
            return View();
        }

        
    }
}