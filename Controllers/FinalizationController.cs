using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class FinalizationController : Controller
{
    private readonly ApplicationDbContext _context;

    public FinalizationController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult EscolherLocal()
    {
        return View();
    }
    public IActionResult CPFnaNota()
    {
        return View();
    }
    public IActionResult Pagamento()
    {
        return View();
    }
    public IActionResult PedidoFinalizado()
    {
        return View();
    }

    // Actions for the Finalization process
}