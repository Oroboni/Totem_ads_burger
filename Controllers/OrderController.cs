
using Microsoft.AspNetCore.Mvc;
using TotemPWA.Data;

namespace TotemPWA.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult ApplyCupom(string code)
        {
            
            return View();
        }
        public IActionResult SetDeliveryType(string type)
        {
            return View();
        }
        public IActionResult FinalizeOrder()
        {
            return View();
        }
    }
}
