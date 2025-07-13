using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string login, string senha)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Login == login && u.Senha == senha);

        if (user != null)
        {
            // Autenticação bem-sucedida, redirecionar para a página de administração
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            return RedirectToAction("Dashboard");
        }

        // Autenticação falhou, retornar à página de login com mensagem de erro
        ViewBag.ErrorMessage = "Login ou senha inválidos.";
        return View();
    }

    public async Task<IActionResult> ViewPedido(int id)
    {
        var pedidos = await _context.Pedidos
        .Include(p => p.Itens)
        .ToListAsync();

        return View(pedidos);
    }

    public async Task<IActionResult> Pedidos(int id)
    {
        var pedido = await _context.Pedidos
            .Include(p => p.Itens)
                .ThenInclude(i => i.Ingredientes)
            .Include(p => p.Itens)
                .ThenInclude(i => i.ComboLanches)
                    .ThenInclude(c => c.Ingredientes)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido == null)
        {
            return NotFound();
        }

        return View(pedido);
    }


    public IActionResult Dashboard()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
