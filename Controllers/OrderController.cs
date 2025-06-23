
using Microsoft.AspNetCore.Mvc;
using TotemPWA.Data;

namespace TotemPWA.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }   
        public IActionResult ApplyCupom(string code)
        {
           var desconto = _context.Cupons
            .Where(c => c.Codigo == code)
            .Select(c => c.Desconto)
            .FirstOrDefault();

            return Json(new { desconto });
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
