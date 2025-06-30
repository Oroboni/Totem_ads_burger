
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
            var cupom = _context.Cupons
                .FirstOrDefault(c => c.Codigo == code);

            var desconto = cupom != null ? cupom.Desconto : 0;
            var tipo = cupom != null ? cupom.Type.ToString() : null;

            return Json(new { desconto, tipo });
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
