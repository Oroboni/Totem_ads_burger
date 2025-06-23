using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class CartController : Controller
{

    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Carrinho()
    {
        var idsComIngredientes = await _context.Products
            .Where(p => p.Compositions.Any())
            .Select(p => p.Id)
            .ToListAsync();

        ViewBag.IdsComIngredientes = idsComIngredientes;
        return View();
    }


    public async Task<IActionResult> Editar(int id)
    {
        var product = await _context.Products
            .Include(p => p.Compositions)
                .ThenInclude(c => c.Ingredient)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return NotFound();

        return View(product);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
